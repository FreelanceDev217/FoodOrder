using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrder
{
    public partial class LogForm : Form
    {
        public FoodOrderApp m_app;
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            uiDateFrom.Value = DateTime.Now.AddDays(-1000);
            uiDateTo.Value = DateTime.Now;

            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            m_app.m_status = false;

            string fromDate = uiDateFrom.Value.ToString("yyyy-MM-dd HH:mm");
            string toDate = uiDateTo.Value.ToString("yyyy-MM-dd HH:mm");

            uiGridLog.ReadOnly = true;
            uiGridLog.Rows.Clear();

            uiGridLog.ColumnCount = 6;
            uiGridLog.Columns[0].Name = "No";
            uiGridLog.Columns[1].Name = "ID";
            uiGridLog.Columns[2].Name = "Date"; 
            uiGridLog.Columns[3].Name = "User";
            uiGridLog.Columns[4].Name = "Print Date";
            uiGridLog.Columns[5].Name = "Items";

            string wh = " where a.order_date >= '" + fromDate + "' and a.order_date <= '" + toDate + "' ";
            string query = "select a.order_id, a.order_date, b.display_name as user_name, a.order_items, a.print_info from golf_food_orders a left join users b on a.order_user = b.username" + wh + " order by order_date desc";
            MySqlCommand cmd = new MySqlCommand(query, m_app.m_conn.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            int rows = 0;
            while (dataReader.Read())
            {
                rows++;
                string res = dataReader["print_info"].ToString();
                if (res == "")
                    res = "Not available";
                else if (res == "printer error")
                    res = "Printer Error";
                string[] row = new string[] { rows.ToString(), dataReader["order_id"].ToString(), dataReader["order_date"].ToString(), dataReader["user_name"].ToString(), res , dataReader["order_items"].ToString() };
                uiGridLog.Rows.Add(row); 
            }
            dataReader.Close();
            m_app.m_status = true;

            uiGridLog.Refresh();
        }

        private void uiBtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void uiDateFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void uiDateTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
