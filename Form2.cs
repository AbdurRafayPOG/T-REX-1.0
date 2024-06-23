﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_REX_10._5
{
    public partial class Form2 : Form
    {
        public string PlayerName { get; private set; }
        public Form2()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerName = NameTextBox.Text;
            Form4 form4 = new Form4(PlayerName);
            form4.Show();
            Hide();
        }
    }
}
