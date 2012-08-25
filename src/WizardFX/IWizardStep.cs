namespace WizardFX
{
    public interface IWizardStep
    {
        Wizard ParentWizard { get; set; }
        Args Args { get; }

        bool OkToMoveNext();
        bool OkToMovePrevious();

        void Visit();
        void FirstTimeVisited();
        void EveryTimeVisited();
        void LeavingStep();

        void ResumeFrom(string wizardName, Args args);
        void ResumeFrom(string wizardName);

        void StartSubWizard(Wizard subWizard);
        void StoreValue(string key, object value);
    }
}
