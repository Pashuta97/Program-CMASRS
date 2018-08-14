using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Program_CMASRS.Model;
using System.Data.SqlClient;

namespace Program_CMASRS
{
    public partial class Form1 : Form
    {
        private BindingSource _bindingSourceElements = new BindingSource();
        private BindingSource _bindingSourceItems = new BindingSource();
        private BindingSource _bindingSourceCriteria = new BindingSource();

        private SqlDataAdapter _dataAdapterElements = new SqlDataAdapter();
        private SqlDataAdapter _dataAdapterItems = new SqlDataAdapter();
        private SqlDataAdapter _dataAdapterCriteria = new SqlDataAdapter();

        //private String _connectionString =
        //            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pashu\\OneDrive\\Навчання\\Диплом\\Program CMASRS\\Program CMASRS\\Design.mdf;Integrated Security=True;Connect Timeout=30";
        private String _connectionString =
                    "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Design.mdf;Integrated Security=True;Connect Timeout=30";

        private Design _design = new Design("Class room");

        DataTable _tableItem = new DataTable();

        private int _checkPrint;

        public Form1()
        {
            InitializeComponent();

            _dataGridViewElements.DataSource = _bindingSourceElements;
            _dataGridViewItems.DataSource = _bindingSourceItems;
            _dataGridViewCriteria.DataSource = _bindingSourceCriteria;
            this.Text = "CMASRS" + " " + _design.Name;

            _submitButton.Click += new EventHandler(_reloadButton_Click);

            _saveAsToolStripMenuItem.Click += new EventHandler(_findRelevantButton_Click);
            _saveAsToolStripMenuItem.Click += new EventHandler(_saveAsToolStripMenuItem_Click);

            this._printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this._printDocument_BeginPrint);
            this._printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this._printDocument_PrintPage);
            this._printToolStripMenuItem.Click += new System.EventHandler(this._printToolStripMenuItem_Click);

