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
        }

        public Mem m = new Mem();

        private void Form1_Load(object sender, EventArgs e)
        {
            int ID = m.getProcIDFromName("toy2.exe");
            if (ID == 0) { MessageBox.Show("Nie ma procesu"); }
            else m.OpenProcess("toy2.exe");
            if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            if (m.read2Byte("0x0052F396") != 14) m.writeMemory("0x0052F396", "int", "14"); //buzz's HP
            m.writeMemory("0x0040732A", "byte", "0x0"); //invincible buzz
            m.writeMemory("0x004E067C", "byte", "0xC"); //laser
            m.writeMemory("0x004E0676", "byte", "0x14"); //whirl
            m.writeMemory("0x004E068E", "byte", "0x14"); //stomp
            m.writeMemory("0x004E0688", "byte", "0x14"); //disks

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if (m.read2Byte("0x0052F39A") < 1 || m.read2Byte("0x0052F39A") > 1) m.writeMemory("0x0052F39A", "int", "1");
                if (m.read2Byte("0x0052F39E") < 50) m.writeMemory("0x0052F39E", "int", "50");
                if (m.read2Byte("0x0052B7D8") < 5) m.writeMemory("0x0052B7D8", "int", "5");
                if (m.getProcIDFromName("toy2.exe") == 0) { MessageBox.Show("Nie ma procesu"); break; }
            }

        }
    }
}
