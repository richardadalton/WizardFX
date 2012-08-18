//using WizardFX;
//using System.Windows.Forms;

//namespace WizardFXTests
//{
//    class MockWizardView : IWizardView
//    {
//        public event NavigateWizard MovePrevious;
//        public event NavigateWizard MoveNext;
//        public event NavigateWizard Cancel;

//        private string _currentTitle;
//        private bool _isDisplayed = true;

//        public void ShowStep(IWizardStep step, bool isFirstStep, bool isLastStep)
//        {
//            _currentTitle = step.Title;
//        }

//        public string CurrentTitle
//        {
//            get { return _currentTitle; }
//        }


//        public void Unload()
//        {
//            _isDisplayed = false;
//        }

//        public bool IsDisplayed
//        {
//            get { return _isDisplayed; }
//        }


//        public void ClickMovePrevious()
//        {
//            MovePrevious();
//        }

//        public void ClickMoveNext()
//        {
//            MoveNext();
//        }

//        public void ClickCancel()
//        {
//            Cancel();
//        }
//    }
//}
