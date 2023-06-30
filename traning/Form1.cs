using System;
using System.Windows.Forms;

namespace traning
{
    public partial class Form1 : Form
    {
        bool log = false;
        public Form1(bool log)
        {
            InitializeComponent();
            this.log = log;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (log) { label1.Visible = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (log == false)
            {
                auth q1 = new auth(log);
                this.Hide();
                q1.ShowDialog();

            }
            else
            {
                MessageBox.Show("Повторная авторизация не требуеться", "авторизованы", MessageBoxButtons.OK);

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void маршрутыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marshirut q1 = new Marshirut(log);
            q1.ShowDialog();
        }

        private void путиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book q1 = new Book(log); q1.ShowDialog();
        }
    }
}
