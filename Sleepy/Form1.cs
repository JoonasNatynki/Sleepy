using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sleepy
{
    public partial class Form1 : Form
    {
        int timeleft;
        string time;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeleft = Int32.Parse(time) * 60;
            progressBar1.Maximum = timeleft;   // Set progress bar maximum to inputted time
            timer1.Start(); // Start the timer
            timelefttext.Text = timeleft.ToString() + " seconds left!";   // Change the textbox text immediately
            progressBar1.Value = 0; // Start from beginning
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timelefttext.Text = timeleft.ToString() + " seconds left!";    // Update time left
            progressBar1.Increment(1);
            timeleft--;

            if(timeleft == 0)
            {
                //  SHUTDOWN!!
                if(checkBox1.Checked)
                {
                    Process.Start("shutdown", "/s /t 0");   // Shuts down the computer
                }
                //  SLEEP!!!
                if(checkBox2.Checked)
                {
                    Application.SetSuspendState(PowerState.Suspend, false, false);  // Puts the computer to sleep
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void inputfield_TextChanged(object sender, EventArgs e)
        {
            time = inputfield.Text;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timeleft = timeleft + 300;
            timelefttext.Text = timeleft.ToString() + " seconds left!";
            progressBar1.Maximum = progressBar1.Maximum + 300;
        }

        private void inputfield_Enter(object sender, EventArgs e)
        {
            inputfield.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timelefttext_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //  If shutdown, no sleep
            if(checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //  If sleep, no shutdown
            if(checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }
    }
}
