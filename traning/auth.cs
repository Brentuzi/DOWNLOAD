using System;
using System.Windows.Forms;

namespace traning
{
    public partial class auth : Form
    {
        bool log = false;
        public auth(bool log)
        {
            InitializeComponent();
            this.log = log;
        }

        private void auth_Load(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            string login, password;

            login = Login.Text;
            password = Pass.Text;

            if (login == "1" && password == "1")
            {
                log = true;
                MessageBox.Show("Успешно", "авторизованы", MessageBoxButtons.OK);
                this.Hide();
                Form1 q1 = new Form1(log);
                q1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный пароль", "Попробуйте еще раз", MessageBoxButtons.OK);
            }
        }
    }
}
