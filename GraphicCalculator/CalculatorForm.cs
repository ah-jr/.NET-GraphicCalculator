﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicCalculator
{
    public partial class CalculatorForm : Form
    {
        public const int c_PanelsOffset = 12;
        public const int c_PanelButtonsHeight = 130;
        public const float c_TextExpOffset = 0.1f;

        public CalculatorForm()
        {
            InitializeComponent();
            CalculatorForm_Resize(null, null);
        }

        private void txtExp_TextChanged(object sender, EventArgs e)
        {
            if (gvGraphic.SetExpression(txtExp.Text))
                lblExpFeedback.Text = "Enter an expression:";  
            else
                lblExpFeedback.Text = "Expression is no valid.";
        }

        private void CalculatorForm_Resize(object sender, EventArgs e)
        {
            pnlGraphic.Left = c_PanelsOffset;
            pnlGraphic.Top = c_PanelsOffset;
            pnlGraphic.Width = ClientRectangle.Width - 2 * c_PanelsOffset;
            pnlGraphic.Height = ClientRectangle.Height - c_PanelButtonsHeight - 3 * c_PanelsOffset;

            pnlButtons.Left = c_PanelsOffset;
            pnlButtons.Top = pnlGraphic.Bottom + c_PanelsOffset;
            pnlButtons.Width = pnlGraphic.Width;
            pnlButtons.Height = c_PanelButtonsHeight;

            txtExp.Left = (int) (c_TextExpOffset * pnlButtons.Width);
            txtExp.Width = (int)(pnlButtons.Width - 2 * c_TextExpOffset * pnlButtons.Width);
            lblExpFeedback.Left = txtExp.Left;
        }
    }
}
