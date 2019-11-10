using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrder
{
    public partial class SelectPrinterForm : Form
    {
        public FoodOrderApp m_app;
        public List<string> m_categories = new List<string>();

        public SelectPrinterForm()
        {
            InitializeComponent();
        }


        private void SelectPrinterForm_Load(object sender, EventArgs e)
        {
            if(m_app.m_conn.connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Not connected to server. Check settings, please.");
                this.Close();
            }

            CheckFoodCategories();
            FillDataGrid();
        }
        
        public void CheckFoodCategories()
        {
            string query = "SELECT FOOD_CATEGORY_NAME FROM golf_food_categories";
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, m_app.m_conn.connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            int rows = 0;
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                rows++;
                m_categories.Add(dataReader["FOOD_CATEGORY_NAME"].ToString());
            }
            dataReader.Close();
            m_app.m_status = true;
            return;
        }
        public void FillDataGrid()
        {
            uiGridPrinterMatch.Rows.Clear();

            uiGridPrinterMatch.ColumnCount = 2;
            uiGridPrinterMatch.Columns[0].Name = "No"; uiGridPrinterMatch.Columns[0].ReadOnly = true;
            uiGridPrinterMatch.Columns[1].Name = "Food Category Name"; uiGridPrinterMatch.Columns[1].ReadOnly = true;

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Printer";
            cmb.Name = "Printer";
            cmb.MaxDropDownItems = m_app.m_printers.Count;
            foreach (string printer in m_app.m_printers)
                cmb.Items.Add(printer);
            uiGridPrinterMatch.Columns.Add(cmb);

            for (int i = 0; i < m_categories.Count; i ++)
            {
                string printer;
                if(m_app.m_dict_match.TryGetValue(m_categories[i], out printer) == false)
                    printer = m_app.m_def_printer;
                else if ( m_app.m_printers.Contains(printer) == false)
                    printer = m_app.m_def_printer;
                string[] row = new string[] { (i+1).ToString(), m_categories[i], printer};
                uiGridPrinterMatch.Rows.Add(row);
            }
            uiGridPrinterMatch.Refresh();
        }

        private void SelectPrinterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
        }

        public void SaveSetting()
        {
            string match = "";
            for (int i = 0; i < m_categories.Count; i++)
            {
                if (i > 0)
                    match = match + ";";
                match = match + uiGridPrinterMatch.Rows[i].Cells[1].FormattedValue.ToString() + ";" + uiGridPrinterMatch.Rows[i].Cells[2].FormattedValue.ToString();
            }
            m_app.m_setting.printer_match = match;
            m_app.SaveSettings();
            m_app.RefreshSettings();
            return;
        }

        private void btnSavePrinterSetting_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }
    }
}
