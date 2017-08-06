using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaveToFile
{
    public static class MyStorage
    {
        //public static object Storage1;
        public static string logStorage = String.Empty;
    }

    public static class SaveToDB
    {
        /// <summary>
        /// zapis do bazy danych ciągu znaków ze zmiennej (MyStorage.logStorage)
        /// </summary>
        private static void save()
        {

            Console.WriteLine("zapisuje do bazy: " + MyStorage.logStorage + ' ' + DateTime.Now);
            String path = (@"E:\KeyLog.txt");

            //tymczasowo zapisuje do pliku
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {

                //sw.WriteLine(MyStorage.logStorage + ' ' + DateTime.Now+ "kliknął delete:" + SaveToDB.CountOccurences("<delete>", MyStorage.logStorage) + "razy");
                sw.WriteLine(MyStorage.logStorage + " |kliknął delete:" + SaveToDB.CountOccurences("<delete>", MyStorage.logStorage) + "razy\n liter w tekście: " + SaveToDB.CountLetters(MyStorage.logStorage));

            }

        }

        /// <summary>
        /// co określony czas wykonuje funkcję save()
        /// </summary>
        public static void timer()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(10);

            var timer = new System.Threading.Timer((e) =>
            {
                save();
            }, null, startTimeSpan, periodTimeSpan);


        }


        /// <summary>
        /// zwraca liczbę wystąpień danego tekstu
        /// </summary>
        /// <param name="needle"></param>co zliczmy
        /// <param name="haystack"></param>z czego zliczmy
        /// <returns></returns>
        public static int CountOccurences(string needle, string haystack)
        {
            return (haystack.Length - haystack.Replace(needle, "").Length) / needle.Length;
        }

        /// <summary>
        /// zwraca ilość liter w stringu a przed tym usuwa takie ciągi znaków: <jakiś_tekst>
        /// </summary>
        /// <param name="mystring"></param>
        /// <returns></returns>
        public static int CountLetters(string mystring)
        {
            //usuwanie ciągów znaków typu <shift>
            var output = Regex.Replace(mystring, @" ?\<.*?\>", string.Empty);
            //liczenie liter w stringu
            return output.Count(char.IsLetter);
        }

    }
}
