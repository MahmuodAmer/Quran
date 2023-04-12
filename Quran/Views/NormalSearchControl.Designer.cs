namespace Quran.Views
{
    partial class NormalSearchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_search = new System.Windows.Forms.Button();
            this.rtb_result = new System.Windows.Forms.RichTextBox();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.comboBox_names = new System.Windows.Forms.ComboBox();
            this.richTextBox_series = new System.Windows.Forms.RichTextBox();
            this.richTextBox_matches = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_addTab = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.White;
            this.button_search.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_search.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_search.Location = new System.Drawing.Point(19, 162);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(173, 48);
            this.button_search.TabIndex = 9;
            this.button_search.Text = "بحث";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // rtb_result
            // 
            this.rtb_result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_result.Location = new System.Drawing.Point(12, 22);
            this.rtb_result.Name = "rtb_result";
            this.rtb_result.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtb_result.Size = new System.Drawing.Size(1314, 193);
            this.rtb_result.TabIndex = 8;
            this.rtb_result.Text = "";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(19, 96);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(173, 27);
            this.textBox_search.TabIndex = 7;
            // 
            // comboBox_names
            // 
            this.comboBox_names.FormattingEnabled = true;
            this.comboBox_names.Location = new System.Drawing.Point(19, 19);
            this.comboBox_names.Name = "comboBox_names";
            this.comboBox_names.Size = new System.Drawing.Size(173, 28);
            this.comboBox_names.TabIndex = 6;
            // 
            // richTextBox_series
            // 
            this.richTextBox_series.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_series.Location = new System.Drawing.Point(12, 542);
            this.richTextBox_series.Name = "richTextBox_series";
            this.richTextBox_series.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox_series.Size = new System.Drawing.Size(1314, 129);
            this.richTextBox_series.TabIndex = 10;
            this.richTextBox_series.Text = "";
            // 
            // richTextBox_matches
            // 
            this.richTextBox_matches.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_matches.Location = new System.Drawing.Point(12, 234);
            this.richTextBox_matches.Name = "richTextBox_matches";
            this.richTextBox_matches.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox_matches.Size = new System.Drawing.Size(1314, 296);
            this.richTextBox_matches.TabIndex = 11;
            this.richTextBox_matches.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(81, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "بحث";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_addTab);
            this.panel1.Location = new System.Drawing.Point(1561, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 149);
            this.panel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(20, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_addTab
            // 
            this.button_addTab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_addTab.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_addTab.ForeColor = System.Drawing.Color.White;
            this.button_addTab.Location = new System.Drawing.Point(20, 12);
            this.button_addTab.Name = "button_addTab";
            this.button_addTab.Size = new System.Drawing.Size(53, 46);
            this.button_addTab.TabIndex = 0;
            this.button_addTab.Text = "+";
            this.button_addTab.UseVisualStyleBackColor = false;
            this.button_addTab.Click += new System.EventHandler(this.button_addTab_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.comboBox_names);
            this.panel2.Controls.Add(this.textBox_search);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_search);
            this.panel2.Location = new System.Drawing.Point(1343, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 279);
            this.panel2.TabIndex = 14;
            // 
            // NormalSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox_matches);
            this.Controls.Add(this.richTextBox_series);
            this.Controls.Add(this.rtb_result);
            this.Name = "NormalSearchControl";
            this.Size = new System.Drawing.Size(1658, 723);
            this.Load += new System.EventHandler(this.NormalSearchControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_search;
        private RichTextBox rtb_result;
        private TextBox textBox_search;
        private ComboBox comboBox_names;
        private RichTextBox richTextBox_series;
        private RichTextBox richTextBox_matches;
        private Label label1;
        private Panel panel1;
        private Button button_addTab;
        private Button button1;
        private Panel panel2;
    }
}
