namespace graphics4
{
    partial class addPoint
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
            this.x = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.pointName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(124, 62);
            this.x.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.x.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(60, 22);
            this.x.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "OX coordinates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "OY coordiantes";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(314, 63);
            this.y.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.y.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(60, 22);
            this.y.TabIndex = 4;
            // 
            // pointName
            // 
            this.pointName.Location = new System.Drawing.Point(63, 25);
            this.pointName.Name = "pointName";
            this.pointName.Size = new System.Drawing.Size(55, 22);
            this.pointName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(124, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose a different name for the point!";
            this.label1.Visible = false;
            // 
            // addPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 130);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pointName);
            this.Controls.Add(this.y);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.x);
            this.Name = "addPoint";
            this.Text = "Add new Point";
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.TextBox pointName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}