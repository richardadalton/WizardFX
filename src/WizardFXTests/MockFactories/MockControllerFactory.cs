using WizardFX;
using Moq;

namespace WizardFXTests.MockFactories
{
    public class MockControllerFactory
    {
        private readonly Mock<WizardController> _controller = new Mock<WizardController>();

        public MockControllerFactory AController
        {
            get
            {
                return this;
            }
        }

        public Mock<WizardController> Mock()
        {
            return _controller;
        }

        public WizardController Stub()
        {
            return _controller.Object;
        }
    }
}
