﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Musk_Inspections.Admin_Functions
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accept_Click(object sender, EventArgs e)
        {
            string fn = fnText.Text;
            string ln = lnText.Text;
            string pwd = pwText.Text;
            string table;
            
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.DB_MUSK))
            {
                cn.Open();
                SqlCommand cmd;

                if (adminCheck.Checked)
                    table = "Administrator";
                else
                    table = "Inspector";

                cmd = new SqlCommand("INSERT INTO " + table + " VALUES " +
                                     "('" + pwd + "', '" + fn + "', '" + ln + "');", cn);

                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("User Created!");
                    }
                    else
                        MessageBox.Show("User Was Not Created!");

                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);
                }
            }
        }
    }
}
