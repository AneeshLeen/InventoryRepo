﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY.UI
{
    public partial class frmlabelprint : Form
    {
        public frmlabelprint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            frmplu frplu = new frmplu();
            frplu.ShowDialog();
        }
    }
}
