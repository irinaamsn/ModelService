using ImitModelBl.Model;
using Microsoft.EntityFrameworkCore;

namespace ImitModelUI
{
    public partial class Main : Form
    {
        DataContext db;
        public Main()
        {
            InitializeComponent();
            db = new DataContext();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void óñëóãèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogService = new Catalog<Service>(db.Services);
            catalogService.Show();
        }

        private void ìàñòåðàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogMaster = new Catalog<Master>(db.Masters);
            catalogMaster.Show();
        }

        private void êëèåíòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers);
            catalogCustomer.Show();
        }

        private void ÷åêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks);
            catalogCheck.Show();
        }

        private void masterAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new MasterForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Masters.Add(form.Master);
                db.SaveChanges();
            }
        }
    }
}