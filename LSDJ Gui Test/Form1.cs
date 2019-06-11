using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
namespace LSDJ_Gui_Test
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //initiate the minimum synth commands
            
            //initate Comboboxes
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 1;
            comboBox4.SelectedIndex = 1;
            comboBox5.SelectedIndex = 3;
            //set up the max values for numer up down

            //volume start
            numericUpDown1.Maximum = 255;
            //cutoff start
            numericUpDown2.Maximum = 255;
            //phase start
            numericUpDown3.Maximum = 31;
            //vshift start
            numericUpDown4.Maximum = 255;
            //volume end
            numericUpDown8.Maximum = 255;
            //cutoff end
            numericUpDown7.Maximum = 255;
            //phase end
            numericUpDown6.Maximum = 31;
            //vshift end
            numericUpDown5.Maximum = 255;
            //Q
            numericUpDown9.Maximum = 15;
            //speed
            numericUpDown10.Maximum = 15;
            numericUpDown10.Minimum = 1;  
            //repeat
            numericUpDown11.Maximum = 15;   
            //length
            numericUpDown12.Maximum = 15;








        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //conver numeric updown to hex and store as string

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
           

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            textBox2.Text = saveFileDialog1.FileName.ToString();

            string fileType = Path.GetExtension(saveFileDialog1.FileName).Remove(0,1);


            string fName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);

            string workingDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);

            Directory.SetCurrentDirectory(workingDirectory);

            string startVolume = "0x" + int.Parse(numericUpDown1.Value.ToString()).ToString("X");
            string startCutOff = "0x" + int.Parse(numericUpDown2.Value.ToString()).ToString("X");
            string startPhase = "0x" + int.Parse(numericUpDown3.Value.ToString()).ToString("X");
            string startvShift = "0x" + int.Parse(numericUpDown4.Value.ToString()).ToString("X");
            string waveform = comboBox1.SelectedItem.ToString();
            string filter = comboBox2.SelectedItem.ToString();
            string Q = "0x" + int.Parse(numericUpDown9.Value.ToString()).ToString("X");
            string disd = comboBox3.SelectedItem.ToString();
            string phaseT = comboBox4.SelectedItem.ToString();
            string endVolume = "0x" + int.Parse(numericUpDown8.Value.ToString()).ToString("X");
            string endtCutOff = "0x" + int.Parse(numericUpDown7.Value.ToString()).ToString("X");
            string endPhase = "0x" + int.Parse(numericUpDown6.Value.ToString()).ToString("X");
            string endvShift = "0x" + int.Parse(numericUpDown5.Value.ToString()).ToString("X");
            string play = comboBox5.SelectedItem.ToString();
            string speed = "0x" + int.Parse(numericUpDown10.Value.ToString()).ToString("X");
            string repeat = "0x" + int.Parse(numericUpDown11.Value.ToString()).ToString("X");
            string length = "0x" + int.Parse(numericUpDown12.Value.ToString()).ToString("X");

            //to fucking big string
            string commandLineWithOptions = startVolume + " " + startCutOff + " " + startPhase + " " + startvShift + " --end " + endVolume + " " + endtCutOff + " " + endPhase + " " + endvShift + " --" + waveform + " --" + filter + " --q " + Q + " --" + disd + " --" + phaseT + " --" + play + " --speed " + speed + " --repeat " + repeat + " --length " + length + " --fname " + fName + " --" + fileType;
            string synthFile = Application.StartupPath.ToString() + "\\LSDJSynthMod.exe";


            var startInfo = new ProcessStartInfo
            {
                FileName = synthFile,
                Arguments = commandLineWithOptions,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            int j = 1;
            var proc = Process.Start(startInfo);
            proc.WaitForExit();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                listBox1.Items.Add(line);
            }
            proc.Dispose();







        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();





            
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start("http://pastebin.com/Kn9UMYAQ");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
