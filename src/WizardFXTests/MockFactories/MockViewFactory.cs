using WizardFX;
using Moq;

namespace WizardFXTests.MockFactories
{
    public class MockViewFactory
    {
        private readonly Mock<IWizardView> _view = new Mock<IWizardView>();

        public MockViewFactory AView
        {
            get
            {
                return this;
            }
        }

        public Mock<IWizardView> Mock()
        {
            return _view;
        }

        public IWizardView Stub()
        {
            return _view.Object;
        }
    }
}
