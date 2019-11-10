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
    public partial class SettingForm : Form
    {
        public FoodOrderApp m_app;
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (m_app.m_is_startup == true)
                this.Visible = false;

            if (true)
            {
                uiTextServerAdd.Text = m_app.m_conn.server;
                uiTextDBName.Text = m_app.m_conn.database;
                uiTextUserID.Text = m_app.m_conn.uid;
                uiTextPassword.Text = m_app.m_conn.password;
                uiTextCheckInterval.Text = m_app.m_conn.chk_interval.ToString();
            }
            TryConnect(true);
        }

        private void uiBtnConnect_Click(object sender, EventArgs e)
        {
            if(uiBtnConnect.Text == "Connect")
            {
                m_app.m_conn.server = uiTextServerAdd.Text;
                m_app.m_conn.database = uiTextDBName.Text;
                m_app.m_conn.uid = uiTextUserID.Text;
                m_app.m_conn.password = uiTextPassword.Text;
                m_app.m_conn.chk_interval = Int32.Parse(uiTextCheckInterval.Text);

                TryConnect(false);
            }
            else
            {
                m_app.m_conn.CloseConnection();

                uiBtnConnect.Text = "Connect";

                uiTextServerAdd.Enabled = true;
                uiTextDBName.Enabled = true;
                uiTextUserID.Enabled = true;
                uiTextPassword.Enabled = true;
                uiTextCheckInterval.Enabled = true;

                uiLblStatus.Text = "Not connected to server.";
                uiLblStatus.ForeColor = System.Drawing.Color.Red;

                m_app.m_status = false;
            }
        }

        public void TryConnect(bool p_sil = true)
        {
            m_app.m_status = false;
            m_app.m_conn.CreateConnection();
            if (m_app.m_conn.OpenConnection(p_sil) == true)
            {
                uiBtnConnect.Text = "Disconnect";

                uiTextServerAdd.Enabled = false;
                uiTextDBName.Enabled = false;
                uiTextUserID.Enabled = false;
                uiTextPassword.Enabled = false;
                uiTextCheckInterval.Enabled = false;

                uiTextServerAdd.Text = m_app.m_conn.server;
                uiTextDBName.Text = m_app.m_conn.database;
                uiTextUserID.Text = m_app.m_conn.uid;
                uiTextPassword.Text = m_app.m_conn.password;
                uiTextCheckInterval.Text = m_app.m_conn.chk_interval.ToString();

                uiLblStatus.Text = "Connected to server.";
                uiLblStatus.ForeColor = System.Drawing.Color.Blue;

                m_app.m_status = true;

                m_app.RefreshSettings();
                m_app.m_conn.SaveSetting(m_app.m_setting);
                m_app.SaveSettings();

                if (m_app.m_is_startup)
                {
                    this.Close();
                }
            }
            else
            {
                uiBtnConnect.Text = "Connect";

                uiTextServerAdd.Enabled = true;
                uiTextDBName.Enabled = true;
                uiTextUserID.Enabled = true;
                uiTextPassword.Enabled = true;
                uiTextCheckInterval.Enabled = true;

                uiLblStatus.Text = "Not connected to server.";
                uiLblStatus.ForeColor = System.Drawing.Color.Red;

                m_app.m_status = true;
                this.Visible = true;

                m_app.m_conn.SaveSetting(m_app.m_setting);
                m_app.SaveSettings();
            }

        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_app.SaveSettings();
        }
    }
}
