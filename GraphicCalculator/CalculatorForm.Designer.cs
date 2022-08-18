
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
            this.lblFun1 = new System.Windows.Forms.Label();
            this.lblFun2 = new System.Windows.Forms.Label();
            this.txtVar = new System.Windows.Forms.TextBox();
            this.gvGraphic = new GraphicCalculator.GraphicView();
            this.pnlButtons.SuspendLayout();
            this.pnlGraphic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.txtVar);
            this.pnlButtons.Controls.Add(this.lblFun1);
            this.pnlButtons.Controls.Add(this.lblFun2);
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
            this.txtExp.Location = new System.Drawing.Point(231, 41);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(226, 53);
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
            // lblFun1
            // 
            this.lblFun1.AutoSize = true;
            this.lblFun1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFun1.Location = new System.Drawing.Point(119, 44);
            this.lblFun1.Name = "lblFun1";
            this.lblFun1.Size = new System.Drawing.Size(44, 46);
            this.lblFun1.TabIndex = 11;
            this.lblFun1.Text = "f(";
            // 
            // lblFun2
            // 
            this.lblFun2.AutoSize = true;
            this.lblFun2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFun2.Location = new System.Drawing.Point(180, 44);
            this.lblFun2.Name = "lblFun2";
            this.lblFun2.Size = new System.Drawing.Size(56, 46);
            this.lblFun2.TabIndex = 12;
            this.lblFun2.Text = ")=";
            // 
            // txtVar
            // 
            this.txtVar.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVar.Location = new System.Drawing.Point(155, 41);
            this.txtVar.MaxLength = 1;
            this.txtVar.Name = "txtVar";
            this.txtVar.Size = new System.Drawing.Size(34, 53);
            this.txtVar.TabIndex = 13;
            this.txtVar.Text = "x";
            this.txtVar.TextChanged += new System.EventHandler(this.txtVar_TextChanged);
            this.txtVar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVar_KeyPress);
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
        private System.Windows.Forms.Label lblFun1;
        private System.Windows.Forms.TextBox txtVar;
        private System.Windows.Forms.Label lblFun2;
    }
}

