﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowsClient.ServiceProducts.ProductServiceClient s = new ServiceProducts.ProductServiceClient();
            dataGridView1.DataSource = s.GetProducts().ToList();
            int a=0;
        }
    }
}
