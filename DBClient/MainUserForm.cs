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
    public partial class MainUserForm : Form
    {
        DataBase dataBase = new DataBase();
        int driver_id;
        public MainUserForm()
        {
            InitializeComponent();
        }

        private void MainUserForm_Load(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
            iconShow.Visible = false;
            tbLogin.MaxLength = 15;
            tbPassword.MaxLength = 15;
            driver_id = DriverNow();
            CreateColumsMain();
            RefreshDataGrid(dgvMainUser, driver_id);
            GetUserInfo(driver_id, userInfoMain, lblSexUser, lblClassUser);
            WriteComboBox(driver_id, tbLogin, tbPassword);
        }

        private void WriteComboBox(int id, TextBox log, TextBox pass)
        {
            dataBase.openConnection();
            string queryIdDriverLog = $"SELECT login_user, password_user FROM Register WHERE id_driver = {id}";
            SqlCommand command = new SqlCommand(queryIdDriverLog, dataBase.GetSqlConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                log.Text = reader.GetString(0);
                pass.Text = reader.GetString(1);
            }
            reader.Close();
            dataBase.closeConnection();;
        }

        private int DriverNow()
        {
            SqlCommand command = new($@"
SELECT driver_id_now FROM Session"

, dataBase.GetSqlConnection());

            dataBase.openConnection();
            var driver_id_now = 0;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                driver_id_now = reader.GetInt32(0);
            }
            reader.Close();
            dataBase.closeConnection();
            return driver_id_now;
        }

        private void GetUserInfo(int id, Label label, Label lable2, Label lable3)
        {
            SqlCommand command = new($@"
SELECT name, surname, classification, sex
    FROM Drivers
WHERE Id = {id}"

, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var driver_name = reader.GetString(0);
                var driver_surname = reader.GetString(1);
                var driver_class = reader.GetString(2);
                var driver_sex = reader.GetString(3);
                string fullInfo = $"{driver_name} {driver_surname}";
                label.Text = fullInfo;
                lable2.Text = $"Пол: {driver_sex}";
                lable3.Text = $"Классификация: {driver_class}";
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void CreateColumsMain()
        {
            dgvMainUser.Columns.Add("time_finish", "Время финиша");
            dgvMainUser.Columns.Add("id_race", "ID Автогонки");
            dgvMainUser.Columns.Add("type", "Тип гонки");
            dgvMainUser.Columns.Add("title", "Название гонки");
            dgvMainUser.Columns.Add("date", "Дата проведения");
            dgvMainUser.Columns.Add("city", "Город проведения");
            dgvMainUser.Columns.Add("country", "Страна проведения");
            dgvMainUser.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            //TimeSpan qwe;
            //string time = record.GetString(7);
            //qwe.ToString(out qwe);

            dgw.Rows.Add(record.GetValue(0).ToString(), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5), record.GetString(6));
        }

        private void RefreshDataGrid(DataGridView dgw, int id)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT RacesToDrivers.time_finish, race_id, Races.type, Races.title, Races.date, Location.city, Location.country
FROM[RacesToDrivers]
JOIN[Drivers]
ON RacesToDrivers.driver_id = Drivers.Id
JOIN[Races]
ON RacesToDrivers.race_id = Races.id_race
JOIN[Location]
ON Races.location_id = Location.Id
WHERE Drivers.Id = {id}"

, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void MainUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlCommand command = new SqlCommand($"DELETE FROM Session", dataBase.GetSqlConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            dataBase.closeConnection();
        }

        private void iconSeachMain_MouseEnter(object sender, EventArgs e)
        {
            iconSeachMain.BackColor = Color.FromArgb(154, 140, 152);
        }

        private void iconSeachMain_MouseLeave(object sender, EventArgs e)
        {
            iconSeachMain.BackColor = Color.FromArgb(201, 173, 167);
        }

        private void iconRefreshMain_MouseEnter(object sender, EventArgs e)
        {
            iconRefreshMain.BackColor = Color.FromArgb(154, 140, 152);
        }

        private void iconRefreshMain_MouseLeave(object sender, EventArgs e)
        {
            iconRefreshMain.BackColor = Color.FromArgb(201, 173, 167);
        }

        private void iconRefreshMain_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dgvMainUser, DriverNow());
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

        private void btnChangeAuth_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно уверены что хотите поменять данные для входа?", "Изменение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                var driver_id = DriverNow();
                var login_user = tbLogin.Text.ToString();
                var password_user = tbPassword.Text.ToString();

                var changeQuery = $"UPDATE Register set login_user = '{login_user}', password_user = '{password_user}' WHERE id_driver = '{driver_id}'";

                var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());

                dataBase.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные для регистрации изменены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Такой логин уже занят", "Смена логина", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataBase.closeConnection();
            }
            else if (dialogResult == DialogResult.No)
            {  
            }
        }

        private void Search(int id)
        {
            dgvMainUser.Rows.Clear();

            string search = $@" 
SELECT RacesToDrivers.time_finish, race_id, Races.type, Races.title, Races.date, Location.city, Location.country
FROM[RacesToDrivers]
JOIN[Drivers]
ON RacesToDrivers.driver_id = Drivers.Id
JOIN[Races]
ON RacesToDrivers.race_id = Races.id_race
JOIN[Location]
ON Races.location_id = Location.Id
WHERE Drivers.Id = {id} and CONCAT(RacesToDrivers.time_finish, race_id, Races.type, Races.title, Races.date, Location.city,  Location.country) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgvMainUser, read);
            }
            read.Close();
        }

        private void iconSeachMain_Click(object sender, EventArgs e)
        {
            Search(DriverNow());
        }
    }
}
