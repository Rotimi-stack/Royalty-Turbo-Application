﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public partial class MarriageForm : Form
    {
        public MarriageForm()
        {
            InitializeComponent();
        }

        private void MarriageForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
