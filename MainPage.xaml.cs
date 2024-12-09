using System.Diagnostics;

namespace TestNRECrash
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMayCrashClicked(object sender, EventArgs e)
        {
            MayCrashBtn.Text += "";

            // Comment below to avoid the crash that happens inside the try block
            RunProcess();

            try
            {
                object o = null;
                MayCrashBtn.Text = o.ToString();
            }
            catch
            {
            }

            MayCrashBtn.Text += "OK";
        }

        public static void RunProcess()
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "which",
                    Arguments = "ls",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.WaitForExit();
            process.StandardOutput.ReadToEnd();
        }
    }

}
