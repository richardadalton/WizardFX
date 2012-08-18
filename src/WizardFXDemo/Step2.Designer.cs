namespace WizardFXDemo
{
    partial class Step2
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
            this.leftList = new System.Windows.Forms.ListBox();
            this.rightList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftList
            // 
            this.leftList.FormattingEnabled = true;
            this.leftList.Location = new System.Drawing.Point(12, 12);
            this.leftList.Name = "leftList";
            this.leftList.Size = new System.Drawing.Size(161, 238);
            this.leftList.TabIndex = 1;
            // 
            // rightList
            // 
            this.rightList.FormattingEnabled = true;
            this.rightList.Location = new System.Drawing.Point(286, 12);
            this.rightList.Name = "rightList";
            this.rightList.Size = new System.Drawing.Size(161, 238);
            this.rightList.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_click);
            // 
            // Step2
            // 
            this.ClientSize = new System.Drawing.Size(459, 306);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rightList);
            this.Controls.Add(this.leftList);
            this.Name = "Step2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox leftList;
        private System.Windows.Forms.ListBox rightList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
