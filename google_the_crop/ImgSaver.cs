//The MIT License (MIT)

//Copyright (c) <2014> <Mikhail S. Pobolovets>

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using Gdk;
using Pinta.Core;
using System;
using System.IO;

namespace GoogleTheCrop
{
    public class ImgSaver
    {
        private const String Filetype = "png";
        private const String Path = "/tmp/";

        public static string Save (Pixbuf pb)
        {
            var doc = PintaCore.Workspace.ActiveDocument;
            var filename = doc.Filename;

            if (filename == null)
                filename = "img";

            var newFileName =
                Path + ((int)DateTime.Now.Ticks).ToString ("X") +
                "_" +
                filename + ".png";

            pb.Savev (newFileName, Filetype, new string[] { }, new string[] { });
            return newFileName;
        }
    }
}
