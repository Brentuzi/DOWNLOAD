using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DataTable = System.Data.DataTable;

namespace traning
{
    public partial class Book : Form
    {
        bool log = false;
        string connectionString = "Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=exercise;Integrated Security=True";
        public Book(bool log)
        {
            InitializeComponent();
            this.log = log;
        }
        
        void Refd()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте подключение.
                connection.Open();

                // Ваш SQL-запрос.
                string sqlQuery = @"
                SELECT   Id_book, Name, Id_author, Creator, Year, Count
FROM      dbo.Book
            ";

                // Создайте команду SQL для получения данных.
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Создайте новый адаптер данных и заполните DataGridView.
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Установите источник данных для вашего DataGridView.
                        dataGridView1.DataSource = table;
                    }
                }
            }
        }

        private void Book_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "exerciseDataSet.Book". При необходимости она может быть перемещена или удалена.
            this.bookTableAdapter1.Fill(this.exerciseDataSet.Book);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "exerciseDataSet1.Book". При необходимости она может быть перемещена или удалена.
            this.bookTableAdapter.Fill(this.exerciseDataSet1.Book);

            if (log == true) {

                this.Size = new Size(1197, 694);
            }

            Refd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=exercise;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = @"
    INSERT INTO dbo.Book (Name, Id_author, Creator, Year, Count) 
    VALUES (@name, @id_author, @creator, @year, @count)
";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                  //  command.Parameters.AddWithValue("@id_book", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@id_author", int.Parse(textBox3.Text));
                    command.Parameters.AddWithValue("@creator", comboBox1.Text);
                    command.Parameters.AddWithValue("@year", int.Parse(textBox5.Text));
                    command.Parameters.AddWithValue("@count", int.Parse(textBox6.Text));

                    command.ExecuteNonQuery();
                }
            }

            // Закрываем форму после добавления записи.
            Refd();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            string sqlQuery = @"
    UPDATE dbo.Book 
    SET Name = @name, Id_author = @id_author, Creator = @creator, Year = @year, Count = @count
    WHERE Id_book = @id_book
";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id_book", int.Parse(comboBox2.Text));
                    command.Parameters.AddWithValue("@name", textBox2.Text);
                    command.Parameters.AddWithValue("@id_author", int.Parse(textBox3.Text));
                    command.Parameters.AddWithValue("@creator", comboBox1.Text);
                    command.Parameters.AddWithValue("@year", int.Parse(textBox5.Text));
                    command.Parameters.AddWithValue("@count", int.Parse(textBox6.Text));

                    command.ExecuteNonQuery();
                }
            }
            Refd();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlQuery = @"
    DELETE FROM dbo.Book 
    WHERE Id_book = @id_book
";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id_book", int.Parse(comboBox2.Text));

                    command.ExecuteNonQuery();
                }
            }
            Refd();
        }
    }

}
