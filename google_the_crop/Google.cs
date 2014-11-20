using System;
using System.Diagnostics;

namespace GoogleTheCrop
{
    public class Google
    {

        public static void Now (string img_url)
        {
            Process.Start ("google-chrome", "https://images.google.com/searchbyimage?image_url=" + img_url);
        }
    }
}
