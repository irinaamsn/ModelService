using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImitModelBl.Model;
namespace ImitModelUI
{
    public partial class MasterForm : Form
    {
        public Master Master { get; set; }
        public MasterForm()
        {
            InitializeComponent();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master = new Master
            {
                Name = textBox1.Text,
                Speciality = textBox2.Text,
                Qualification =textBox3.Text
            };
            Close();
        }
    }
}
