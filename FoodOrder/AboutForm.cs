using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace FoodOrder
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uiLinkContact.LinkVisited = true;
            System.Diagnostics.Process.Start("http://privateclubapps.com");
        }
    }
}
