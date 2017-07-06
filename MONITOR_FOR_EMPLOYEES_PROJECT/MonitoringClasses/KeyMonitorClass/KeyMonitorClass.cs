using Keystroke.API;
using System;
using System.Windows.Forms;

namespace KeyMonitorClass
{
    public static class MyStorage
    {
        //public static object Storage1;
        public static string logStorage = String.Empty;
    }
    class KeyMonitorClass
    {
        static void Main(string[] args)
        {
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) =>
                {
                    MyStorage.logStorage += character;
                    Console.WriteLine(MyStorage.logStorage);
                });
                Application.Run();
            }


        }


    }
}
