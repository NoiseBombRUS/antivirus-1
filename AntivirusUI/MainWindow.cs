﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignatureBase;
namespace AntivirusUI
{
    public partial class MainWindow : Form
    {
        Signature sgnt;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                sgnt = new Signature(1);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) //start_scan_button

        {
            StartScaning sc = new StartScaning();
            sc.sgnt = this.sgnt;
            sc.Show();
        }
    }
}
