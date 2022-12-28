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
    public partial class MainForm : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        public MainForm()
        {
            InitializeComponent();
        }
        private void CreateColumsMain()
        {
            dgvMainAdmin.Columns.Add("Id", "Id записи");
            dgvMainAdmin.Columns.Add("Id_reader", "Id читателя");
            dgvMainAdmin.Columns.Add("name", "Имя");
            dgvMainAdmin.Columns.Add("patronymic", "Отчество");
            dgvMainAdmin.Columns.Add("surname", "Фамилия");
            dgvMainAdmin.Columns.Add("Id_book", "Id книги");
            dgvMainAdmin.Columns.Add("book_title", "Название книги");
            dgvMainAdmin.Columns.Add("author", "Автор");
            dgvMainAdmin.Columns.Add("title", "Издатель");
            dgvMainAdmin.Columns.Add("date_get", "Дата выдачи");
            dgvMainAdmin.Columns.Add("date_back", "Дата возврата");
            dgvMainAdmin.Columns.Add(String.Empty, "IsNew");
            dgvMainAdmin.Columns[9].DefaultCellStyle.Format = "yyyy.MM.dd";
            dgvMainAdmin.Columns[10].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvMainAdmin.Columns[11].Visible = false;
        }

        private void ClearTB()
        {
            lblIdReg.Text = "";
            cdIdReader.Text = "";
            cdIdBook.Text = "";
            dtpGet.Text = "";
            dtpBack.Text = "";
        }

        private void ClearTBBook()
        {
            lblBook.Text = "";
            tbTitleBook.Text = "";
            cbAuthorBook.Text = "";
            cbYearBook.Text = "";
            tbQuantity.Text = "";
            cbGenreBook.Text = "";
            cbPublisherBook.Text = "";

        }

        private void ClearTBReader()
        {
            lblIdReader.Text = "";
            tbSurnameReader.Text = "";
            tbNameReader.Text = "";
            tbPatronymicReader.Text = "";
            tbAddressReader.Text = "";
            tbEmailReader.Text = "";
            tbPassReader.Text = "";
            mtbPhoneReader.Text = "";
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetInt32(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetDateTime(9), record.GetDateTime(10), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT Register.Id, Readers.reader_id, name, Readers.patronymic, Readers.surname, Books.book_id, Books.title, Books.author, Publishers.title, Register.date_get, Register.date_back
FROM[Register]
JOIN[Readers]
ON Readers.reader_id = Register.reader_id
JOIN[Books]
ON Books.book_id = Register.book_id
JOIN[Publishers]
ON Books.publisher_id = Publishers.publisher_id"
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
            CreateColumsMain();
            RefreshDataGrid(dgvMainAdmin);
            writeComboBox("reader_id", "Readers", cdIdReader);
            writeComboBox("book_id", "Books", cdIdBook);
        }

        public void writeComboBox(string nameColum, string nameTable, ComboBox nameCb)
        {
            nameCb.Items.Clear();
            DataTable tad = new DataTable();
            string query = "SELECT DISTINCT " + nameColum + " from " + nameTable + " ORDER BY " + nameColum;
            SqlCommand commands = new SqlCommand(query, dataBase.GetSqlConnection());
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

                lblIdReg.Text = row.Cells[0].Value.ToString();
                cdIdReader.Text = row.Cells[1].Value.ToString();
                cdIdBook.Text = row.Cells[5].Value.ToString();
                dtpGet.Value = DateTime.Parse(row.Cells[9].Value.ToString());
                dtpBack.Value = DateTime.Parse(row.Cells[10].Value.ToString());
            }
        }

        private void btnNewMain_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var id_reader = cdIdReader.Text.Trim();
            var id_book = cdIdBook.Text.Trim();
            var data_get = dtpGet.Value.ToString("yyyy.MM.dd"); ;
            var date_back = dtpBack.Value.ToString("yyyy.MM.dd"); ;

            var addQuery = $@"
