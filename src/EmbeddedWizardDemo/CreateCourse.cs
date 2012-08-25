using WizardFX;

namespace EmbeddedWizardDemo
{
    public partial class CreateCourse : WizardStep
    {
        public CreateCourse()
        {
            InitializeComponent();
        }

        public override bool OkToMoveNext()
        {
            if (txtCode.Text == "")
            {
                errorProvider1.SetError(txtCode, "Mandatory Field");
                return false;
            }

            if (txtTitle.Text == "")
            {
                errorProvider1.SetError(txtTitle, "Mandatory Field");
                return false;
            }

            return true;
        }

        public override void LeavingStep()
        {
            StoreValue("Code", txtCode.Text);
            StoreValue("Title", txtTitle.Text);
        }
    }
}
