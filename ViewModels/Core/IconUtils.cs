using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RedRatShortcuts.ViewModels.Core
{
    public static class IconUtils
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Converts an icon to <see cref="ImageSource"/>.
        /// </summary>
        /// <param name="icon">The icon to convert.</param>
        /// <returns>The icon as <see cref="ImageSource"/>.</returns>
        public static ImageSource ToImageSource(this Icon icon)
        {            
            Bitmap bitmap = icon.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();

            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            if (!DeleteObject(hBitmap)) throw new Win32Exception("Could not delete hBitmap.");
            return wpfBitmap;
        }
    }
}