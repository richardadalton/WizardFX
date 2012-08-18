using System.Windows.Forms;
using WizardFX;

namespace EmbeddedWizardDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var controller = new WizardController(wizardView);

            var wizard = new Wizard();
            wizard.AddStep(new Step1())
                  .AddStep(new Step2());
            controller.Start(wizard);
        }

        private void wizard_view_unloaded(object sender, System.EventArgs e)
        {
            wizardView.Enabled = false;
        }
    }
}
