using System;
using System.Windows.Forms;

namespace WizardFX
{
    public partial class WizardView : UserControl, IWizardView
    {
        public WizardView()
        {
            InitializeComponent();
        }

        public event EventHandler MovedPrevious;
        public event EventHandler MovedNext;
        public event EventHandler Cancelled;
        public event EventHandler Unloaded;

        public event EventHandler Finished;

        public bool CanMoveNext { get; set; }
        public bool CanMovePrevious { get; set; }

        public void IsFirstStep(bool value)
        {
            previousButton.Enabled = !value;
        }

        public void IsLastStep(bool value)
        {
            nextButton.Text = value ? "&Finish" : "&Next";
        }

        public void ShowStep(IWizardStep step)
        {
            HideExistingSteps();
            DisplayStepWithinView(step);
        }

        public void Unload(Args args)
        {
            var arguments = new WizardEventArgs(args);
            if (Unloaded != null) Unloaded(this, arguments);
        }

        public virtual void OnMovePrevious(EventArgs e)
        {
            if (MovedPrevious != null) MovedPrevious(this, e);
        }

        protected virtual void OnMoveNext(EventArgs e)
        {
            if (MovedNext != null) MovedNext(this, e);
        }

        protected virtual void OnCancel(EventArgs e)
        {
            if (Cancelled != null) Cancelled(this, e);
        }

        private void HideExistingSteps()
        {
            foreach (WizardStep step in Workspace.Controls)
                step.Hide();
        }

        private void DisplayStepWithinView(IWizardStep step)
        {
            var stepForm = step as WizardStep;

            stepForm.TopLevel = false;
            stepForm.Parent = Workspace;

            stepForm.Left = 0;
            stepForm.Top = 0;
            stepForm.Size = Workspace.Size;
            stepForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            stepForm.Show();
        }

        private void next_button_click(object sender, EventArgs e)
        {
            OnMoveNext(EventArgs.Empty);
        }

        private void cancel_button_click(object sender, EventArgs e)
        {
            OnCancel(EventArgs.Empty);
        }

        private void previous_button_click(object sender, EventArgs e)
        {
            OnMovePrevious(EventArgs.Empty);
        }
    }
}
