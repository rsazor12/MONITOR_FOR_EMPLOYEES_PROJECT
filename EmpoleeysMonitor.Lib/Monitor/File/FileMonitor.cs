using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace EmployeesMonitor.Lib.Monitor.File
{
    public class FileMonitor: IMonitor
    {
        //
        private object locker = new object();
        private List<UserAction> actions = new List<UserAction>();
        private Thread thread;
        private int monitoringInterval;

        string pathToWorkspace;
        List<string> listOfPathsToFiles; //lista zawierajaca sciezki do wszystkich plikow w Workspace
        Dictionary<string, int> dictionaryOfFilesAndLines;

        //
        public FileMonitor()
        {
            this.dictionaryOfFilesAndLines = new Dictionary<string, int>();
        }

        public void setUp(string pathToWorkspace, int monitoringIntervalSeconds)
        {
            this.pathToWorkspace = pathToWorkspace;  // inicjuje sciezke
            this.monitoringInterval = monitoringIntervalSeconds; //co ile sekund bedzie monitorowac pliki 

            //sprawdzam czy katalogi robocze istnieja           
            if (!Directory.Exists(pathToWorkspace))
            {
                Directory.CreateDirectory(pathToWorkspace); //jesli katalog nie istnieje to go tworze
            }

            if(!Directory.Exists(pathToWorkspace+@"\oldFiles"))
            {
                Directory.CreateDirectory(pathToWorkspace + @"\oldFiles"); //jesli katalog oldFiles nie istnieje
            }

            //usuwam wszystkie pliki z oldFiles
            Directory.GetFiles(pathToWorkspace + @"\oldFiles").ToList().ForEach(f=> System.IO.File.Delete(f)); //usuwam wszystkie pliki z katalogu oldFiles - żeby miec świeżą wersje

            listOfPathsToFiles = Directory.GetFiles(pathToWorkspace,"*",SearchOption.AllDirectories).ToList();  //pobieram wszystkie ścieżki do plików znajdujacych sie w workspace

            //kopiuje wszystkie pliki z Workspace do katalogu oldFIles
            listOfPathsToFiles.ForEach(f => System.IO.File.Copy(Path.Combine(Environment.CurrentDirectory, f),pathToWorkspace+"\\oldFiles\\"+Path.GetFileName(f)));    

        }


        /// <summary>
        /// Zwraca liczbę linii w podanym pliku (arg - ścieżka do pliku)
        /// </summary>
        private int GetNumberOfLinesFromFile(string pathToFile)
        {
            var lineCount = System.IO.File.ReadLines(pathToFile).Count(); //licze ilosc linii w podanym pliku i zwracam ta liczbe

            return lineCount;
        }

        /// <summary>
        /// Zwraca słownik typu <nazwa_pliku><ilosc_linii>
        /// </summary>
        private Dictionary<string,int> MonitorOfNumberOfLinesInAllFilesInWorkspace()
        {
            //Dictionary<string, int> dictionaryOfFilesAndLines = new Dictionary<string, int>();
            this.dictionaryOfFilesAndLines.Clear();

            listOfPathsToFiles.ForEach(f => this.dictionaryOfFilesAndLines.Add(f, GetNumberOfLinesFromFile(f))); //dla kazdego pliku licze ilosc linii i wpisuje do słownika

            return dictionaryOfFilesAndLines;  //zwracam gotowy słownik
        }


        public void Start()
        {
            thread = new Thread(FileMonitorMainThread);
            thread.Start();

            
        }

        public void End()
        {
            thread.Abort();
        }

        public IList<EmployeesMonitor.Lib.Model.UserAction> GetLatestUserActions()
        {
            lock (locker)
            {
                var items = actions.GetRange(0, actions.Count); // shallow copy of list before clear
                actions.Clear();
                return items;
            }
        }

        ///monitorowanie zmian na plikach
        private void FileMonitorMainThread()
        {
            while (true)
            {
                Thread.Sleep(this.monitoringInterval * 1000);
                this.MonitorOfNumberOfLinesInAllFilesInWorkspace();


                lock (locker)
                {
                    foreach(var file in this.dictionaryOfFilesAndLines)
                    {
                       MessageBox.Show(file.Key +" : "+ file.Value);
                       actions.Add(new UserAction()
                        {
                            ActionType = ActionType.LineCalculating,  //do bazy wrzucam tylko ilosc linii z plikow
                            Date = DateTime.UtcNow,
                            Info = file.Key.ToString() + ":" + file.Value.ToString()
                        });
                    }
                    
                }
            }
        }
    }
}
