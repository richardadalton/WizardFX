using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WizardFX;

namespace EmbeddedWizardDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var wizard = new Wizard();
            wizard.AddStep(new Step1())
                  .AddStep(new Step2());

            var controller = new WizardController(wizardView);
            controller.Start(wizard);
        }

        private void wizard_view_unloaded(object sender, System.EventArgs e)
        {
            var arguments = e as WizardEventArgs;

            var sb = new StringBuilder();
            sb.AppendLine(arguments.Arguments["Name"].ToString());
            sb.AppendLine(arguments.Arguments["Address"].ToString());
            sb.AppendLine(arguments.Arguments["Email"].ToString());

            foreach (var course in arguments.Arguments["Courses"] as List<string>)
                sb.AppendLine(course);

            textBox.Text = sb.ToString();


            // TODO: Shouldn't Rely on the Hosting Form to do this. 
            wizardView.Enabled = false;
        }
    }
}
