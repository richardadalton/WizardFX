namespace WizardFXDemo
{
    public partial class SubStep1_1 : WizardFX.WizardStep
    {
        public override bool OkToMoveNext()
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Mandatory Field");
                return false;
            }
            return true;
        }

        public override void LeavingStep()
        {
            StoreValue("Value", textBox1.Text);
        }
    }
}
