using System;
using System.Collections.Generic;

namespace WizardFX
{
    public class Wizard
    {
        private readonly string _title;
        private readonly List<IWizardStep> _steps = new List<IWizardStep>();
        private int _currentStepIndex;
        private readonly Args _args = new Args();
        private WizardController _controller;
        
        public Wizard() { }
        public Wizard(string title) { _title = title; }

        public string Title
        {
            get { return _title; }
        }

        public IWizardStep CurrentStep
        {
            get { return _steps[_currentStepIndex - 1]; }
        }

        public Args Args
        {
            get { return _args; }
        }

        public bool InProcess { get; private set; }

        public bool IsFirstStep()
        {
            return _currentStepIndex == 1;
        }

        public bool IsLastStep()
        {
            return _currentStepIndex == _steps.Count;
        } 

        public Wizard AddStep(IWizardStep step)
        {
            step.ParentWizard = this;
            _steps.Add(step);
            return this;
        }

        public void StartWith(WizardController controller)
        {
            _controller = controller;
            Start();
        }

        public void Start()
        {
            if (_steps.Count == 0)
                throw new ApplicationException("Can not start an empty Wizard");

            _currentStepIndex = 1;
            InProcess = true;
        }

        public void MovePrevious()
        {
            if (!InProcess)
                throw new ApplicationException("Wizard is not started, can't move previous.");

            DoMovePrevious();
        }

        public void MoveNext()
        {
            if (!InProcess)
                throw new ApplicationException("Wizard is not started, can't move next.");

            DoMoveNext();
        }

        public void JumpToStep(int step)
        {
            if (!InProcess)
                throw new ApplicationException("Wizard is not started, can't jump to a step.");

            CurrentStep.LeavingStep();

            _currentStepIndex = step;

            CurrentStep.Visit();
        }

        public void StartSubWizard(Wizard subWizard)
        {
            _controller.Start(subWizard);
        }

        public void Exit()
        {
            InProcess = false;
        }

        private void DoMoveNext()
        {
            if (CurrentStep.OkToMoveNext())
            {
                CurrentStep.LeavingStep();
                _currentStepIndex++;
            }

            if (MovedPastLastStep())
                Exit();
            else
                CurrentStep.Visit();
        }

        private void DoMovePrevious()
        {
            if (CurrentStep.OkToMovePrevious())
            {
                CurrentStep.LeavingStep();
                _currentStepIndex--;
            }

            if (MovedPastFirstStep())
                Exit();
            else
                CurrentStep.Visit();

        }

        private bool MovedPastLastStep()
        {
            return _currentStepIndex > _steps.Count;
        }

        private bool MovedPastFirstStep()
        {
            return _currentStepIndex == 0;
        }
    }
}
