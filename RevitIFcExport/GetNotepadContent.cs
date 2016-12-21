using System;
using System.Collections.Generic;
using System.Text;

namespace RevitIFcExport
{
    public class GetNotepadContent
    {
        private const int WM_GETTEXT = 0xd;
        private const int WM_GETTEXTLENGTH = 0xe;

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);



        public string GetNotePadContent_Contains(string containsString)
        {
            var resultString = string.Empty;

            while (string.IsNullOrEmpty(resultString))
            {
                resultString = GetAllRunningNotepadInstanceText(containsString);
            }

            return resultString;
        }

        private string GetAllRunningNotepadInstanceText(string containsString)
        {
            var notepadText = string.Empty;
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("notepad");
            foreach (System.Diagnostics.Process p in ps)
            {
                IntPtr editWnd = FindWindowEx(p.MainWindowHandle, IntPtr.Zero, "Edit", "");
                notepadText =  GetText(editWnd);
                if (notepadText.Contains(containsString))
                {
                    p.Kill();
                }
                else
                {
                    notepadText = string.Empty;
                }
            }

            return notepadText;
        }

        private string GetText(IntPtr hWnd)
        {
            int textLength = SendMessage(hWnd, WM_GETTEXTLENGTH, 0, 0) + 1;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(textLength);
            if (textLength > 0)
            {
                SendMessage(hWnd, WM_GETTEXT, textLength, sb);
            }
            return sb.ToString();
        }


    }
}
