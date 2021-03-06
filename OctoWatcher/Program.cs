﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using OctoWatcher.Properties;

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
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show(Resources.Program_Main_only_one_instance_at_a_time, Caption, Button, Icon);
            }
        }
    }
}
