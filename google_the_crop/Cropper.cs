using Cairo;
using Gdk;
using Gtk;
using Pinta.Core;
using System;

namespace GoogleTheCrop
{
    public class Cropper
    {
        public static Pixbuf Crop ()
        {
            var doc = PintaCore.Workspace.ActiveDocument;
            var rect = doc.GetSelectedBounds (true);

            PintaCore.Actions.Edit.Deselect.Activate ();

            using (var src = doc.GetFlattenedImage ()) {
                using (var dest = new ImageSurface (Format.Argb32, rect.Width, rect.Height)) {
                    using (var ctx = new Context (dest)) {
                        ctx.SetSourceSurface (src, -rect.X, -rect.Y);
                        ctx.Paint ();
                    }

                    // Save
                    return dest.ToPixbuf ();
                }
            }
        }
    }
}
