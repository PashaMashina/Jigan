using System.Data;
using System.Data.SqlClient;

namespace DBClient
{
    public partial class QueryForm : Form
    {
        DataBase dataBase = new DataBase();
        public QueryForm()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (var connection = dataBase.GetSqlConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(txtQuery.Text, connection);
                try { 
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        dataGridMain.DataSource = table;
                    }
                }catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка в запросе", "SQL Запросы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
