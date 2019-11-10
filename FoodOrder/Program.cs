using DBConnectNS;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace FoodOrder
{
    public class FoodOrderApp : Form
    {
        public UserSetting m_setting;
        public DBConnect m_conn = new DBConnect();
        public bool m_status = false;
        public Dictionary<string, string> m_dict_match = new Dictionary<string, string>();
        System.Timers.Timer m_timer = new System.Timers.Timer();
        public List<string> m_printers = new List<string>();
        public string m_def_printer;
        public bool m_is_startup = true;

        [STAThread]
        public static void Main()
        {
            Application.Run(new FoodOrderApp());
        }

        private NotifyIcon m_trayIcon;
        private ContextMenu m_trayMenu;
        public FoodOrderApp()
        {
            // Create a simple tray menu with only one item.
            m_trayMenu = new ContextMenu();

            m_trayMenu.MenuItems.Add("Settings", OnSetting);
            m_trayMenu.MenuItems.Add("Logs", OnShowLog);
            m_trayMenu.MenuItems.Add("Select Printers", OnSelectPrinters);
            m_trayMenu.MenuItems.Add("About", OnAbout);
            m_trayMenu.MenuItems.Add("Exit", OnExit);

            m_trayIcon = new NotifyIcon();
            m_trayIcon.Text = "FoodOrder";
            try
            {
                m_trayIcon.Icon = new Icon("icon.ico");
            }
            catch (Exception e)
            {
                m_trayIcon.Icon = System.Drawing.SystemIcons.Shield;
                System.Diagnostics.Debug.Print(e.Message);
            }

            // Add menu to tray icon and show it.
            m_trayIcon.ContextMenu = m_trayMenu;
            m_trayIcon.Visible = true;

            OnSetting(null, null);
            m_is_startup = false;

            m_timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            m_timer.Interval = m_setting.check_interval * 1000;
            if (m_timer.Interval <= 0)
                m_timer.Interval = 3000;
            m_timer.AutoReset = false;
            m_timer.Start();

            SetStartup();
        }

        private void CheckPrinters()
        {
            m_printers.Clear();
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    m_def_printer = printer;

                m_printers.Add(printer);
            }
            return;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (m_conn.connection.State == System.Data.ConnectionState.Fetching ||
                m_conn.connection.State == System.Data.ConnectionState.Executing ||
                m_conn.connection.State == System.Data.ConnectionState.Closed ||
                m_conn.connection.State == System.Data.ConnectionState.Connecting || m_status == false)
            {
                m_timer.Start();
                return;
            }

            // prevent duplicate operation
            m_status = false;

            // get pending orders and process one by one
            Dictionary<string, string> proc_result = new Dictionary<string, string>();
            string query = "select a.ORDER_ID, a.ORDER_USER as Member, b.display_name as Name, a.ORDER_DATE as Date, a.ORDER_ITEMS as Items, a.ORDER_REMARKS as Remark from golf_food_orders a left join users b on a.ORDER_USER = b.username WHERE a.ORDER_STATUS LIKE 'Pending'";
            MySqlCommand cmd = new MySqlCommand(query, m_conn.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            int rows = 0;
            string user_info, order_remark, item_info, order_id;
            Dictionary<string, string> items = new Dictionary<string, string>();
            while (dataReader.Read()) 
            {
                rows++;
                order_id = dataReader["ORDER_ID"].ToString();
                user_info = "Member: " + dataReader["Member"].ToString() + "\nName: " + dataReader["Name"].ToString() + "\nServer: Web Order\n" + dataReader["Date"].ToString();
                order_remark = dataReader["Remark"].ToString();
                item_info = dataReader["Items"].ToString();
                ClassifyItems(item_info, items);

                bool print_error = false;
                foreach (KeyValuePair<string, string> entry in items)
                {
                    string cat = entry.Key.ToString();
                    string content = user_info + "\n\n\n" + "Category: " + entry.Key.ToString() + "\n\n" + entry.Value.ToString() + "\n" + order_remark;
                    string printer = "";
                    if (m_dict_match.TryGetValue(cat, out printer) == false || cat == "Unknown")
                        printer = m_def_printer;
                    else if(m_printers.Contains(printer) == false)
                        printer = m_def_printer;

                    content = CalibrateContent(content);
                    if (PrintOneChit(printer, content) == false)
                        print_error = true;
                }

                if (print_error == false)
                {
                    proc_result[order_id] = DateTime.Now.ToString();
                }
                else
                {
                    proc_result[order_id] = "printer error";
                }
            }
            dataReader.Close();

            // update order table
            foreach (KeyValuePair<string, string> entry in proc_result)
            {
                query = "UPDATE golf_food_orders SET ORDER_STATUS = 'Completed', PRINT_INFO='" + entry.Value.ToString() + "' WHERE ORDER_ID=" + entry.Key.ToString();
                cmd = new MySqlCommand(query, m_conn.connection);
                cmd.ExecuteNonQuery();
            }

            // reset the timer status
            m_status = true;
            m_timer.Start();
        }

        public string CalibrateContent(string str)
        {
            string[] lines = str.Split('\n');
            string res = lines[0];
            for (int i = 1; i < lines.Length; i++)
                res = res + "\n" + CheckLim(lines[i]);
            return res;
        }

        public string CheckLim(string str)
        {
            if (str.Trim().Length == 0)
                return "";
            int lim = 40;
            int left = 0, right = 0;
            while (true)
            {
                int newpos = str.IndexOf(' ', right + 1);
                if (newpos < 0)
                {
                    right = str.Length;
                    while (right - left > lim)
                    {
                        str = str.Insert(left + lim, "\n");
                        left += lim;
                    }
                    break;
                }

                if (newpos - left > lim)
                {
                    if (newpos - right > lim) // too long
                    {
                        str = str.Insert(left + lim, "\n");
                        right = left; left += lim;
                    }
                    else
                    {
                        str = str.Remove(right, 1);
                        str = str.Insert(right, "\n");
                        left = right;
                    }
                }
                else
                {
                    right = newpos;
                }
            }
            return str;
        }
        public bool PrintOneChit(string printer, string content)
        {
            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = printer;
            Margins margins = new Margins(20, 20, 20, 20);
            p.DefaultPageSettings.Margins = margins;

            p.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                e.Graphics.DrawString(content, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(30, 30, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printing Error : " + ex.Message);
                return false;
            }
            return true;
        }

        public void ClassifyItems(string item_info, Dictionary<string, string> dict)
        {
            while (item_info.Length > 0)
            {
                string item = item_info.Substring(item_info.IndexOf('[') + 1, item_info.IndexOf(']') - item_info.IndexOf('[') - 1).Trim();
                string[] info = item.Split(new string[] { " - " }, StringSplitOptions.None);
                Dictionary<string, string> subinfo = new Dictionary<string, string>();
                foreach (string s in info)
                {
                    string[] tmp = s.Split(':');
                    subinfo.Add(tmp[0].Trim(), tmp[1].Trim());
                }

                string str = "";
                if (subinfo.TryGetValue("Item", out str))
                    item = str;
                if (subinfo.TryGetValue("Qty", out str))
                    item += "\nQty: " + str ;
                if (subinfo.TryGetValue("Note", out str))
                    item += "\n" + str + "\n";

                string cat = "", val = "";
                if(subinfo.TryGetValue("Category", out cat) == false)
                    cat = "Unknown";

                if (dict.TryGetValue(cat, out val))
                    dict[cat] = dict[cat] + "\n" + item;
                else
                    dict[cat] = item;

                item_info = item_info.Substring(item_info.IndexOf(']') + 1).Trim();
            }
        }
        public void LoadSettings()
        {
            string setting_path = AppDomain.CurrentDomain.BaseDirectory + "\\settings.json";
            m_setting = UserSetting.Load(setting_path);
            m_conn.LoadSetting(m_setting);
            CheckPrinters();
            RefreshSettings();
            return;
        }

        public void RefreshSettings()
        {
            m_dict_match.Clear();

            string[] token = m_setting.printer_match.Split(';');

            for (int i = 0; i < token.Length / 2; i++)
            {
                m_dict_match.Add(token[2 * i], token[2 * i + 1]);
            }

            if (m_timer.Interval != m_setting.check_interval * 1000)
            {
                m_timer.Stop();
                m_timer.Interval = m_setting.check_interval * 1000;
                m_timer.Start();
            }
        }
        public void SaveSettings()
        {
            string setting_path = AppDomain.CurrentDomain.BaseDirectory + "\\settings.json";
            UserSetting.Save(m_setting, setting_path);
            return;
        }


        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            
            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void OnSelectPrinters(object sender, EventArgs e)
        {
            if (m_conn.connection.State == System.Data.ConnectionState.Fetching ||
                m_conn.connection.State == System.Data.ConnectionState.Executing||
                m_conn.connection.State == System.Data.ConnectionState.Closed ||
                m_conn.connection.State == System.Data.ConnectionState.Connecting || m_status == false)
            {
                MessageBox.Show("Server not connected or busy.");
                return;
            }
            m_status = false;
            LoadSettings();
            SelectPrinterForm frm = new SelectPrinterForm();
            frm.m_app = this;
            frm.ShowDialog();
        }

        private void OnShowLog(object sender, EventArgs e)
        {
            if (m_conn.connection.State == System.Data.ConnectionState.Fetching ||
                m_conn.connection.State == System.Data.ConnectionState.Executing ||
                m_conn.connection.State == System.Data.ConnectionState.Closed ||
                m_conn.connection.State == System.Data.ConnectionState.Connecting || m_status == false)
            {

                MessageBox.Show("Server not connected or busy.");
                return;
            }
            m_status = false;
            LogForm frm = new LogForm();
            frm.m_app = this;
            frm.ShowDialog();
        }

        private void OnSetting(object sender, EventArgs e)
        {
            LoadSettings();
            SettingForm frm = new SettingForm();
            frm.m_app = this;
            frm.Show();
        }
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                m_trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            //if (chkStartUp.Checked)
                rk.SetValue("FoodOrder", Application.ExecutablePath);
            //else
            //    rk.DeleteValue("FoodOrder", false);

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodOrderApp));
            this.SuspendLayout();
            // 
            // FoodOrderApp
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FoodOrderApp";
            this.ResumeLayout(false);

        }
    } 
}