namespace CubeMap_BUILDER_
{
    partial class CubeMap_UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CubeMap_UI));
            this.discord = new System.Windows.Forms.Label();
            this.build_button = new System.Windows.Forms.Button();
            this.console_panel = new System.Windows.Forms.Panel();
            this.check = new System.Windows.Forms.CheckBox();
            this.uncheck = new System.Windows.Forms.CheckBox();
            this.console_label = new System.Windows.Forms.Label();
            this.file_button = new System.Windows.Forms.Button();
            this.bedrock_option = new System.Windows.Forms.CheckBox();
            this.java_option = new System.Windows.Forms.CheckBox();
            this.directory_button = new System.Windows.Forms.Button();
            this.console_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // discord
            // 
            this.discord.AutoSize = true;
            this.discord.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discord.Location = new System.Drawing.Point(710, 453);
            this.discord.Name = "discord";
            this.discord.Size = new System.Drawing.Size(234, 38);
            this.discord.TabIndex = 1;
            this.discord.Text = "discord.gg/swim";
            // 
            // build_button
            // 
            this.build_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.build_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.build_button.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.build_button.ForeColor = System.Drawing.Color.White;
            this.build_button.Location = new System.Drawing.Point(594, 295);
            this.build_button.Name = "build_button";
            this.build_button.Size = new System.Drawing.Size(336, 147);
            this.build_button.TabIndex = 2;
            this.build_button.Text = "BUILD";
            this.build_button.UseVisualStyleBackColor = false;
            this.build_button.Click += new System.EventHandler(this.build_button_Click);
            // 
            // console_panel
            // 
            this.console_panel.BackColor = System.Drawing.Color.Black;
            this.console_panel.Controls.Add(this.check);
            this.console_panel.Controls.Add(this.uncheck);
            this.console_panel.Controls.Add(this.console_label);
            this.console_panel.Location = new System.Drawing.Point(11, 9);
            this.console_panel.Name = "console_panel";
            this.console_panel.Size = new System.Drawing.Size(429, 432);
            this.console_panel.TabIndex = 3;
            // 
            // check
            // 
            this.check.AutoSize = true;
            this.check.Checked = true;
            this.check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check.ForeColor = System.Drawing.Color.White;
            this.check.Location = new System.Drawing.Point(27, 357);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(95, 20);
            this.check.TabIndex = 7;
            this.check.Text = "checkBox1";
            this.check.UseVisualStyleBackColor = true;
            this.check.Visible = false;
            // 
            // uncheck
            // 
            this.uncheck.AutoSize = true;
            this.uncheck.ForeColor = System.Drawing.Color.White;
            this.uncheck.Location = new System.Drawing.Point(27, 397);
            this.uncheck.Name = "uncheck";
            this.uncheck.Size = new System.Drawing.Size(95, 20);
            this.uncheck.TabIndex = 8;
            this.uncheck.Text = "checkBox2";
            this.uncheck.UseVisualStyleBackColor = true;
            this.uncheck.Visible = false;
            // 
            // console_label
            // 
            this.console_label.AutoSize = true;
            this.console_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_label.ForeColor = System.Drawing.Color.White;
            this.console_label.Location = new System.Drawing.Point(21, 28);
            this.console_label.Name = "console_label";
            this.console_label.Size = new System.Drawing.Size(0, 31);
            this.console_label.TabIndex = 0;
            // 
            // file_button
            // 
            this.file_button.BackColor = System.Drawing.Color.Black;
            this.file_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_button.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_button.ForeColor = System.Drawing.Color.White;
            this.file_button.Location = new System.Drawing.Point(594, 202);
            this.file_button.Name = "file_button";
            this.file_button.Size = new System.Drawing.Size(336, 87);
            this.file_button.TabIndex = 4;
            this.file_button.Text = "CHOOSE FILE";
            this.file_button.UseVisualStyleBackColor = false;
            this.file_button.Click += new System.EventHandler(this.file_button_Click);
            // 
            // bedrock_option
            // 
            this.bedrock_option.AutoSize = true;
            this.bedrock_option.Font = new System.Drawing.Font("Poppins SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedrock_option.Location = new System.Drawing.Point(13, 461);
            this.bedrock_option.Name = "bedrock_option";
            this.bedrock_option.Size = new System.Drawing.Size(87, 27);
            this.bedrock_option.TabIndex = 5;
            this.bedrock_option.Text = "bedrock";
            this.bedrock_option.UseVisualStyleBackColor = true;
            this.bedrock_option.CheckStateChanged += new System.EventHandler(this.bedrock_option_CheckStateChanged);
            // 
            // java_option
            // 
            this.java_option.AutoSize = true;
            this.java_option.Font = new System.Drawing.Font("Poppins SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.java_option.Location = new System.Drawing.Point(105, 461);
            this.java_option.Name = "java_option";
            this.java_option.Size = new System.Drawing.Size(62, 27);
            this.java_option.TabIndex = 6;
            this.java_option.Text = "java";
            this.java_option.UseVisualStyleBackColor = true;
            this.java_option.CheckStateChanged += new System.EventHandler(this.java_option_CheckStateChanged);
            // 
            // directory_button
            // 
            this.directory_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.directory_button.Font = new System.Drawing.Font("Poppins SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directory_button.Location = new System.Drawing.Point(173, 457);
            this.directory_button.Name = "directory_button";
            this.directory_button.Size = new System.Drawing.Size(267, 33);
            this.directory_button.TabIndex = 7;
            this.directory_button.Text = "DIRECTORY";
            this.directory_button.UseVisualStyleBackColor = true;
            this.directory_button.Click += new System.EventHandler(this.directory_button_Click);
            // 
            // CubeMap_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.directory_button);
            this.Controls.Add(this.java_option);
            this.Controls.Add(this.bedrock_option);
            this.Controls.Add(this.file_button);
            this.Controls.Add(this.console_panel);
            this.Controls.Add(this.build_button);
            this.Controls.Add(this.discord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CubeMap_UI";
            this.Text = "CubeMap[BUILDER]";
            this.Load += new System.EventHandler(this.CubeMap_UI_Load);
            this.console_panel.ResumeLayout(false);
            this.console_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label discord;
        private System.Windows.Forms.Button build_button;
        private System.Windows.Forms.Panel console_panel;
        private System.Windows.Forms.Button file_button;
        private System.Windows.Forms.Label console_label;
        private System.Windows.Forms.CheckBox bedrock_option;
        private System.Windows.Forms.CheckBox java_option;
        private System.Windows.Forms.CheckBox check;
        private System.Windows.Forms.CheckBox uncheck;
        private System.Windows.Forms.Button directory_button;
    }
}

