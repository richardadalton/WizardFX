using System;
using System.Collections.Generic;

namespace WizardFX
{
    public class Wizard
    {
        private readonly List<IWizardStep> _steps = new List<IWizardStep>();
        private readonly string _title = string.Empty;
        private readonly Args _args = new Args();

        public Wizard() { }
        
        public Wizard(string title) 
        { 
            _title = title; 
        }

        public int NumberOfSteps
        {
            get { return _steps.Count; }
        }

        public int CurrentStepIndex { get; private set; }

        public IWizardStep CurrentStep
        {
            get { return _steps[CurrentStepIndex - 1]; }
        }

        public string Title
        {  
            get { return _title; }
        }

        public WizardController Controller { get; set; }

        public Args Args
        {
            get { return _args; }
        }

        public bool InProcess { get; private set; }

        public bool IsAtFirstStep
        {
            get { return CurrentStepIndex == 1; }
        }

        public bool IsAtLastStep
        {
            get { return CurrentStepIndex == NumberOfSteps; }
        }

        public Wizard AddStep(IWizardStep step)
        {
            step.ParentWizard = this;
            _steps.Add(step);
            return this;
        }

        public void JumpToStep(int step)
        {
            if (!InProcess)
                Start();

            CurrentStep.LeavingStep();

            CurrentStepIndex = step;

            CurrentStep.Visit();
        }


        public void MoveNext()
        {
            if (!InProcess)
                Start();
            else
                DoMoveNext();
        }


        private void DoMoveNext()
        {
            if (CurrentStep.OkToMoveNext())
            {
                CurrentStep.LeavingStep();
                CurrentStepIndex += 1;
            }

            if (MovedPastLastStep())
                Finish();
            else
                CurrentStep.Visit();
        }

        private bool MovedPastLastStep()
        {
            return CurrentStepIndex > NumberOfSteps;
        }

        private bool MovedPastFirstStep()
        {
            return CurrentStepIndex == 0;
        }

        public void MovePrevious()
        {
            if (!InProcess)
                throw new ApplicationException("Wizard is not started, can't move previous.");
                
            DoMovePrevious();
        }

        private void DoMovePrevious()
        {
            if (CurrentStep.OkToMovePrevious())
            {
                CurrentStep.LeavingStep();
                CurrentStepIndex -= 1;
            }

            if (MovedPastFirstStep())
                Cancel();
            else
                CurrentStep.Visit();

        }

        public void Cancel()
        {
            InProcess = false;
            CurrentStepIndex = 0;
        }

        public void Finish()
        {
            InProcess = false;
        }

        private void Start()
        {
            if (NumberOfSteps == 0)
                throw new ApplicationException("Can not start an empty Wizard");

            CurrentStepIndex = 1;
            InProcess = true;
        }
    }
}
