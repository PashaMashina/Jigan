using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBClient
{
    public partial class LoginForm : Form
    {
        DataBase dataBase = new DataBase();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
            iconShow.Visible = false;
            tbLogin.MaxLength = 15;
            tbPassword.MaxLength = 15;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginUser = tbLogin.Text;
            var passUser = tbPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT login_user, password_user FROM Register WHERE login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(query, dataBase.GetSqlConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //dataBase.OpenConnection();
            if (table.Rows.Count == 1)
            {
                dataBase.openConnection();
                //command.CommandText = $"INSERT INTO Session (login, driver_id_now) VALUES ('{loginUser}',(SELECT id_driver FROM Register WHERE login = '{loginUser}'))";
                command.CommandText = $"INSERT INTO Session(login, driver_id_now) VALUES('{loginUser}', (SELECT id_driver FROM Register WHERE login_user = '{loginUser}'))";
                command.ExecuteNonQuery();
                dataBase.closeConnection();

                MessageBox.Show("Вы успешно вошли", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if(loginUser == "admin")
                {
                    MainAdminForm userForm = new MainAdminForm();
                    


                    this.Hide();
                    userForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MainUserForm userForm = new MainUserForm();
                    this.Hide();
                    userForm.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Логин или пароль неверны", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void iconHidden_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = false;
            iconHidden.Visible = false;
            iconShow.Visible = true;
        }

        private void iconShow_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
            iconHidden.Visible = true;
            iconShow.Visible = false;
        }
    }
}