INSERT INTO Register(reader_id, book_id, date_get, date_back) VALUES({id_reader}, {id_book}, '{data_get}', '{date_back}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Register", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTB();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search(DataGridView dataGridView)
        {
            dgvMainAdmin.Rows.Clear();

            string search = $@"
SELECT Register.Id, Readers.reader_id, name, Readers.patronymic, Readers.surname, Books.book_id, Books.title, Books.author, Publishers.title, Register.date_get, Register.date_back
FROM[Register]
JOIN[Readers]
ON Readers.reader_id = Register.reader_id
JOIN[Books]
ON Books.book_id = Register.book_id
JOIN[Publishers]
ON Books.publisher_id = Publishers.publisher_id
WHERE CONCAT(Register.Id, Readers.reader_id, name, Readers.patronymic, Readers.surname, Books.book_id, Books.title, Books.author, Publishers.title, Register.date_get, Register.date_back) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgvMainAdmin, read);
            }
            read.Close();
        }
        private void SearchBook(DataGridView dataGridView)
        {
            dgvBookMain.Rows.Clear();

            string search = $@" 
SELECT * FROM Books
WHERE CONCAT(book_id, title, author, publisher_id, year_of_publishing, quantity, genre) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowBook(dgvBookMain, read);
            }
            read.Close();
        }


        private void DeleteRow()
        {
            int index = dgvMainAdmin.CurrentCell.RowIndex;

            dgvMainAdmin.Rows[index].Visible = false;

            if (dgvMainAdmin.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvMainAdmin.Rows[index].Cells[11].Value = RowState.Deleted;
            }
            dgvMainAdmin.Rows[index].Cells[11].Value = RowState.Deleted;
        }

        private void UpdateBD()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvMainAdmin.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvMainAdmin.Rows[index].Cells[11].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvMainAdmin.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Register WHERE Id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvMainAdmin.Rows[index].Cells[0].Value.ToString();
                        var id_reader = dgvMainAdmin.Rows[index].Cells[1].Value.ToString();
                        var id_book = dgvMainAdmin.Rows[index].Cells[5].Value.ToString();
                        var data_get = dgvMainAdmin.Rows[index].Cells[9].Value.ToString();
                        var date_back = dgvMainAdmin.Rows[index].Cells[10].Value.ToString();


                        var changeQuery = $"UPDATE Register set reader_id = {id_reader}, book_id = {id_book}, date_get = '{data_get}', date_back = '{date_back}' WHERE Id = '{id}'";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Register", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(SqlException ex) 
            {
                MessageBox.Show("Ошибка ввода", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataBase.closeConnection();
        }

        private void Change()
        {
            var selectedRowIndex = dgvMainAdmin.CurrentCell.RowIndex;

            var id_reader = cdIdReader.Text.Trim();
            var id_book = cdIdBook.Text.Trim();
            var data_get = dtpGet.Value.ToString("yyyy.MM.dd");
            var date_back = dtpBack.Value.ToString("yyyy.MM.dd");

            if (dgvMainAdmin.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvMainAdmin.Rows[selectedRowIndex].Cells[1].Value = (id_reader);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[5].Value = (id_book);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[9].Value = (data_get);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[10].Value = (date_back);
                dgvMainAdmin.Rows[selectedRowIndex].Cells[11].Value = RowState.Modified;
            }
            MessageBox.Show("Изменены записи в таблице Register", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iconRefreshMain_Click(object sender, EventArgs e)
        {
            if (tcForAdmin.SelectedIndex == 0)
            {
                RefreshDataGrid(dgvMainAdmin);
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
                RefreshDataGridBooks(dgvBookMain);
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                RefreshDataGridReaders(dgvMainReaders);
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                RefreshDataGridPublishers(dgvMainPub);
            }
        }

        private void iconSeachMain_Click(object sender, EventArgs e)
        {
            if (tcForAdmin.SelectedIndex == 0)
            {
                Search(dgvMainAdmin);
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
               SearchBook(dgvBookMain);
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                SearchReader(dgvMainReaders);
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                SearchPublisher(dgvMainPub);
            }
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

        private void tcForAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcForAdmin.SelectedIndex == 0)
            {
                dgvMainAdmin.Rows.Clear();
                dgvMainAdmin.Columns.Clear();
                CreateColumsMain();
                RefreshDataGrid(dgvMainAdmin);
                writeComboBox("reader_id", "Readers", cdIdReader);
                writeComboBox("book_id", "Books", cdIdBook);
            }
            if (tcForAdmin.SelectedIndex == 1)
            {
                dgvBookMain.Rows.Clear();
                dgvBookMain.Columns.Clear();
                CreateColumsBooks();
                RefreshDataGridBooks(dgvBookMain);
                writeComboBox("author", "Books", cbAuthorBook);
                writeComboBox("year_of_publishing", "Books", cbYearBook);
                writeComboBox("genre", "Books", cbGenreBook);
                writeComboBox("publisher_id", "Books", cbPublisherBook);
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                dgvMainReaders.Rows.Clear();
                dgvMainReaders.Columns.Clear();
                CreateColumsReaders();
                RefreshDataGridReaders(dgvMainReaders);
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                dgvMainPub.Rows.Clear();
                dgvMainPub.Columns.Clear();
                CreateColumsPublishers();
                RefreshDataGridPublishers(dgvMainPub);
            }
        }

        private void CreateColumsBooks()
        {
            dgvBookMain.Columns.Add("book_id", "ID книги");
            dgvBookMain.Columns.Add("title", "Название");
            dgvBookMain.Columns.Add("author", "Автор");
            dgvBookMain.Columns.Add("publisher_id", "ID издателя");
            dgvBookMain.Columns.Add("year_of_publishing", "Год издания");
            dgvBookMain.Columns.Add("quantity", "Кол-во стр.");
            dgvBookMain.Columns.Add("genre", "Жанр");
            dgvBookMain.Columns.Add(String.Empty, "IsNew");
            dgvBookMain.Columns[7].Visible = false;
        }

        private void CreateColumsReaders()
        {
            dgvMainReaders.Columns.Add("reader_id", "ID Автогонки");
            dgvMainReaders.Columns.Add("surname", "Фамилия");
            dgvMainReaders.Columns.Add("name", "Имя");
            dgvMainReaders.Columns.Add("patronymic", "Отчество");
            dgvMainReaders.Columns.Add("password", "Пароль");
            dgvMainReaders.Columns.Add("email", "Эл. почта");
            dgvMainReaders.Columns.Add("address", "Адрес проживания");
            dgvMainReaders.Columns.Add("phone", "Номер телефона");
            dgvMainReaders.Columns.Add(String.Empty, "IsNew");
            dgvMainReaders.Columns[8].Visible = false;
        }
        private void CreateColumsPublishers()
        {
            dgvMainPub.Columns.Add("publisher_id", "ID издателя");
            dgvMainPub.Columns.Add("title", "Название");
            dgvMainPub.Columns.Add("city", "Город");
            dgvMainPub.Columns.Add(String.Empty, "IsNew");
            dgvMainPub.Columns[3].Visible = false;
        }

        private void ReadSingleRowBook(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), record.GetString(6), RowState.ModifiedNew);
        }

        private void RefreshDataGridBooks(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT * FROM Books"
, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowBook(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void ReadSingleRowReader(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), RowState.ModifiedNew);
        }

        private void RefreshDataGridReaders(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new($@"
SELECT * FROM Readers"
, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowReader(dgw, reader);
            }
            reader.Close();
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
                ClearTBBook();
            }
            if (tcForAdmin.SelectedIndex == 2)
            {
                ClearTBReader();
            }
            if (tcForAdmin.SelectedIndex == 3)
            {
                ClearTBPublishers();
            }
        }

        private void ClearTBPublishers()
        {
            lblPublisher.Text = "";
            tbTitlePub.Text = "";
            tbCityPub.Text = "";
        }

        private void DeleteRowBook()
        {
            int index = dgvBookMain.CurrentCell.RowIndex;

            dgvBookMain.Rows[index].Visible = false;

            if (dgvBookMain.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvBookMain.Rows[index].Cells[3].Value = RowState.Deleted;
            }
            dgvBookMain.Rows[index].Cells[3].Value = RowState.Deleted;
        }

        private void UpdateBDBook()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvBookMain.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvBookMain.Rows[index].Cells[7].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvBookMain.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Books WHERE Id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvBookMain.Rows[index].Cells[0].Value.ToString();
                        var title = dgvBookMain.Rows[index].Cells[1].Value.ToString();
                        var author = dgvBookMain.Rows[index].Cells[2].Value.ToString();
                        var publisher_id = dgvBookMain.Rows[index].Cells[3].Value.ToString();
                        var year_of_publishing = dgvBookMain.Rows[index].Cells[4].Value.ToString();
                        var quantity = dgvBookMain.Rows[index].Cells[5].Value.ToString();
                        var genre = dgvBookMain.Rows[index].Cells[6].Value.ToString();


                        var changeQuery = $"UPDATE Books set title = '{title}', author = '{author}', publisher_id = {publisher_id}, year_of_publishing = {year_of_publishing}, quantity = {quantity}, genre = '{genre}' WHERE book_id = '{id}'";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Books", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка БД", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void ChangeBook()
        {
            var selectedRowIndex = dgvBookMain.CurrentCell.RowIndex;

            var title = tbTitleBook.Text;
            var author = cbAuthorBook.Text.Trim();
            var year_of_publishing = cbYearBook.Text.Trim();
            var quantity = tbQuantity.Text;
            var genre = cbGenreBook.Text.Trim();
            var publisher_id = cbPublisherBook.Text.Trim();

            if (dgvBookMain.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvBookMain.Rows[selectedRowIndex].Cells[1].Value = (title);
                dgvBookMain.Rows[selectedRowIndex].Cells[2].Value = (author);
                dgvBookMain.Rows[selectedRowIndex].Cells[4].Value = (year_of_publishing);
                dgvBookMain.Rows[selectedRowIndex].Cells[5].Value = (quantity);
                dgvBookMain.Rows[selectedRowIndex].Cells[6].Value = (genre);
                dgvBookMain.Rows[selectedRowIndex].Cells[3].Value = (publisher_id);
                dgvBookMain.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
            }
        }
        

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();

            this.Hide();
            queryForm.ShowDialog();
            this.Show();
        }

        private void DeleteRowReader()
        {
            int index = dgvMainReaders.CurrentCell.RowIndex;

            dgvMainReaders.Rows[index].Visible = false;

            if (dgvMainReaders.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvMainReaders.Rows[index].Cells[8].Value = RowState.Deleted;
            }
            dgvMainReaders.Rows[index].Cells[8].Value = RowState.Deleted;
        }

        private void ChangeReader()
        {
            var selectedRowIndex = dgvMainReaders.CurrentCell.RowIndex;

            var surname = tbSurnameReader.Text;
            var name = tbNameReader.Text;
            var patronymic = tbPatronymicReader.Text;
            var password = tbPassReader.Text;
            var email = tbEmailReader.Text;
            var address = tbAddressReader.Text;
            var phone = mtbPhoneReader.Text;

            if (dgvMainReaders.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvMainReaders.Rows[selectedRowIndex].Cells[1].Value = (surname);
                dgvMainReaders.Rows[selectedRowIndex].Cells[2].Value = (name);
                dgvMainReaders.Rows[selectedRowIndex].Cells[3].Value = (patronymic);
                dgvMainReaders.Rows[selectedRowIndex].Cells[4].Value = (password);
                dgvMainReaders.Rows[selectedRowIndex].Cells[5].Value = (email);
                dgvMainReaders.Rows[selectedRowIndex].Cells[6].Value = (address);
                dgvMainReaders.Rows[selectedRowIndex].Cells[7].Value = (phone);
                dgvMainReaders.Rows[selectedRowIndex].Cells[8].Value = RowState.Modified;
            }
        }

        private void UpdateBDReaders()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvMainReaders.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvMainReaders.Rows[index].Cells[8].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvMainReaders.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Readers WHERE reader_id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvMainReaders.Rows[index].Cells[0].Value.ToString();
                        var surname = dgvMainReaders.Rows[index].Cells[1].Value.ToString();
                        var name = dgvMainReaders.Rows[index].Cells[2].Value.ToString();
                        var patronymic = dgvMainReaders.Rows[index].Cells[3].Value.ToString();
                        var password = dgvMainReaders.Rows[index].Cells[4].Value.ToString();
                        var email = dgvMainReaders.Rows[index].Cells[5].Value.ToString();
                        var address = dgvMainReaders.Rows[index].Cells[6].Value.ToString();
                        var phone = dgvMainReaders.Rows[index].Cells[7].Value.ToString();

                        var changeQuery = $"UPDATE Readers set surname = '{surname}', name = '{name}', patronymic = '{patronymic}', password = '{password}', email = '{email}', address = '{address}', phone = '{phone}' WHERE reader_id = {id}";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Readers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка БД", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
        private void SearchReader(DataGridView dataGridView)
        {
            dgvMainReaders.Rows.Clear();

            string search = $@" 
SELECT * FROM Readers
WHERE CONCAT(reader_id, surname, name, password, email, address, phone) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowReader(dgvMainReaders, read);
            }
            read.Close();
        }

        private void ReadSingleRowPublishers(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }

        private void RefreshDataGridPublishers(DataGridView dgw)
        {
            dgw.Rows.Clear();

            SqlCommand command = new("SELECT * FROM Publishers", dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowPublishers(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }
        private void SearchPublisher(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            string search = $@" 
SELECT * FROM Publishers
WHERE CONCAT(publisher_id, title, city) like N'%" + tbSearchMain.Text + "%'";

            SqlCommand command = new SqlCommand(search, dataBase.GetSqlConnection());

            dataBase.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowPublishers(dataGridView, read);
            }
            read.Close();
        }

        private void ChangePublisher()
        {
            var selectedRowIndex = dgvMainPub.CurrentCell.RowIndex;

            var title = tbTitlePub.Text;
            var city = tbCityPub.Text;

            if (dgvMainPub.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgvMainPub.Rows[selectedRowIndex].Cells[1].Value = (title);
                dgvMainPub.Rows[selectedRowIndex].Cells[2].Value = (city);
                dgvMainPub.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
        }

        private void DeleteRowPublisher()
        {
            int index = dgvMainPub.CurrentCell.RowIndex;

            dgvMainPub.Rows[index].Visible = false;

            if (dgvMainPub.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgvMainPub.Rows[index].Cells[3].Value = RowState.Deleted;
            }
            dgvMainPub.Rows[index].Cells[3].Value = RowState.Deleted;
        }

        private void UpdateBDPublishers()
        {
            dataBase.openConnection();

            try
            {
                for (int index = 0; index < dgvMainPub.Rows.Count; index++)
                {
                    var rowState = (RowState)dgvMainPub.Rows[index].Cells[3].Value;

                    if (rowState == RowState.Existed)
                        continue;
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dgvMainPub.Rows[index].Cells[0].Value);

                        var deleteQuery = $"DELETE FROM Publishers WHERE publisher_id = {id}";

                        var command = new SqlCommand(deleteQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var id = dgvMainPub.Rows[index].Cells[0].Value.ToString();
                        var title = dgvMainPub.Rows[index].Cells[1].Value.ToString();
                        var city = dgvMainPub.Rows[index].Cells[2].Value.ToString();

                        var changeQuery = $"UPDATE Publishers set title = '{title}', city = '{city}' WHERE publisher_id = {id}";

                        var command = new SqlCommand(changeQuery, dataBase.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Изменения внесены в таблице Publishers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка БД", "Изменение бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void dgvBookMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookMain.Rows[selectedRow];

                lblBook.Text = row.Cells[0].Value.ToString();
                tbTitleBook.Text = row.Cells[1].Value.ToString();
                cbAuthorBook.Text = row.Cells[2].Value.ToString();
                cbPublisherBook.Text = row.Cells[3].Value.ToString();
                cbYearBook.Text = row.Cells[4].Value.ToString();
                tbQuantity.Text = row.Cells[5].Value.ToString();
                cbGenreBook.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var title = tbTitleBook.Text;
            var author = cbAuthorBook.Text.Trim();
            var year_of_publishing = cbYearBook.Text.Trim();
            var quantity = tbQuantity.Text;
            var genre = cbGenreBook.Text.Trim();
            var publisher_id = cbPublisherBook.Text.Trim();

            var addQuery = $"INSERT INTO Books(title, author, year_of_publishing, quantity, genre, publisher_id) VALUES(N'{title}', '{author}', {year_of_publishing}, {quantity}, '{genre}', {publisher_id})";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Books", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            ChangeBook();
            ClearTBBook();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            DeleteRowBook();
            ClearTBBook();
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            UpdateBDBook();
        }

        private void dgvMainReader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMainReaders.Rows[selectedRow];

                lblIdReader.Text = row.Cells[0].Value.ToString();
                tbSurnameReader.Text = row.Cells[1].Value.ToString();
                tbNameReader.Text = row.Cells[2].Value.ToString();
                tbPatronymicReader.Text = row.Cells[3].Value.ToString();
                tbAddressReader.Text = row.Cells[6].Value.ToString();
                mtbPhoneReader.Text = row.Cells[7].Value.ToString();
                tbEmailReader.Text = row.Cells[5].Value.ToString();
                tbPassReader.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnNewReader_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var surname = tbSurnameReader.Text;
            var name = tbNameReader.Text;
            var patronymic = tbPatronymicReader.Text;
            var password = tbPassReader.Text;
            var email = tbEmailReader.Text;
            var address = tbAddressReader.Text;
            var phone = mtbPhoneReader.Text;

            var addQuery = $"INSERT INTO Readers(surname, name, patronymic, password, email, address, phone) VALUES('{surname}', '{name}', '{patronymic}', '{password}', '{email}', '{address}', '{phone}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Readers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void btnUpdateReader_Click(object sender, EventArgs e)
        {
            ChangeReader();
            ClearTBReader();
        }

        private void btnDeleteReader_Click(object sender, EventArgs e)
        {
            DeleteRowReader();
            ClearTBReader();
        }

        private void btnSaveReader_Click(object sender, EventArgs e)
        {
            UpdateBDReaders();
        }

        private void dgvMainPub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMainPub.Rows[selectedRow];

                lblPublisher.Text = row.Cells[0].Value.ToString();
                tbTitlePub.Text = row.Cells[1].Value.ToString();
                tbCityPub.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnNewPub_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var title = tbTitlePub.Text;
            var city = tbCityPub.Text;

            var addQuery = $"INSERT INTO Publishers (title, city) VALUES('{title}', '{city}')";

            var command = new SqlCommand(addQuery, dataBase.GetSqlConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Создана запись в таблице Publishers", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Введены неверные данные", "Создание записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void btnUpdatePub_Click(object sender, EventArgs e)
        {
            ChangePublisher();
            ClearTBPublishers();
        }

        private void btnDeletePub_Click(object sender, EventArgs e)
        {
            DeleteRowPublisher();
            ClearTBPublishers();
        }

        private void btnSavePub_Click(object sender, EventArgs e)
        {
            UpdateBDPublishers();
        }
    }
}
