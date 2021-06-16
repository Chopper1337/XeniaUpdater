
namespace XeniaUpdater_C
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.masterUpdateBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.masterStartBTN = new System.Windows.Forms.Button();
            this.canaryStartBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.canaryUpdateBTN = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.percentageLBL = new System.Windows.Forms.Label();
            this.canaryExStartBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.canaryExUpdateBTN = new System.Windows.Forms.Button();
            this.infoBTN = new System.Windows.Forms.Button();
            this.updateBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // masterUpdateBTN
            // 
            this.masterUpdateBTN.Location = new System.Drawing.Point(115, 6);
            this.masterUpdateBTN.Name = "masterUpdateBTN";
            this.masterUpdateBTN.Size = new System.Drawing.Size(69, 23);
            this.masterUpdateBTN.TabIndex = 0;
            this.masterUpdateBTN.Text = "Update";
            this.masterUpdateBTN.UseVisualStyleBackColor = true;
            this.masterUpdateBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xenia Master";
            // 
            // masterStartBTN
            // 
            this.masterStartBTN.Location = new System.Drawing.Point(190, 6);
            this.masterStartBTN.Name = "masterStartBTN";
            this.masterStartBTN.Size = new System.Drawing.Size(69, 23);
            this.masterStartBTN.TabIndex = 2;
            this.masterStartBTN.Text = "Start";
            this.masterStartBTN.UseVisualStyleBackColor = true;
            this.masterStartBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // canaryStartBTN
            // 
            this.canaryStartBTN.Location = new System.Drawing.Point(190, 35);
            this.canaryStartBTN.Name = "canaryStartBTN";
            this.canaryStartBTN.Size = new System.Drawing.Size(69, 23);
            this.canaryStartBTN.TabIndex = 6;
            this.canaryStartBTN.Text = "Start";
            this.canaryStartBTN.UseVisualStyleBackColor = true;
            this.canaryStartBTN.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Xenia Canary PR";
            // 
            // canaryUpdateBTN
            // 
            this.canaryUpdateBTN.Location = new System.Drawing.Point(115, 35);
            this.canaryUpdateBTN.Name = "canaryUpdateBTN";
            this.canaryUpdateBTN.Size = new System.Drawing.Size(69, 23);
            this.canaryUpdateBTN.TabIndex = 4;
            this.canaryUpdateBTN.Text = "Update";
            this.canaryUpdateBTN.UseVisualStyleBackColor = true;
            this.canaryUpdateBTN.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 94);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(219, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // percentageLBL
            // 
            this.percentageLBL.AutoSize = true;
            this.percentageLBL.BackColor = System.Drawing.Color.Transparent;
            this.percentageLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.percentageLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.percentageLBL.Location = new System.Drawing.Point(235, 99);
            this.percentageLBL.Name = "percentageLBL";
            this.percentageLBL.Size = new System.Drawing.Size(21, 13);
            this.percentageLBL.TabIndex = 8;
            this.percentageLBL.Text = "0%";
            this.percentageLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // canaryExStartBTN
            // 
            this.canaryExStartBTN.Location = new System.Drawing.Point(190, 65);
            this.canaryExStartBTN.Name = "canaryExStartBTN";
            this.canaryExStartBTN.Size = new System.Drawing.Size(69, 23);
            this.canaryExStartBTN.TabIndex = 11;
            this.canaryExStartBTN.Text = "Start";
            this.canaryExStartBTN.UseVisualStyleBackColor = true;
            this.canaryExStartBTN.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Xenia Canary Ex";
            // 
            // canaryExUpdateBTN
            // 
            this.canaryExUpdateBTN.Location = new System.Drawing.Point(115, 65);
            this.canaryExUpdateBTN.Name = "canaryExUpdateBTN";
            this.canaryExUpdateBTN.Size = new System.Drawing.Size(69, 23);
            this.canaryExUpdateBTN.TabIndex = 9;
            this.canaryExUpdateBTN.Text = "Update";
            this.canaryExUpdateBTN.UseVisualStyleBackColor = true;
            this.canaryExUpdateBTN.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // infoBTN
            // 
            this.infoBTN.Location = new System.Drawing.Point(10, 123);
            this.infoBTN.Name = "infoBTN";
            this.infoBTN.Size = new System.Drawing.Size(82, 23);
            this.infoBTN.TabIndex = 12;
            this.infoBTN.Text = "Information";
            this.infoBTN.UseVisualStyleBackColor = true;
            this.infoBTN.Click += new System.EventHandler(this.infoBTN_Click);
            // 
            // updateBTN
            // 
            this.updateBTN.Location = new System.Drawing.Point(180, 123);
            this.updateBTN.Name = "updateBTN";
            this.updateBTN.Size = new System.Drawing.Size(80, 23);
            this.updateBTN.TabIndex = 13;
            this.updateBTN.Text = "Update";
            this.updateBTN.UseVisualStyleBackColor = true;
            this.updateBTN.Click += new System.EventHandler(this.updateBTN_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Open Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(95, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Upload Log";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 180);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.updateBTN);
            this.Controls.Add(this.infoBTN);
            this.Controls.Add(this.canaryExStartBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.canaryExUpdateBTN);
            this.Controls.Add(this.percentageLBL);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.canaryStartBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canaryUpdateBTN);
            this.Controls.Add(this.masterStartBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.masterUpdateBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Xenia Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button masterUpdateBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button masterStartBTN;
        private System.Windows.Forms.Button canaryStartBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button canaryUpdateBTN;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label percentageLBL;
        private System.Windows.Forms.Button canaryExStartBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button canaryExUpdateBTN;
        private System.Windows.Forms.Button infoBTN;
        private System.Windows.Forms.Button updateBTN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

