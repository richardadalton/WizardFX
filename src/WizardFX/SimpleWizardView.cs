using System;
using System.Windows.Forms;

namespace WizardFX
{
    public partial class SimpleWizardView : Form, IWizardView 
    {
        public event EventHandler MovedPrevious;
        public event EventHandler MovedNext;
        public event EventHandler Cancelled;
        public event EventHandler Unloaded;

        public SimpleWizardView()
        {
            InitializeComponent();
        }

        public void AllowMovePrevious(bool allow)
        {
            wizardView.AllowMovePrevious(allow);
        }

        public void AllowMoveNext(bool allow)
        {
            wizardView.AllowMoveNext(allow);
        } 

        public void ShowStep(IWizardStep step)
        {
            wizardView.ShowStep(step);
        }

        public void Unload()
        { }

        private void wizard_view_moved_previous(object sender, EventArgs e)
        {
            if (MovedPrevious != null) MovedPrevious(sender, e);
        }

        private void wizard_view_moved_next(object sender, EventArgs e)
        {
            if (MovedNext != null) MovedNext(sender, e);
        }

        private void wizard_view_cancelled(object sender, EventArgs e)
        {
            if (Cancelled != null) Cancelled(this, e);
            Close();
        }

        private void wizard_view_unloaded(object sender, EventArgs e)
        {
            if (Unloaded != null) Unloaded(this, e);
            Close();
        }
    }
}
