namespace CartsSimulation2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pbCart1 = new System.Windows.Forms.ProgressBar();
            this.pbCart2 = new System.Windows.Forms.ProgressBar();
            this.pbCart3 = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTesting = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbCart1
            // 
            this.pbCart1.Location = new System.Drawing.Point(419, 33);
            this.pbCart1.Name = "pbCart1";
            this.pbCart1.Size = new System.Drawing.Size(190, 10);
            this.pbCart1.TabIndex = 0;
            // 
            // pbCart2
            // 
            this.pbCart2.Location = new System.Drawing.Point(419, 49);
            this.pbCart2.Name = "pbCart2";
            this.pbCart2.Size = new System.Drawing.Size(190, 10);
            this.pbCart2.TabIndex = 1;
            // 
            // pbCart3
            // 
            this.pbCart3.Location = new System.Drawing.Point(419, 65);
            this.pbCart3.Name = "pbCart3";
            this.pbCart3.Size = new System.Drawing.Size(189, 10);
            this.pbCart3.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(307, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTesting
            // 
            this.lblTesting.AutoSize = true;
            this.lblTesting.Location = new System.Drawing.Point(323, 112);
            this.lblTesting.Name = "lblTesting";
            this.lblTesting.Size = new System.Drawing.Size(69, 17);
            this.lblTesting.TabIndex = 6;
            this.lblTesting.Text = "lblTesting";
            // 
            // timer1
            // 
        //    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTesting);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbCart3);
            this.Controls.Add(this.pbCart2);
            this.Controls.Add(this.pbCart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCart1;
        private System.Windows.Forms.ProgressBar pbCart2;
        private System.Windows.Forms.ProgressBar pbCart3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTesting;
        private System.Windows.Forms.Timer timer1;
    }
}

