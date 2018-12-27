namespace LanguageChange
{
    using System;
    using System.Activities;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    public sealed class LanguageChangeActivity : NativeActivity
    {       
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);

        public Language LanguageName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            if (LanguageName != null)
            {
                string lang = this.LanguageName.id;
                int ret = LoadKeyboardLayout(lang, 1);
                PostMessage(GetForegroundWindow(), 0x50, 1, ret);
            }
        }

    }
}