            try
            {
                _tableItem = GetTable("select * from Item", ref _dataAdapterItems);

                FillComboBox();
                FillDataFromDB();
                FillDataGridViewElements();
                FillDataGridViewItems();
                FillDataGridViewCriteria();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FillDataGridViewCriteria()
        {
            GetData("select * from " + _comboBox1.SelectedItem + " where Id < 2", _bindingSourceCriteria, ref _dataAdapterCriteria, _dataGridViewCriteria);
            _dataGridViewCriteria.Columns[0].ReadOnly = true;
            _dataGridViewCriteria.Columns[1].ReadOnly = true;
            _dataGridViewCriteria.Columns[0].Visible = false;
            _dataGridViewCriteria.AllowUserToAddRows = false;
            _dataGridViewCriteria.AllowUserToDeleteRows = false;
            
        }

        private void FillDataGridViewItems()
        {
            GetData("select * from Item", _bindingSourceItems, ref _dataAdapterItems, _dataGridViewItems);
            _dataGridViewItems.Columns[0].ReadOnly = true;
            _dataGridViewItems.Columns[0].Visible = false;
            _dataGridViewItems.Columns[1].ReadOnly = true;
            _dataGridViewItems.AllowUserToAddRows = false;
            _dataGridViewItems.AllowUserToDeleteRows = false;
        }

        private void FillDataGridViewElements()
        {
            GetData("select * from " + _comboBox1.SelectedItem + " where Id > 1", _bindingSourceElements, ref _dataAdapterElements, _dataGridViewElements);
            _dataGridViewElements.Columns[0].ReadOnly = true;
            _dataGridViewElements.Columns[0].Visible = false;
           
        }

        private void FillComboBox()
        {
            for (int countRowItem = 0; countRowItem < _tableItem.Rows.Count; countRowItem++)
            {
                _comboBox1.Items.Add(_tableItem.Rows[countRowItem][1].ToString());
            }
            _comboBox1.SelectedIndexChanged += new EventHandler(_comboBox1_SelectedIndexChanged);
            _comboBox1.SelectedIndex = 0;
        }

        private void FillDataFromDB()
        {
            for (int countRowItem = 0; countRowItem < _tableItem.Rows.Count; countRowItem++)
            {
                _design.Items.Add(new Item());
                FillDataFromTable(countRowItem);
            }
        }

        private void FillDataFromTable(int countRowItem)
        {
            DataTable _table = GetTable("select * from " + _tableItem.Rows[countRowItem][1].ToString(), ref _dataAdapterElements);

            //створюєм новий предмет з іменем i кількістю
            _design.Items[countRowItem].Name = _tableItem.Rows[countRowItem][1].ToString();
            _design.Items[countRowItem].Count = Int16.Parse(_tableItem.Rows[countRowItem][2].ToString());

            //задаємо критерії та їх важливість
            _design.Items[countRowItem].Criteria.Name = _table.Rows[0][1].ToString();
            _design.Items[countRowItem].Criteria.Price = Double.Parse(_table.Rows[0][2].ToString());

            _design.Items[countRowItem].ImportantCriteria.Name = _table.Rows[1][1].ToString();
            _design.Items[countRowItem].ImportantCriteria.Price = Double.Parse(_table.Rows[1][2].ToString());

            _design.Items[countRowItem].Criteria.Characteristics = new List<double>();
            _design.Items[countRowItem].ImportantCriteria.Characteristics = new List<double>();
            _design.Items[countRowItem].NameCriteria = new List<string>();
            for (int countColumn = 3; countColumn < _table.Columns.Count; countColumn++)
            {
                _design.Items[countRowItem].NameCriteria.Add(_table.Columns[countColumn].ColumnName);
                _design.Items[countRowItem].Criteria.Characteristics.Add(Double.Parse(_table.Rows[0][countColumn].ToString()));
                _design.Items[countRowItem].ImportantCriteria.Characteristics.Add(Double.Parse(_table.Rows[1][countColumn].ToString()));
            }

            // заповнюємо предмет елементами колонки 1 - ім'я, колонка 2 - ціна, інші колонки - інші характеристики
            _design.Items[countRowItem].Elements = new List<Element>();
            for (int countRow = 2; countRow < _table.Rows.Count; countRow++)
            {
                DataRow _row = _table.Rows[countRow];
                _design.Items[countRowItem].Elements.Add(new Element());
                _design.Items[countRowItem].Elements[countRow - 2].Name = _table.Rows[countRow][1].ToString();
                _design.Items[countRowItem].Elements[countRow - 2].Price = Double.Parse(_table.Rows[countRow][2].ToString());

                _design.Items[countRowItem].Elements[countRow - 2].Characteristics = new List<double>();
                for (int countColumn = 3; countColumn < _table.Columns.Count; countColumn++)
                {
                    _design.Items[countRowItem].Elements[countRow - 2].Characteristics.Add(Double.Parse(_table.Rows[countRow][countColumn].ToString()));
                }
            }
        }

        private void GetData(string _selectCommand, BindingSource _bindingSource, ref SqlDataAdapter _dataAdapter, DataGridView _dataGridView)
        {
            try
            {
                _bindingSource.DataSource = GetTable(_selectCommand, ref _dataAdapter);
            }
            catch (SqlException)
            {
                MessageBox.Show("Get Data exception");
            }
        }

        private DataTable GetTable(string _selectCommand, ref SqlDataAdapter _dataAdapter)
        {
            DataTable _table = new DataTable();
            try
            {
                _dataAdapter = new SqlDataAdapter(_selectCommand, _connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapter);

                _table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                _dataAdapter.Fill(_table);
            }
            catch (SqlException)
            {
                MessageBox.Show("Get Table exception");
            }
            return _table;
        }

        private void _comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData("select * from " + _comboBox1.SelectedItem + " where Id > 1", _bindingSourceElements, ref _dataAdapterElements, _dataGridViewElements);
            GetData("select * from " + _comboBox1.SelectedItem + " where Id < 2", _bindingSourceCriteria, ref _dataAdapterCriteria, _dataGridViewCriteria);
        }

