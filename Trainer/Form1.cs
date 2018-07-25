using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Trainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public Mem m = new Mem();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            int ID = m.getProcIDFromName("toy2.exe");
            if(ID == 0) MessageBox.Show("Nie ma procesu");
            else m.OpenProcess("toy2.exe");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            if (immortality.Checked)
            {
                    if (m.read2Byte("0x0052F39A") < 1 || m.read2Byte("0x0052F39A") > 1) m.writeMemory("0x0052F39A", "int", "1");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.writeMemory("0x0052F39E", "int", "50");
            var x = m.readBytes("0x00407328", 6);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)49)
            {
                if (immortality.Checked) immortality.Checked = false;
                else immortality.Checked = true;
            }
        }

        private void immortality_CheckedChanged(object sender, EventArgs e)
        {
            if(immortality.Checked) m.writeMemory("0x0040732A", "byte", "0x0");
            else m.writeMemory("0x0040732A", "byte", "0x2");
        }
    }
}
