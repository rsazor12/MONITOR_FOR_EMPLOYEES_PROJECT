using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONITOR_FOR_EMPLOYEES_PROJECT.MonitoringClasses.FileMonitorClasses
{
    class FileMonitorClass
    {
        string pathToWorkspace;
        //string[] filesInWorkspace;
        List<string> listOfPathsToFiles; //lista zawierajaca sciezki do wszystkich plikow w Workspace

        /// <summary>
        /// Konstruktor tworzy kopie wszystkich plikow zawartych w workspace(jesli nie istnieje to go tworzy) i kopiuje je do katalogu oldFiles
        /// </summary>
        public FileMonitorClass(string pathToWorkspace)
        {
            this.pathToWorkspace = pathToWorkspace;  // inicjuje sciezke

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
            Directory.GetFiles(pathToWorkspace + @"\oldFiles").ToList().ForEach(f=> File.Delete(f)); //usuwam wszystkie pliki z katalogu oldFiles - żeby miec świeżą wersje

            listOfPathsToFiles = Directory.GetFiles(pathToWorkspace,"*",SearchOption.AllDirectories).ToList();  //pobieram wszystkie ścieżki do plików znajdujacych sie w workspace

            //kopiuje wszystkie pliki z Workspace do katalogu oldFIles
            listOfPathsToFiles.ForEach(f => File.Copy(Path.Combine(Environment.CurrentDirectory, f),pathToWorkspace+"\\oldFiles\\"+Path.GetFileName(f)));


        }

        /// <summary>
        /// Zwraca liczbę linii w podanym pliku (arg - ścieżka do pliku)
        /// </summary>
        private int getNumberOfLinesFromFile(string pathToFile)
        {
            var lineCount = File.ReadLines(pathToFile).Count(); //licze ilosc linii w podanym pliku i zwracam ta lizbe

            return lineCount;
        }

        /// <summary>
        /// Zwraca słownik typu <nazwa_pliku><ilosc_linii>
        /// </summary>
        private Dictionary<string,int> MonitorOfNumberOfLinesInAllFilesInWorkspace()
        {
            Dictionary<string, int> dictionaryOfFilesAndLines = new Dictionary<string, int>();

            listOfPathsToFiles.ForEach(f => dictionaryOfFilesAndLines.Add(f, getNumberOfLinesFromFile(f))); //dla kazdego pliku licze ilosc linii i wpisuje do słownika

            return dictionaryOfFilesAndLines;  //zwracam gotowy słownik
        }
        
        /// <summary>
        /// Handler do obsługi Dispatchera (zapisuje wszystkie dane do bazy jakie udało się zmonitorować na plikach w Workspace)
        /// </summary>
        public void FileMonitorHandlerOfDispatcher()
        {

        }
    }
}
