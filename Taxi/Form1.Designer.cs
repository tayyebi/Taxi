﻿namespace Taxi
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(865, 42);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 457);
            this.panel2.Size = new System.Drawing.Size(865, 30);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(285, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "مدیریت مسیر ها";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(134, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(285, 62);
            this.button3.TabIndex = 2;
            this.button3.Text = "مدیریت کارمند ها";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(425, 116);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(285, 62);
            this.button4.TabIndex = 3;
            this.button4.Text = "مدیریت خودرو ها";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(134, 184);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(285, 62);
            this.button5.TabIndex = 4;
            this.button5.Text = "مدیریت سرویس ها";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(425, 184);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(285, 62);
            this.button6.TabIndex = 5;
            this.button6.Text = "مدیریت پیام ها";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "مدیریت مشتری ها";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(134, 286);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(285, 62);
            this.button7.TabIndex = 6;
            this.button7.Text = "تنظیمات برنامه";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(134, 379);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(285, 62);
            this.button8.TabIndex = 7;
            this.button8.Text = "گزارش درامد خودرو ها";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Menu_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(425, 379);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(285, 62);
            this.button9.TabIndex = 8;
            this.button9.Text = "گزارش 2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Menu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 487);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(13, 20, 13, 20);
            this.Name = "Form1";
            this.Text = "منو";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button9, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

