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

namespace File_Manager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetDat.EventHandler = new SetDat.SetData(SetData);
        }
        void SetData(string name)
        {
            textBox1.Text = name;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetDat.EventHandler(textBox1.Text, this.DialogResult);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
