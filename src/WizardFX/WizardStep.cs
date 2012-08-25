using System.Windows.Forms;

namespace WizardFX
{
    public partial class WizardStep : Form, IWizardStep
    {
        private readonly Args _args = new Args();
        private bool _previouslyVisited;
        
        public WizardStep() 
        {
            InitializeComponent();
        }

        public WizardStep(Args args)
        {
            InitializeComponent();
            _args = args;
        }

        public Args Args
        {
            get { return _args; }
        }

        public Wizard ParentWizard { get; set; }

        public virtual bool OkToMoveNext()
        {
            return true;
        }

        public virtual bool OkToMovePrevious()
        {
            return true;
        }

        public void Visit()
        {
            if (!_previouslyVisited)
            {
                _previouslyVisited = true;
                FirstTimeVisited();
            }
            EveryTimeVisited();
        }

        public void StartSubWizard(Wizard subWizard)
        {
            ParentWizard.StartSubWizard(subWizard);
        }

        public void StoreValue(string key, object value)
        {
            ParentWizard.Args.AddOrReplace(key, value);
        }

        public virtual void FirstTimeVisited() { }
        public virtual void EveryTimeVisited() { }
        public virtual void LeavingStep() { }

        public virtual void ResumeFrom(string wizardName) { }
        public virtual void ResumeFrom(string wizardName, Args args) { }
    }
}
