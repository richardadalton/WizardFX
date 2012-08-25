using System;

namespace WizardFX
{
    public class WizardEventArgs: EventArgs
    {
        public WizardEventArgs(Args arguments)
        {
            Arguments = arguments;
        }

        public Args Arguments { get; private set; }
    }
}
