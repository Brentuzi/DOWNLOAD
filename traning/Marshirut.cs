using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace traning
{
    public partial class Marshirut : Form
    {

        public void Kol(){
        dataGridView1.Columns["FIO"].HeaderText = "ФИО Автора";
    dataGridView1.Columns["Name"].HeaderText = "Название Книги";
    dataGridView1.Columns["Creator"].HeaderText = "Создатель";
    dataGridView1.Columns["Id_author"].HeaderText = "ID Автора";
    dataGridView1.Columns["Year"].HeaderText = "Год";
    dataGridView1.Columns["Count"].HeaderText = "Количество";
    }

        bool log = false;
        
        public Marshirut(bool log)
        {
            InitializeComponent();
            this.log = log;


            string connectionString = "Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=exercise;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте подключение.
                connection.Open();

                // Ваш SQL-запрос.
                string sqlQuery = @"
                SELECT   dbo.Author.FIO, dbo.Book.Name, dbo.Book.Creator, dbo.Book.Id_author, dbo.Book.Year, dbo.Book.Count
FROM      dbo.Author INNER JOIN
                dbo.Book ON dbo.Author.Id_author = dbo.Book.Id_author
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
            Kol();

        }

        private void Marshirut_Load(object sender, EventArgs e)
        {
            if (log == false)
            {
                this.Size = new Size(1049, 489);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=exercise;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте подключение.
                connection.Open();

                // Ваш SQL-запрос.
                string sqlQuery = @"
                SELECT   dbo.Author.FIO, dbo.Book.Name, dbo.Book.Creator, dbo.Book.Id_author, dbo.Book.Year, dbo.Book.Count
FROM      dbo.Author INNER JOIN
                dbo.Book ON dbo.Author.Id_author = dbo.Book.Id_author
ORDER BY dbo.Book.Id_author ASC
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=exercise;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте подключение.
                connection.Open();

                // Ваш SQL-запрос.
                string sqlQuery = @"
                SELECT   dbo.Author.FIO, dbo.Book.Name, dbo.Book.Creator, dbo.Book.Id_author, dbo.Book.Year, dbo.Book.Count
FROM      dbo.Author INNER JOIN
                dbo.Book ON dbo.Author.Id_author = dbo.Book.Id_author
ORDER BY dbo.Book.Id_author DESC
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Используйте вашу строку подключения.
            string connectionString = "Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=exercise;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте подключение.
                connection.Open();

                string sqlQuery;

                // Если текстовое поле не пустое, то применяем фильтрацию.
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    sqlQuery = @"
                    SELECT dbo.Author.FIO, dbo.Book.Name, dbo.Book.Creator, dbo.Book.Id_author, dbo.Book.Year, dbo.Book.Count
                    FROM dbo.Author 
                    INNER JOIN dbo.Book 
                    ON dbo.Author.Id_author = dbo.Book.Id_author
                    WHERE dbo.Book.Name LIKE @bookName
                    
                ";
                }
                else // Иначе показываем все данные без фильтрации.
                {
                    sqlQuery = @"
                    SELECT dbo.Author.FIO, dbo.Book.Name, dbo.Book.Creator, dbo.Book.Id_author, dbo.Book.Year, dbo.Book.Count
                    FROM dbo.Author 
                    INNER JOIN dbo.Book 
                    ON dbo.Author.Id_author = dbo.Book.Id_author
                   
                ";
                }

                // Создайте команду SQL для получения данных.
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Если текстовое поле не пустое, то добавляем параметр.
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        command.Parameters.AddWithValue("@bookName", textBox1.Text + "%");
                    }

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
        //using Excel = Microsoft.Office.Interop.Excel;
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();

            if (excelApp != null)
            {
                
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

              
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    excelWorksheet.Cells[1, i + 1] = dataGridView1.Columns[i].Name;
                }

               
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            excelWorksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            
                            excelWorksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                
                excelApp.Visible = true;
            }
        }
    }
}