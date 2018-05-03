using System;
using System.Windows.Forms;

namespace OctoWatcher
{
    public partial class Form2 : Form
    {

        printer printer_data = new printer();
        jobMain job_data = new jobMain();

        public Form2()
        {
            InitializeComponent();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            printer_data = getPrinter();
            job_data = getJob();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = string.Format("Printer status:\r{0}\r{1}{2}\r{3}{4}\r{5}\r{6}\r{7}", 
                printer_data.state.text, 
                printer_data.temperature.tool0.actual, printer_data.temperature.tool0.target, 
                printer_data.temperature.bed.actual, printer_data.temperature.bed.target,
                job_data.progress.completion.ToString(),
                job_data.job.file.name,
                job_data.job.file.size);
        }

        //private void icon_MouseMove(object sender, EventArgs e)
        //{
        //    printer_data = getPrinter();
        //    job_data = getJob();
        //    icon.Text = string.Format("Printer status:\r{0}\r{1}", printer_data.state.text, printer_data.temperature.tool0.actual);
        //}
    }
}
