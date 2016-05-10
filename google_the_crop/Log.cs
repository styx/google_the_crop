using System;
using System.IO;

namespace GoogleTheCrop
{
    public class Log
    {
        private const String PATH = @"/tmp/upload_log.txt";

        public static void Line (string str)
        {
            StreamWriter file = new StreamWriter (PATH, true);
            file.WriteLine (str);
            file.Close ();
        }
    }
}
