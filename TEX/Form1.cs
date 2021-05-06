using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEXTER
{
    public partial class Form1 : Form
    {
        string Nowfile;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|All files(*.*)|*.*";
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nowfile = "Noname";
            this.Text = "TEXTER: " + Nowfile;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Nowfile = openFileDialog1.FileName;
                this.Text = "TEXTER: " + Nowfile;
                try
                {
                    richTextBox1.LoadFile(Nowfile);
                }
                catch
                {
                    richTextBox1.LoadFile(Nowfile, (RichTextBoxStreamType)1);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Nowfile, richTextBox1.Text);
            }
            catch
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Nowfile = saveFileDialog1.FileName;
                this.Text = "TEXTER: " + Nowfile;
                File.WriteAllText(Nowfile, richTextBox1.Text);
            }
        }

        private void giToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Zarazdor");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
