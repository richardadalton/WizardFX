using System;
using WizardFX;

namespace WizardFXDemo
{
    public partial class Step2 : WizardStep
    {
        public Step2()
        {
            InitializeComponent();
        }

        public Step2(Args args) : base(args)
        {
            InitializeComponent();
        }

        public override void FirstTimeVisited()
        {
            leftList.Items.Add(Args["arg1"].ToString());
            leftList.Items.Add(Args["arg2"].ToString());
            leftList.Items.Add(Args["arg3"].ToString());
            leftList.Items.Add(Args["arg4"].ToString());
            leftList.Items.Add(Args["arg5"].ToString());
        }

        private void button1_click(object sender, EventArgs e)
        {
            var subWizard = new Wizard("LeftList");
            subWizard.AddStep(new SubStep1_1());

            ParentWizard.StartSubWizard(subWizard);
        }

        private void button2_click(object sender, EventArgs e)
        {
            var subWizard = new Wizard("RightList");
            subWizard.AddStep(new SubStep1_1());

            ParentWizard.StartSubWizard(subWizard);
        }

        public override void ResumeFrom(string wizardName, Args args)
        {
            if (wizardName == "LeftList")
                leftList.Items.Add(args["Value"].ToString());

            if (wizardName == "RightList")
                rightList.Items.Add(args["Value"].ToString());
        }

    }
}
