using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            string path = Directory.GetCurrentDirectory() + @"\..\..\" + "Data.txt";
            FileStream filestream ;
            try
            {
                filestream = new FileStream(path, FileMode.Open);
            }
            catch (Exception)
            {
                MessageBox.Show("Melumatlar silinib!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamReader reader = new StreamReader(filestream);
            while (reader.Peek() > 0)
            {
                List.Items.Add(reader.ReadLine());
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(richTextBox1.Text) || String.IsNullOrWhiteSpace(richTextBox1.Text)))
            {

                List.Items.Add(richTextBox1.Text);
                string path = Directory.GetCurrentDirectory() + @"\..\..\"+"Data.txt";
                FileStream filestream ;
                if (File.Exists(path))
                 filestream = new FileStream(path, FileMode.Append);
                else
                {
                    MessageBox.Show("Melumatlar silinib!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             
                StreamWriter writer = new StreamWriter(filestream);
                writer.WriteLine(richTextBox1.Text);
                writer.Close();
            }

            else
            {
                MessageBox.Show("Task bos ola bilmez!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            richTextBox1.Text = String.Empty;
        }
    }
}
