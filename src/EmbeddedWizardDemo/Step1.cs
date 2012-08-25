using WizardFX;

namespace EmbeddedWizardDemo
{
    public partial class Step1 : WizardStep
    {
        public Step1()
        {
            InitializeComponent();
        }

        public override void LeavingStep()
        {
            StoreValue("Name", txtName.Text);
            StoreValue("Address", txtAddress.Text);
            StoreValue("Email", txtEmail.Text);
        }
    }
}
