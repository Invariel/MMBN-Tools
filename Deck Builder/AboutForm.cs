using System.Collections;
using System.Drawing.Text;
using System.Globalization;

namespace Deck_Builder
{
    public partial class frm_About : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        internal static PrivateFontCollection _internalFonts = new();

        public frm_About()
        {
            Thread.Sleep(1000);

            InitializeComponent();

            /// <summary>
            /// Font: https://x.com/megarock_exe/status/959320476790095872
            /// How to Use the Font in WinForms: https://stackoverflow.com/questions/556147/how-do-i-embed-my-own-fonts-in-a-winforms-app
            /// </summary>

            foreach (DictionaryEntry font in Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true)!)
            {
                if (font.Value is byte[] fontData)
                {
                    IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                    System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                    uint dummy = 0;
                    _internalFonts.AddMemoryFont(fontPtr, fontData.Length);
                    AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
                }
            }

            rtxt_About.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 16);
        }
    }
}
