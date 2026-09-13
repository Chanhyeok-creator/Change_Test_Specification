namespace Change_Test_Specification.Forms
{
    partial class Editor_form2
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
            this.save_file_button = new System.Windows.Forms.Button();
            this.load_file_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.datagridview_name = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // save_file_button
            // 
            this.save_file_button.Location = new System.Drawing.Point(710, 370);
            this.save_file_button.Name = "save_file_button";
            this.save_file_button.Size = new System.Drawing.Size(127, 129);
            this.save_file_button.TabIndex = 1;
            this.save_file_button.Text = "Save";
            this.save_file_button.UseVisualStyleBackColor = true;
            this.save_file_button.Click += new System.EventHandler(this.save_file_button_Click);
            // 
            // load_file_button
            // 
            this.load_file_button.Location = new System.Drawing.Point(12, 22);
            this.load_file_button.Name = "load_file_button";
            this.load_file_button.Size = new System.Drawing.Size(75, 53);
            this.load_file_button.TabIndex = 5;
            this.load_file_button.Text = "Load File";
            this.load_file_button.UseVisualStyleBackColor = true;
            this.load_file_button.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(710, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 82);
            this.button2.TabIndex = 7;
            this.button2.Text = "Add Row";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(710, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 82);
            this.button1.TabIndex = 8;
            this.button1.Text = "Delete Row";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 400);
            this.panel1.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 53);
            this.button3.TabIndex = 10;
            this.button3.Text = "Open File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // datagridview_name
            // 
            this.datagridview_name.AutoSize = true;
            this.datagridview_name.Location = new System.Drawing.Point(319, 95);
            this.datagridview_name.Name = "datagridview_name";
            this.datagridview_name.Size = new System.Drawing.Size(61, 12);
            this.datagridview_name.TabIndex = 0;
            this.datagridview_name.Text = "FIle name";
            this.datagridview_name.Click += new System.EventHandler(this.datagridview_name_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(710, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 82);
            this.button4.TabIndex = 11;
            this.button4.Text = "Delete File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(710, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 82);
            this.button5.TabIndex = 12;
            this.button5.Text = "Create File";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // Editor_form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 511);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.datagridview_name);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.load_file_button);
            this.Controls.Add(this.save_file_button);
            this.Name = "Editor_form2";
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_file_button;
        private System.Windows.Forms.Button load_file_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label datagridview_name;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}