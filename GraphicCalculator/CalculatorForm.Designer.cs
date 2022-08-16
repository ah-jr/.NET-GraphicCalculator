﻿
namespace GraphicCalculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblExpFeedback = new System.Windows.Forms.Label();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.pnlGraphic = new System.Windows.Forms.Panel();
            this.gvGraphic = new GraphicCalculator.GraphicView();
            this.pnlButtons.SuspendLayout();
            this.pnlGraphic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.lblExpFeedback);
            this.pnlButtons.Controls.Add(this.txtExp);
            this.pnlButtons.Location = new System.Drawing.Point(12, 595);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(576, 135);
            this.pnlButtons.TabIndex = 5;
            // 
            // lblExpFeedback
            // 
            this.lblExpFeedback.AutoSize = true;
            this.lblExpFeedback.Location = new System.Drawing.Point(124, 22);
            this.lblExpFeedback.Name = "lblExpFeedback";
            this.lblExpFeedback.Size = new System.Drawing.Size(103, 13);
            this.lblExpFeedback.TabIndex = 10;
            this.lblExpFeedback.Text = "Enter an expression:";
            // 
            // txtExp
            // 
            this.txtExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExp.Location = new System.Drawing.Point(124, 41);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(338, 53);
            this.txtExp.TabIndex = 9;
            this.txtExp.TextChanged += new System.EventHandler(this.txtExp_TextChanged);
            // 
            // pnlGraphic
            // 
            this.pnlGraphic.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGraphic.Controls.Add(this.gvGraphic);
            this.pnlGraphic.Location = new System.Drawing.Point(12, 12);
            this.pnlGraphic.Name = "pnlGraphic";
            this.pnlGraphic.Size = new System.Drawing.Size(576, 576);
            this.pnlGraphic.TabIndex = 6;
            // 
            // gvGraphic
            // 
            this.gvGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGraphic.Location = new System.Drawing.Point(0, 0);
            this.gvGraphic.Name = "gvGraphic";
            this.gvGraphic.Size = new System.Drawing.Size(576, 576);
            this.gvGraphic.TabIndex = 0;
            this.gvGraphic.Text = "graphicView1";
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(600, 742);
            this.Controls.Add(this.pnlGraphic);
            this.Controls.Add(this.pnlButtons);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.Resize += new System.EventHandler(this.CalculatorForm_Resize);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.pnlGraphic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlGraphic;
        private GraphicView gvGraphic;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.Label lblExpFeedback;
    }
}

