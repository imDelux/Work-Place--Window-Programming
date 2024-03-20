﻿using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucHome : UserControl
    {
        DataReader reader = new DataReader();

        public ucHome()
        {
            InitializeComponent();
        }

        private void GenerateDynamicUserControl()
        {
            fpnlContainer.Controls.Clear();

            // Get the worker list from database
            List<Worker> listWorker = reader.getWorkerList();

            // Generate user control
            for (int i = 0; i < listWorker.Count; i++) 
            {
                ucWorker workerPreview = new ucWorker();
                workerPreview.DataSetter(listWorker[i]);
                fpnlContainer.Controls.Add(workerPreview);
            }
        }

        private void ucHome_Load(object sender, EventArgs e)
        {
            GenerateDynamicUserControl();
        }
    }
}
