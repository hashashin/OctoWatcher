using OctoWatcher.Properties;
using System;
using System.Threading;
using System.Windows.Forms;

namespace OctoWatcher
{
    internal static class Program
    {
        private const string Caption = "Octowatcher";
        private const MessageBoxButtons Button = MessageBoxButtons.OK;
        private const MessageBoxIcon Icon = MessageBoxIcon.Warning;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly Mutex mutex = new Mutex(true, "{94fb821b-d743-4ac8-a35a-a1b94b965471}");

        [STAThread]
        private static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MultiFormContext(new MainForm(), new Form2()));
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show(Resources.Program_Main_only_one_instance_at_a_time, Caption, Button, Icon);
            }
        }
    }

    public class MultiFormContext : ApplicationContext
    {
        private int openForms;
        public MultiFormContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach (var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    //When we have closed the last of the "starting" forms, 
                    //end the program.
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };

                form.Show();
            }
        }
    }
}
