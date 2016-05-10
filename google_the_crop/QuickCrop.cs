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

using Action = Gtk.Action;
using Cairo;
using Gdk;
using Gtk;
using Pinta.Core;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace GoogleTheCrop
{
    [Mono.Addins.Extension]
    public class QuickCropExtension : IExtension
    {
        private readonly Widget _menuItem;

        #region IExtension Members

        public void Initialize ()
        {
            PintaCore.Actions.Addins.AddMenuItem (_menuItem);
        }

        public void Uninitialize ()
        {
            PintaCore.Actions.Addins.RemoveMenuItem (_menuItem);
        }

        #endregion

        public QuickCropExtension ()
        {
            var menuAction =
                new Action (
                    "google_the_crop",
                    "Google the crop",
                    "Googles selected part of the image",
                    "Menu.View.ZoomToSelection.png");

            menuAction.Activated += (sender, e) => CropSaveGoogle ();
            _menuItem = menuAction.
                CreateAcceleratedMenuItem (Gdk.Key.Q, ModifierType.None);
        }

        public void CropSaveGoogle ()
        {
            var pb = Cropper.Crop ();
            var filepath = ImgSaver.Save (pb);
            ((IDisposable)pb).Dispose ();

            if (filepath != null) {
                var formPath = HtmlForm.Encode (filepath);
                Google.Now (formPath);
            }
        }
    }
}
