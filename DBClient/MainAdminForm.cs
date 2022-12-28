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
using System.Runtime;

namespace DBClient
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted,
    }
    public partial class MainAdminForm : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        public MainAdminForm()
        {
            InitializeComponent();
        }
        private void CreateColumsMain()
        {
            dgvMainAdmin.Columns.Add("id_driver", "ID Автогонщика");
            dgvMainAdmin.Columns.Add("name", "Имя");
            dgvMainAdmin.Columns.Add("surname", "Фамилия");
            dgvMainAdmin.Columns.Add("sex", "Пол");
            dgvMainAdmin.Columns.Add("classification", "Классификация");
            dgvMainAdmin.Columns.Add("id_race", "ID Автогонки");
            dgvMainAdmin.Columns.Add("type", "Тип гонки");
            dgvMainAdmin.Columns.Add("title", "Название гонки");
            dgvMainAdmin.Columns.Add("date", "Дата проведения");
            dgvMainAdmin.Columns.Add("time_finish", "Время финиша");
            dgvMainAdmin.Columns.Add("city", "Город проведения");
            dgvMainAdmin.Columns.Add("country", "Страна проведения");
            dgvMainAdmin.Columns.Add("id_location", "ID Локации");
            dgvMainAdmin.Columns.Add("id_raceToDriver", "ID Связи");
            dgvMainAdmin.Columns.Add(String.Empty, "IsNew");
            dgvMainAdmin.Columns["sex"].SortMode =
    DataGridViewColumnSortMode.NotSortable;
            dgvMainAdmin.Columns["classification"].SortMode =
    DataGridViewColumnSortMode.NotSortable;
            dgvMainAdmin.Columns["type"].SortMode =
    DataGridViewColumnSortMode.NotSortable;
            dgvMainAdmin.Columns[8].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvMainAdmin.Columns[14].Visible = false;
        }

        private void ClearTB()
        {
            cbIdDriverMain.Text = "";
            cbIdRaceMain.Text = "";
            tbTimeNewMain.Clear();
        }

        private void ClearTBLoc()
        {
            tbIdLocation.Text = "";
            cbCityLocation.Text = "";
            cbCountryLocation.Text = "";
        }

        private void ClearTBRace()
        {
            tbIdRaces.Text = "";
            cbTypeRaces.Text = "";
            tbTitleRaces.Text = "";
            dtpDateRaces.Text = "";
            cbIdLocation.Text = "";
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetInt32(5), record.GetString(6), record.GetString(7), record.GetDateTime(8), record.GetValue(9).ToString(), record.GetString(10), record.GetString(11), record.GetInt32(12), record.GetInt32(13),RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT Drivers.id, Drivers.name, Drivers.surname, Drivers.sex, Drivers.classification, race_id, Races.type, Races.title,  Races.date, RacesToDrivers.time_finish, Location.city, Location.country, location_id, RacesToDrivers.Id
FROM[RacesToDrivers]
JOIN[Drivers]
ON RacesToDrivers.driver_id = Drivers.Id
JOIN[Races]
ON RacesToDrivers.race_id = Races.id_race
JOIN[Location]
ON Races.location_id = Location.Id"
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

        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
            userInfoMain.Text = "Администратор";
            CreateColumsMain();
            RefreshDataGrid(dgvMainAdmin);
            writeComboBox("Id", "Drivers", cbIdRaceMain);
            writeComboBox("id_race", "Races", cbIdDriverMain);
            writeComboBox("classification", "Drivers", cbClassMain);
            writeComboBox("type", "Races", cbTypeMain);
            writeComboBox("country", "Location", cbCountryMain);
        }

        public void writeComboBox(string nameColum, string nameTable, ComboBox nameCb)
        {
            DataTable tad = new DataTable();
            string queryIdDriver = "SELECT DISTINCT " + nameColum + " from " + nameTable + " ORDER BY " + nameColum;
            SqlCommand commands = new SqlCommand(queryIdDriver, dataBase.GetSqlConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(commands);
            adapter.SelectCommand = commands;
            adapter.Fill(tad);


            for (int i = 0; i < tad.Rows.Count; i++)
            {
                nameCb.Items.Add(tad.Rows[i][nameColum]);
            }

            dataBase.closeConnection();
        }

        private void dgvMainAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvMainAdmin.Rows[selectedRow];

                    tbNameMain.Text = row.Cells[1].Value.ToString();
                    tbSurnameMain.Text = row.Cells[2].Value.ToString();
                    cbSexMain.Text = row.Cells[3].Value.ToString();
                    cbClassMain.Text = row.Cells[4].Value.ToString();
                    cbTypeMain.Text = row.Cells[6].Value.ToString();
                    tbTitleMain.Text = row.Cells[7].Value.ToString();
                    dtpDateMain.Value = DateTime.Parse(row.Cells[8].Value.ToString());
                    tbTimeMain.Text = row.Cells[9].Value.ToString();
                    cbCountryMain.Text = row.Cells[10].Value.ToString();
                    cbCityMain.Text = row.Cells[11].Value.ToString();
                    tbTimeNewMain.Text = row.Cells[9].Value.ToString();
                    cbIdDriverMain.Text = row.Cells[0].Value.ToString();
                    cbIdRaceMain.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnNewMain_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var timeNew = tbTimeNewMain.Text;
            var idDriver = cbIdDriverMain.Text;
            var idRace = cbIdRaceMain.Text;

            var addQuery = $@"
INSERT INTO RacesToDrivers(race_id, driver_id, time_finish) VALUES({idRace}, {idDriver}, '{timeNew}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице RacesToDrivers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTB();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Такая запись уже существует в RacesToDrivers или введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void cbCountryMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCityMain.Items.Clear();
            var country = cbCountryMain.Text;
            if(country == "Кот д'Ивуaр")
            {
                country = "Кот д''Ивуaр";
            }

            DataTable tad = new DataTable();
            string queryIdDriver = "SELECT DISTINCT city from Location WHERE country = N'" + country + "' ORDER BY city";
            SqlCommand commands = new SqlCommand(queryIdDriver, dataBase.GetSqlConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(commands);
            adapter.SelectCommand = commands;
            adapter.Fill(tad);


            for (int i = 0; i < tad.Rows.Count; i++)
            {
                cbCityMain.Items.Add(tad.Rows[i]["city"]);
            }

            dataBase.closeConnection();
        }

        private void Search(DataGridView dataGridView)
        {
            dgvMainAdmin.Rows.Clear();

            string search = $@" 
SELECT Drivers.name, Drivers.surname, Drivers.sex, Drivers.classification, Races.type, Races.title,  Races.date, RacesToDrivers.time_finish, Location.city, Location.country, Drivers.id, location_id, race_id, RacesToDrivers.Id
FROM[RacesToDrivers]
JOIN[Drivers]
ON RacesToDrivers.driver_id = Drivers.Id
JOIN[Races]
ON RacesToDrivers.race_id = Races.id_race
JOIN[Location]
ON Races.location_id = Location.Id
WHERE CONCAT(Drivers.name, Drivers. surname,Drivers.sex, Drivers.classification, Races.type, Races.title,  Races.date, RacesToDrivers.time_finish, Location.city, Location.country, Drivers.id, location_id, race_id, RacesToDrivers.Id) like N'%" + tbSearchMain.Text +"%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgvMainAdmin, read);
            }
            read.Close();
        }
        private void SearchLoc(DataGridView dataGridView)
        {
            dgvLocationMain.Rows.Clear();

            string search = $@" 
SELECT * FROM Location
WHERE CONCAT(Id, city, country) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowLocation(dgvLocationMain, read);
            }
            read.Close();
        }


        private void DeleteRow()
        {
            int index = dgvMainAdmin.CurrentCell.RowIndex;

            dgvMainAdmin.Rows[index].Visible = false;

            if (dgvMainAdmin.Rows[index].Cells[13].Value.ToString() == string.Empty)
            {
                dgvMainAdmin.Rows[index].Cells[14].Value = RowState.Deleted;
            }
            dgvMainAdmin.Rows[index].Cells[14].Value = RowState.Deleted;
        }

        private void UpdateBD()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvMainAdmin.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvMainAdmin.Rows[index].Cells[14].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvMainAdmin.Rows[index].Cells[13].Value);

                        var deleteQuery = $"DELETE FROM RacesToDrivers WHERE Id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvMainAdmin.Rows[index].Cells[13].Value.ToString();
                        var id_driver = dgvMainAdmin.Rows[index].Cells[0].Value.ToString();
                        var id_race = dgvMainAdmin.Rows[index].Cells[5].Value.ToString();
                        var time = dgvMainAdmin.Rows[index].Cells[9].Value.ToString();

                        var changeQuery = $"UPDATE RacesToDrivers set race_id = '{id_race}', driver_id = '{id_driver}', time_finish = '{time}' WHERE Id = '{id}'";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице RacesToDrivers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(SqlException ex) 
            {
                MessageBox.Show("Ошибка ввода", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataBase.closeConnection();
        }

        private void Change()
        {
            var selectedRowIndex = dgvMainAdmin.CurrentCell.RowIndex;

            var id_driver = cbIdDriverMain.Text;
            var id_race = cbIdRaceMain.Text;
            var time = tbTimeNewMain.Text;

            if(dgvMainAdmin.Rows[selectedRowIndex].Cells[13].Value.ToString() != string.Empty)
            {
                dgvMainAdmin.Rows[selectedRowIndex].Cells[0].Value = (id_driver);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[5].Value = (id_race);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[9].Value = (time);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[14].Value = RowState.Modified;
            }
            MessageBox.Show("Изменены записи в таблице RacesToDrivers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iconRefreshMain_Click(object sender, EventArgs e)
        {
            if (tcForAdmin.SelectedIndex == 0)
            {
                RefreshDataGrid(dgvMainAdmin);
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
                RefreshDataGridLocation(dgvLocationMain);
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                RefreshDataGridRace(dgvMainRaces);
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                RefreshDataGridDrivers(dgvMainDrivers);
            }
        }

        private void iconClearMain_MouseEnter(object sender, EventArgs e)
        {
            iconClearMain.BackColor = Color.FromArgb(154, 140, 152);
        }

        private void iconClearMain_MouseLeave(object sender, EventArgs e)
        {
            iconClearMain.BackColor = Color.FromArgb(201, 173, 167);
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

        private void iconSeachMain_Click(object sender, EventArgs e)
        {
            if (tcForAdmin.SelectedIndex == 0)
            {
                Search(dgvMainAdmin);
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
                SearchLoc(dgvLocationMain);
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                SearchRace(dgvMainRaces);
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                SearchDriver(dgvMainDrivers);
            }
        }

        private void SearchDriver(DataGridView dgvMainDriver)
        {
            dgvMainDriver.Rows.Clear();

            string search = $@" 
SELECT * FROM Drivers
WHERE CONCAT(Id, name, surname, classification, sex) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowDrivers(dgvMainDriver, read);
            }
            read.Close();
        }

        private void btnDeleteMain_Click(object sender, EventArgs e)
        {
            DeleteRow();
            ClearTB();
        }

        private void btnSaveMain_Click(object sender, EventArgs e)
        {
            UpdateBD();
        }

        private void btnUpdateMain_Click(object sender, EventArgs e)
        {
            Change();
            ClearTB();
        }

        private void MainAdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlCommand command = new SqlCommand($"DELETE FROM Session", dataBase.GetSqlConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            dataBase.closeConnection();
        }

        private void tcForAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcForAdmin.SelectedIndex == 0)
            {
                dgvMainAdmin.Rows.Clear();
                dgvMainAdmin.Columns.Clear();
                CreateColumsMain();
                RefreshDataGrid(dgvMainAdmin);
                writeComboBox("Id", "Drivers", cbIdDriverMain);
                writeComboBox("id_race", "Races", cbIdRaceMain);
                writeComboBox("classification", "Drivers", cbClassMain);
                writeComboBox("type", "Races", cbTypeMain);
                writeComboBox("country", "Location", cbCountryMain);
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
                dgvLocationMain.Rows.Clear();
                dgvLocationMain.Columns.Clear();
                CreateColumsLocation();
                RefreshDataGridLocation(dgvLocationMain);
                writeComboBox("country", "Location", cbCountryLocation);
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                dgvMainRaces.Rows.Clear();
                dgvMainRaces.Columns.Clear();
                CreateColumsRaces();
                RefreshDataGridRace(dgvMainRaces);
                writeComboBox("type", "Races", cbTypeRaces);
                writeComboBox("Id", "Location", cbIdLocation);
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                dgvMainDrivers.Rows.Clear();
                dgvMainDrivers.Columns.Clear();
                CreateColumsDrivers();
                RefreshDataGridDrivers(dgvMainDrivers);
                writeComboBox("classification", "Drivers", cbClassDriver);
            }
        }

        private void CreateColumsLocation()
        {
            dgvLocationMain.Columns.Add("id_location", "ID Локации");
            dgvLocationMain.Columns.Add("city", "Город");
            dgvLocationMain.Columns.Add("country", "Страна");
            dgvLocationMain.Columns.Add(String.Empty, "IsNew");
            dgvLocationMain.Columns[3].Visible = false;
        }

        private void CreateColumsRaces()
        {
            dgvMainRaces.Columns.Add("id_race", "ID Автогонки");
            dgvMainRaces.Columns.Add("title", "Название");
            dgvMainRaces.Columns.Add("location_id", "ID Локации");
            dgvMainRaces.Columns.Add("date", "Дата");
            dgvMainRaces.Columns.Add("type", "Тип");
            dgvMainRaces.Columns.Add(String.Empty, "IsNew");
            dgvMainRaces.Columns[5].Visible = false;
            dgvMainRaces.Columns[3].DefaultCellStyle.Format = "yyyy.MM.dd";
        }
        private void CreateColumsDrivers()
        {
            dgvMainDrivers.Columns.Add("id_driver", "ID Автогонщика");
            dgvMainDrivers.Columns.Add("name", "Имя");
            dgvMainDrivers.Columns.Add("surname", "Фамилия");
            dgvMainDrivers.Columns.Add("classification", "Классификация");
            dgvMainDrivers.Columns.Add("sex", "Пол");
            dgvMainDrivers.Columns.Add(String.Empty, "IsNew");
            dgvMainDrivers.Columns[5].Visible = false;
        }

        private void ReadSingleRowLocation(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }

        private void RefreshDataGridLocation(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT * FROM Location"
, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowLocation(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void ReadSingleRowRace(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetDateTime(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGridRace(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT * FROM Races"
, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowRace(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void dgvLocationMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLocationMain.Rows[selectedRow];

                tbIdLocation.Text = row.Cells[0].Value.ToString();
                cbCountryLocation.Text = row.Cells[2].Value.ToString();
                cbCityLocation.Text = row.Cells[1].Value.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var country = cbCountryLocation.Text;
            var city = cbCityLocation.Text;


            var addQuery = $@"
INSERT INTO Location(country, city) VALUES(N'{country}', N'{city}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Location", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Такая запись уже существует в Location или введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void iconClearMain_Click(object sender, EventArgs e)
        {
            if(tcForAdmin.SelectedIndex == 0)
            {
                ClearTB();
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
                ClearTBLoc();
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                ClearTBRace();
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                ClearTBDriver();
            }
        }

        private void ClearTBDriver()
        {
            tbIdDriver.Text = "";
            tbNameDriver.Text = "";
            tbSurnameDriver.Text = "";
            cbSexDriver.Text = "";
            lblClassDriver.Text = "";

            tbLogin.Text = "";
            tbPassword.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeLoc();
            ClearTB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteRowLoc();
            ClearTB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateBDLoc();
        }
        private void DeleteRowLoc()
        {
            int index = dgvLocationMain.CurrentCell.RowIndex;

            dgvLocationMain.Rows[index].Visible = false;

            if (dgvLocationMain.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvLocationMain.Rows[index].Cells[3].Value = RowState.Deleted;
            }
            dgvLocationMain.Rows[index].Cells[3].Value = RowState.Deleted;
        }

        private void UpdateBDLoc()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvLocationMain.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvLocationMain.Rows[index].Cells[3].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvLocationMain.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Location WHERE Id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvLocationMain.Rows[index].Cells[0].Value.ToString();
                        var city = dgvLocationMain.Rows[index].Cells[1].Value.ToString();
                        var country = dgvLocationMain.Rows[index].Cells[2].Value.ToString();


                        var changeQuery = $"UPDATE Location set city = N'{city}', country = N'{country}' WHERE Id = '{id}'";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Location", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка БД", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void ChangeLoc()
        {
            var selectedRowIndex = dgvLocationMain.CurrentCell.RowIndex;

            var city = cbCityLocation.Text;
            var country = cbCountryLocation.Text;

            if (dgvLocationMain.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvLocationMain.Rows[selectedRowIndex].Cells[1].Value = (city);
                dgvLocationMain.Rows[selectedRowIndex].Cells[2].Value = (country);
                dgvLocationMain.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
        }

        private void cbCountryLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCityLocation.Items.Clear();
            var country = cbCountryLocation.Text;
            if (country == "Кот д'Ивуaр")
            {
                country = "Кот д''Ивуaр";
            }

            DataTable tad = new DataTable();
            string queryIdDriver = "SELECT DISTINCT city from Location WHERE country = N'" + country + "' ORDER BY city";
            SqlCommand commands = new SqlCommand(queryIdDriver, dataBase.GetSqlConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(commands);
            adapter.SelectCommand = commands;
            adapter.Fill(tad);


            for (int i = 0; i < tad.Rows.Count; i++)
            {
                cbCityLocation.Items.Add(tad.Rows[i]["city"]);
            }

            dataBase.closeConnection();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateForm adminGen = new GenerateForm();

            this.Hide();
            adminGen.ShowDialog();
            this.Show();
        }

        private void dgvMainRaces_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMainRaces.Rows[selectedRow];

                tbIdRaces.Text = row.Cells[0].Value.ToString();
                tbTitleRaces.Text = row.Cells[1].Value.ToString();
                cbIdLocation.Text = row.Cells[2].Value.ToString();
                dtpDateRaces.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                cbTypeRaces.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnNewRace_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var title = tbTitleRaces.Text;
            var location_id = cbIdLocation.Text;
            var date = dtpDateRaces.Value.ToString("yyyy.MM.dd");
            var type = cbTypeRaces.Text;


            var addQuery = $"INSERT INTO Races(title, location_id, date, type) VALUES(N'{title}', {location_id}, '{date}', N'{type}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Races", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Такая запись уже существует в Races или введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void btnUpdadeRace_Click(object sender, EventArgs e)
        {
            ChangeRace();
            ClearTBRace();
        }

        private void btnDeleteRace_Click(object sender, EventArgs e)
        {
            DeleteRowRace();
            ClearTBRace();
        }

        private void btnSaveRace_Click(object sender, EventArgs e)
        {
            UpdateBDRace();
        }

        private void DeleteRowRace()
        {
            int index = dgvMainRaces.CurrentCell.RowIndex;

            dgvMainRaces.Rows[index].Visible = false;

            if (dgvMainRaces.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvMainRaces.Rows[index].Cells[5].Value = RowState.Deleted;
            }
            dgvMainRaces.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void ChangeRace()
        {
            var selectedRowIndex = dgvMainRaces.CurrentCell.RowIndex;

            var type = cbTypeRaces.Text;
            var location_id = cbIdLocation.Text;
            var date = dtpDateRaces.Value.ToString("yyyy.MM.dd");
            var title = tbTitleRaces.Text;

            if (dgvMainRaces.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvMainRaces.Rows[selectedRowIndex].Cells[1].Value = (title);
                dgvMainRaces.Rows[selectedRowIndex].Cells[2].Value = (location_id);
                dgvMainRaces.Rows[selectedRowIndex].Cells[3].Value = (date);
                dgvMainRaces.Rows[selectedRowIndex].Cells[4].Value = (type);
                dgvMainRaces.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }
        }

        private void UpdateBDRace()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvMainRaces.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvMainRaces.Rows[index].Cells[5].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvMainRaces.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Races WHERE id_race = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvMainRaces.Rows[index].Cells[0].Value.ToString();
                        var title = dgvMainRaces.Rows[index].Cells[1].Value.ToString();
                        var location_id = dgvMainRaces.Rows[index].Cells[2].Value.ToString();
                        var date = dgvMainRaces.Rows[index].Cells[3].Value.ToString();
                        var type = dgvMainRaces.Rows[index].Cells[4].Value.ToString();

                        var changeQuery = $"UPDATE Races set title = N'{title}', location_id = {location_id}, date = '{date}', type = N'{type}' WHERE id_race = {id}";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Races", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка БД", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
        private void SearchRace(DataGridView dataGridView)
        {
            dgvMainRaces.Rows.Clear();

            string search = $@" 
SELECT * FROM Races
WHERE CONCAT(id_race, title, location_id, date, type) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowRace(dgvMainRaces, read);
            }
            read.Close();
        }

        private void ReadSingleRowDrivers(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGridDrivers(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new("SELECT * FROM Drivers", dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowDrivers(dgvMainDrivers, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void dgvMainDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMainDrivers.Rows[selectedRow];

                tbIdDriver.Text = row.Cells[0].Value.ToString();
                tbNameDriver.Text = row.Cells[1].Value.ToString();
                tbSurnameDriver.Text = row.Cells[2].Value.ToString();
                cbClassDriver.Text = row.Cells[3].Value.ToString();
                cbSexDriver.Text = row.Cells[4].Value.ToString();

                var id = Int32.Parse(row.Cells[0].Value.ToString());
                WriteTbLog(id);
            }
        }

        private void WriteTbLog(int id)
        {
            dataBase.openConnection();
            string queryIdDriverLog = $"SELECT login_user, password_user FROM Register WHERE id_driver = {id}";
            SqlCommand command = new SqlCommand(queryIdDriverLog, dataBase.GetSqlConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tbLogin.Text = reader.GetString(0);
                tbPassword.Text = reader.GetString(1);
            }
            reader.Close();
            dataBase.closeConnection(); ;
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

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно уверены что хотите поменять данные для входа?", "Изменение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                var driver_id = tbIdDriver.Text;
                var login_user = tbLogin.Text.ToString();
                var password_user = tbPassword.Text.ToString();

                var changeQuery = $"UPDATE Register set login_user = '{login_user}', password_user = '{password_user}' WHERE id_driver = '{driver_id}'";

                var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());

                dataBase.openConnection();
                if (login_user != "" && password_user != "")
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Данные для регистрации изменены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Такой логин уже занят", "Смена логина", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля для авторизации", "Смена логина", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataBase.closeConnection();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void btnNewDriver_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var name = tbNameDriver.Text;
            var surname = tbSurnameDriver.Text;
            var classification = cbClassDriver.Text;
            var sex = cbSexDriver.Text;


            var addQuery = $"INSERT INTO Drivers (name, surname, classification, sex) VALUES(N'{name}', N'{surname}', N'{classification}', N'{sex}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Driver", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void btnUpdateDriver_Click(object sender, EventArgs e)
        {
            ChangeDriver();
            ClearTBDriver();
        }

        private void ChangeDriver()
        {
            var selectedRowIndex = dgvMainDrivers.CurrentCell.RowIndex;

            var name = tbNameDriver.Text;
            var surname = tbSurnameDriver.Text;
            var classificaion = cbClassDriver.Text;
            var sex = cbSexDriver.Text;

            if (dgvMainDrivers.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvMainDrivers.Rows[selectedRowIndex].Cells[1].Value = (name);
                dgvMainDrivers.Rows[selectedRowIndex].Cells[2].Value = (surname);
                dgvMainDrivers.Rows[selectedRowIndex].Cells[3].Value = (classificaion);
                dgvMainDrivers.Rows[selectedRowIndex].Cells[4].Value = (sex);
                dgvMainDrivers.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }
        }

        private void btnDeleteDriver_Click(object sender, EventArgs e)
        {
            DeleteRowDriver();
            ClearTBDriver();
        }

        private void DeleteRowDriver()
        {
            int index = dgvMainDrivers.CurrentCell.RowIndex;

            dgvMainDrivers.Rows[index].Visible = false;

            if (dgvMainDrivers.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvMainDrivers.Rows[index].Cells[5].Value = RowState.Deleted;
            }
            dgvMainDrivers.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void btnSaveDriver_Click(object sender, EventArgs e)
        {
            UpdateBDDriver();
        }

        private void UpdateBDDriver()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvMainDrivers.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvMainDrivers.Rows[index].Cells[5].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvMainDrivers.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Drivers WHERE Id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvMainDrivers.Rows[index].Cells[0].Value.ToString();
                        var name = dgvMainDrivers.Rows[index].Cells[1].Value.ToString();
                        var surname = dgvMainDrivers.Rows[index].Cells[2].Value.ToString();
                        var classification = dgvMainDrivers.Rows[index].Cells[3].Value.ToString();
                        var sex = dgvMainDrivers.Rows[index].Cells[4].Value.ToString();

                        var changeQuery = $"UPDATE Drivers set name = N'{name}', surname = N'{surname}', classification = N'{classification}', sex = N'{sex}' WHERE Id = {id}";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Drivers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка БД", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
    }
}
