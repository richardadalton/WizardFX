using System;
using System.Collections.Generic;

namespace WizardFX
{
    public class WizardController
    {
        private readonly Stack<Wizard> _wizardStack = new Stack<Wizard>();
        private Wizard _activeWizard;

        private IWizardView _view;

        public WizardController(IWizardView view)
        {
            WireEventsToView(view);
        }

        public IWizardStep CurrentStep
        {
            get { return _activeWizard.CurrentStep; }
        }

        public void Start(Wizard wizard)
        {
            if (_activeWizard != null)
                _wizardStack.Push(_activeWizard);

            _activeWizard = wizard;
            _activeWizard.StartWith(this);

            ShowWizard(_view);
        }

        private void OnMovedNext(object sender, EventArgs e)
        {
            var view = sender as IWizardView;
            if (view == null) return;

            _activeWizard.MoveNext();

            if (!_activeWizard.IsInProcess)
            {
                var resumeFromTitle = _activeWizard.Title;
                var returnArgs = _activeWizard.Args;

                if (_wizardStack.Count > 0)
                {
                    _activeWizard = _wizardStack.Pop();
                    CurrentStep.ResumeFrom(resumeFromTitle, returnArgs);
                }
                else
                    view.Unload();
            }

            if (_activeWizard.IsInProcess)
                ShowWizard(view);
        }

        private void OnMovedPrevious(object sender, EventArgs e)
        {
            var view = sender as IWizardView;

            _activeWizard.MovePrevious();
            ShowWizard(view);
        }

        private void OnCancel(object sender, EventArgs e)
        {
            var view = sender as IWizardView;
            if (view == null) return;

            _activeWizard.Exit();
            if (_wizardStack.Count > 0)
            {
                _activeWizard = _wizardStack.Pop();
                ShowWizard(view);
            }
            else
                view.Unload();
        }

        private void ShowWizard(IWizardView view)
        {
            view.ShowStep(CurrentStep);
            view.IsFirstStep(_activeWizard.IsFirstStep());
            view.IsLastStep(IsLastStep()); 
        }

        private bool IsLastStep()
        {
            return (_activeWizard.IsLastStep() && _wizardStack.Count == 0);

        }

        private void WireEventsToView(IWizardView view)
        {
            view.MovedNext += OnMovedNext;
            view.MovedPrevious += OnMovedPrevious;
            view.Cancelled += OnCancel;
            _view = view;
        }
    }
}
