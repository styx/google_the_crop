using System;
using System.Diagnostics;
using Pinta.Core;

namespace GoogleTheCrop
{
    public class Google
    {
        public static void Now (string path)
        {
            var processName = "google-chrome";
            if (SystemManager.GetOperatingSystem () == OS.Mac) {
                processName = "open";
            }

            Log.Line (processName);
            Log.Line (path);

            Process.Start (processName, path);
        }
    }
}
