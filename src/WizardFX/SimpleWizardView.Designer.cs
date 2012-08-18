namespace WizardFX
{
    partial class SimpleWizardView
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
            this.wizardView = new WizardFX.WizardView();
            this.SuspendLayout();
            // 
            // wizardView
            // 
            this.wizardView.CanMoveNext = false;
            this.wizardView.CanMovePrevious = false;
            this.wizardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardView.Location = new System.Drawing.Point(0, 0);
            this.wizardView.Name = "wizardView";
            this.wizardView.Size = new System.Drawing.Size(672, 456);
            this.wizardView.TabIndex = 0;
            this.wizardView.MovedPrevious += new System.EventHandler(this.wizard_view_moved_previous);
            this.wizardView.MovedNext += new System.EventHandler(this.wizard_view_moved_next);
            this.wizardView.Cancelled += new System.EventHandler(this.wizard_view_cancelled);
            this.wizardView.Unloaded += new System.EventHandler(this.wizard_view_unloaded);
            // 
            // SimpleWizardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 456);
            this.Controls.Add(this.wizardView);
            this.Name = "SimpleWizardView";
            this.Text = "SimpleWizardView";
            this.ResumeLayout(false);

        }

        #endregion

        private WizardView wizardView;



    }
}