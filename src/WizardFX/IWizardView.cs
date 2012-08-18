using System;

namespace WizardFX
{
    public interface IWizardView
    {
        event EventHandler MovedPrevious;
        event EventHandler MovedNext;
        event EventHandler Cancelled;

        void AllowMovePrevious(bool allow);
        void AllowMoveNext(bool allow);

        void ShowStep(IWizardStep step);
        void Unload();
    }
}
