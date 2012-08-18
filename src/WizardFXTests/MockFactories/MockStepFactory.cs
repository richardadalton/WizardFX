using WizardFX;
using Moq;

namespace WizardFXTests.MockFactories
{
    public class MockStepFactory
    {
        private readonly Mock<IWizardStep> _step;

        public MockStepFactory()
        {
            _step = new Mock<IWizardStep>();
        }

        public MockStepFactory AStep
        {
            get 
            {
                return this;
            }            
        }


        public MockStepFactory ThatCanMoveNext
        {
            get
            {
                _step.Setup(v => v.OkToMoveNext()).Returns(true);
                return this;
            }
        }

        public MockStepFactory ThatCanNotMoveNext
        {
            get
            {
                _step.Setup(v => v.OkToMoveNext()).Returns(false);
                return this;
            }
        }

        public MockStepFactory ThatCanMovePrevious
        {
            get
            {
                _step.Setup(v => v.OkToMovePrevious()).Returns(true);
                return this;
            }
        }

        public MockStepFactory ThatCanNotMovePrevious
        {
            get
            {
                _step.Setup(v => v.OkToMovePrevious()).Returns(false);
                return this;
            }
        }

        public IWizardStep Stub()
        {
            return _step.Object;
        }

        public Mock<IWizardStep> Mock()
        {
            return _step;
        }
    }
}
