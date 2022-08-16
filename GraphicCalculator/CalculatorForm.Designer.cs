
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtOp1 = new System.Windows.Forms.TextBox();
            this.txtOp2 = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.txtMaxY = new System.Windows.Forms.TextBox();
            this.txtMinY = new System.Windows.Forms.TextBox();
            this.txtMaxX = new System.Windows.Forms.TextBox();
            this.txtMinX = new System.Windows.Forms.TextBox();
            this.pnlGraphic = new System.Windows.Forms.Panel();
            this.gvGraphic = new GraphicCalculator.GraphicView();
            this.pnlButtons.SuspendLayout();
            this.pnlGraphic.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(146, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtOp1
            // 
            this.txtOp1.Location = new System.Drawing.Point(187, 16);
            this.txtOp1.Name = "txtOp1";
            this.txtOp1.Size = new System.Drawing.Size(75, 20);
            this.txtOp1.TabIndex = 2;
            this.txtOp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText);
            // 
            // txtOp2
            // 
            this.txtOp2.Location = new System.Drawing.Point(278, 16);
            this.txtOp2.Name = "txtOp2";
            this.txtOp2.Size = new System.Drawing.Size(75, 20);
            this.txtOp2.TabIndex = 3;
            this.txtOp2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.txtExp);
            this.pnlButtons.Controls.Add(this.txtMaxY);
            this.pnlButtons.Controls.Add(this.txtMinY);
            this.pnlButtons.Controls.Add(this.txtMaxX);
            this.pnlButtons.Controls.Add(this.txtMinX);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.button2);
            this.pnlButtons.Controls.Add(this.txtOp2);
            this.pnlButtons.Controls.Add(this.txtOp1);
            this.pnlButtons.Location = new System.Drawing.Point(12, 595);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(576, 134);
            this.pnlButtons.TabIndex = 5;
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(359, 16);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(196, 20);
            this.txtExp.TabIndex = 9;
            this.txtExp.TextChanged += new System.EventHandler(this.txtExp_TextChanged);
            // 
            // txtMaxY
            // 
            this.txtMaxY.Location = new System.Drawing.Point(3, 100);
            this.txtMaxY.Name = "txtMaxY";
            this.txtMaxY.Size = new System.Drawing.Size(100, 20);
            this.txtMaxY.TabIndex = 8;
            this.txtMaxY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText);
            // 
            // txtMinY
            // 
            this.txtMinY.Location = new System.Drawing.Point(3, 72);
            this.txtMinY.Name = "txtMinY";
            this.txtMinY.Size = new System.Drawing.Size(100, 20);
            this.txtMinY.TabIndex = 7;
            this.txtMinY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText);
            // 
            // txtMaxX
            // 
            this.txtMaxX.Location = new System.Drawing.Point(3, 42);
            this.txtMaxX.Name = "txtMaxX";
            this.txtMaxX.Size = new System.Drawing.Size(100, 20);
            this.txtMaxX.TabIndex = 6;
            this.txtMaxX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText);
            // 
            // txtMinX
            // 
            this.txtMinX.Location = new System.Drawing.Point(3, 16);
            this.txtMinX.Name = "txtMinX";
            this.txtMinX.Size = new System.Drawing.Size(100, 20);
            this.txtMinX.TabIndex = 5;
            this.txtMinX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText);
            // 
            // pnlGraphic
            // 
            this.pnlGraphic.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGraphic.Controls.Add(this.gvGraphic);
            this.pnlGraphic.Location = new System.Drawing.Point(12, 13);
            this.pnlGraphic.Name = "pnlGraphic";
            this.pnlGraphic.Size = new System.Drawing.Size(576, 576);
            this.pnlGraphic.TabIndex = 6;
            // 
            // gvGraphic
            // 
            this.gvGraphic.Location = new System.Drawing.Point(3, 3);
            this.gvGraphic.Name = "gvGraphic";
            this.gvGraphic.Size = new System.Drawing.Size(570, 570);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.pnlGraphic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtOp1;
        private System.Windows.Forms.TextBox txtOp2;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlGraphic;
        private System.Windows.Forms.TextBox txtMaxY;
        private System.Windows.Forms.TextBox txtMinY;
        private System.Windows.Forms.TextBox txtMaxX;
        private System.Windows.Forms.TextBox txtMinX;
        private GraphicView gvGraphic;
        private System.Windows.Forms.TextBox txtExp;
    }
}

