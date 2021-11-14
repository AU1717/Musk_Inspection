﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Musk_Inspections
{
    public partial class Dashboard : Form
    {
        public static class Directories
        {
            public static string dirPDFfile;
            public static string dirWordFile;
        }

        public Dashboard()
        {

            //Ignore and DO NOT REMOVE THIS GIBBERISH
            //V momenta v  koito cuknish sumbmit se pravi Word file 
            // sled tova se pravi nova row s id i drygite atribyti
            //sled tova vzima word fila i go preimenyva s id to 
            //chak togava pravi pdf file s id na reporta
            //!! no moje i da napravim purvo row i sled tova da kopirame id-to i da go slojim na word fila
            // Da napravish 
            // 1 da pokazva iztegli vmesto linka kum failsa
            // nameri nachin da otvaeq faila sled kato cuknish na kletkata (VIEW) tova e samo za PDF
            // chujdite klychove da pokazvat value vmesto reference

            // YeeYee
            InitializeComponent();
            //correct format for picking a date
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            gettingDirectories();
        }
        public void gettingDirectories()
        {
            string directory = Directory.GetCurrentDirectory();
            directory = directory.Substring(0, directory.Length - 9); //remove the unneccesery parts of the current directory
            Directories.dirPDFfile = Path.Combine(directory, "pdf_files");
            Directories.dirWordFile = Path.Combine(directory, "word_files");

        }

        private void btnOpenCreateReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_report_page Cr = new Create_report_page();
            Cr.ShowDialog();
            this.Close();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'musk_DBDS.Inspectors' table. You can move, or remove it, as needed.
           // this.inspectorsTableAdapter.Fill(this.musk_DBDS.Inspectors);
            // TODO: This line of code loads data into the 'musk_DBDS.Inspection' table. You can move, or remove it, as needed.
           // this.inspectionTableAdapter.Fill(this.musk_DBDS.Inspection);
            // TODO: This line of code loads data into the 'musk_DBDataSet.Inspection' table. You can move, or remove it, as needed.
           // this.inspectionTableAdapter.Fill(this.musk_DBDS.Inspection);
            // TODO: This line of code loads data into the 'musk_DBDataSet.Inspections' table. You can move, or remove it, as needed.
           //this.inspectionTableAdapter.Fill(this.musk_DBDS.Inspection);
            // TODO: This line of code loads data into the 'musk_DBDataSet.Inspectors' table. You can move, or remove it, as needed.
           // this.inspectorTableAdapter.Fill(this.musk_DBDS.Inspectors);
            // TODO: This line of code loads data into the 'musk_DBDataSet.Inspections' table. You can move, or remove it, as needed.
           // this.inspectionTableAdapter.Fill(this.musk_DBDS.Inspection);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(1) && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
                  
                    MessageBox.Show(Directories.dirPDFfile);

                    string filename = Path.Combine(Directories.dirPDFfile, "5.pdf");
                    System.Diagnostics.Process.Start(filename);

                    //SLED kato razgadaish kak da napravish fail s imeto koeto da e id-to 
                    //IMPORTANT THE FILE NAME HAS TO BE THE SAME AS THE ID

                }
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.inspectionTableAdapter.FillBy(this.musk_DBDS.Inspection);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