        private void _reloadButton_Click(object sender, EventArgs e)
        {
            GetData(_dataAdapterElements.SelectCommand.CommandText, _bindingSourceElements, ref _dataAdapterElements, _dataGridViewElements);
            GetData(_dataAdapterItems.SelectCommand.CommandText, _bindingSourceItems, ref _dataAdapterItems, _dataGridViewItems);
            GetData(_dataAdapterCriteria.SelectCommand.CommandText, _bindingSourceCriteria, ref _dataAdapterCriteria, _dataGridViewCriteria);
        }

        private void _submitButton_Click(object sender, EventArgs e)
        {
            _dataAdapterElements.Update((DataTable)_bindingSourceElements.DataSource);
            _dataAdapterItems.Update((DataTable)_bindingSourceItems.DataSource);
            _dataAdapterCriteria.Update((DataTable)_bindingSourceCriteria.DataSource);

            _tableItem = GetTable("select * from Item", ref _dataAdapterItems);

            for (int countRowItem = 0; countRowItem < _tableItem.Rows.Count; countRowItem++)
            {
                _design.Items[countRowItem].Count = Int16.Parse(_tableItem.Rows[countRowItem][2].ToString());
            }
            FillDataFromTable(_comboBox1.SelectedIndex);
            GetData("select * from " + _comboBox1.SelectedItem + " where Id > 1", _bindingSourceElements, ref _dataAdapterElements, _dataGridViewElements);
        }

        private void _findRelevantButton_Click(object sender, EventArgs e)
        {
            _design.FindRelevant();

            _richTextBox.Text = "";
            _richTextBox.Font = new Font("Arial", 10, FontStyle.Italic);

            _richTextBox.SelectionFont = new Font("Arial", 10, FontStyle.Bold | FontStyle.Italic);
            _richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            _richTextBox.AppendText("Optimal variant of items for " + _design.Name + "\r\n");
            
            _richTextBox.SelectionAlignment = HorizontalAlignment.Left;
            for (int countRowItem = 0; countRowItem < _tableItem.Rows.Count; countRowItem++)
            {
                _richTextBox.AppendText((countRowItem + 1).ToString() + "). " + _design.Items[countRowItem].Name + " " +
                    _design.Items[countRowItem].Elements[_design.Items[countRowItem].DeviationItemIndex].Name +
                    "\r\n\tPrice for " + _tableItem.Rows[countRowItem][2].ToString() + " pc. = ");
                _richTextBox.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
                _richTextBox.AppendText(_design.Items[countRowItem].Price().ToString());

                
                for (int countCharacteristics = 0; countCharacteristics < _design.Items[countRowItem].NameCriteria.Count; countCharacteristics++)
                {
                    _richTextBox.SelectionFont = _richTextBox.Font;
                    _richTextBox.AppendText("\r\n\t" + _design.Items[countRowItem].NameCriteria[countCharacteristics] + ": ");
                    _richTextBox.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
                    _richTextBox.AppendText(_design.Items[countRowItem].Elements[_design.Items[countRowItem].DeviationItemIndex].Characteristics[countCharacteristics].ToString());
                }

                _richTextBox.AppendText("\r\n");
            }

            _richTextBox.SelectionFont = new Font("Arial", 10, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            _richTextBox.SelectionAlignment = HorizontalAlignment.Right;
            _richTextBox.AppendText("Total price = " + _design.Price().ToString());
        }

        private void _saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog _saveFile1 = new SaveFileDialog();

            _saveFile1.DefaultExt = "*.rtf";
            _saveFile1.Filter = "RTF Files|*.rtf";

            if (_saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               _saveFile1.FileName.Length > 0)
            {
                _richTextBox.SaveFile(_saveFile1.FileName, RichTextBoxStreamType.RichText);
            }
        }
                                         
        private void _printToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_printDialog.ShowDialog() == DialogResult.OK)
                _printDocument.Print();
        }

        private void _printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _checkPrint = 0;
        }

        private void _printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            _checkPrint = _richTextBox.Print(_checkPrint, _richTextBox.TextLength, e);

            // Check for more pages
            if (_checkPrint < _richTextBox.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

    }
}
