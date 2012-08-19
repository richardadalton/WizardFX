using System;
using WizardFX;

namespace WizardFXDemo
{
    public partial class Step1 : WizardStep
    {
        protected Step1()
        {
            InitializeComponent();
        }

        public Step1(Args args) : base(args)
        {
            InitializeComponent();
        }
        
        private void button1_click(object sender, EventArgs e)
        {
            var subWizard = new Wizard("SubWizard");
                subWizard.AddStep(new SubStep1_1());

            StartSubWizard(subWizard);
        }

        public override void ResumeFrom(string wizardName, Args args)
        {
            listBox1.Items.Add(args["Value"].ToString());
        }

    }
}
