using System;

namespace WizardFX
{
    public interface IWizardView
    {
        event EventHandler MovedPrevious;
        event EventHandler MovedNext;
        event EventHandler Cancelled;

        void IsFirstStep(bool value);
        void IsLastStep(bool value);

        void ShowStep(IWizardStep step);
        void Unload(Args arguments);
    }
}
