using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            int ID = m.getProcIDFromName("toy2.exe");
            if(ID == 0) MessageBox.Show("Nie ma procesu");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int ID = m.getProcIDFromName("toy2.exe");
            bool is_opened = false;
            if (ID > 0)
            {
                is_opened =
                m.OpenProcess("toy2.exe");
            }
            if (is_opened)
            {
                m.writeMemory("0x0052F39E", "bytes", "50");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.OpenProcess("toy2.exe");
            m.writeMemory("0x0052F39E", "int", "50");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)49)
            {
                m.OpenProcess("toy2.exe");
                m.writeMemory("0x0052F39E", "int", "50");
                e.Handled = true;
            }
        }
    }
}
