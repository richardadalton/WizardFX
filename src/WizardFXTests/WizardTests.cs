using NUnit.Framework;
using WizardFX;

namespace WizardFXTests
{
    [TestFixture]
    public class WizardTests
    {
        private Wizard _wizard;

        [Test]
        public void a_wizard_can_have_a_title()
        {
            _wizard = new Wizard("Any Title");
            Assert.AreEqual("Any Title", _wizard.Title);
        }

        [Test]
        public void a_wizard_does_not_have_to_have_a_title()
        {
            _wizard = new Wizard();
            Assert.AreEqual("", _wizard.Title);
        }

        [Test]
        public void new_wizard_is_not_started()
        {
            _wizard = new Wizard();
            Assert.AreEqual(false, _wizard.IsInProcess);
        }

        [Test]
        [ExpectedException("System.ApplicationException")]
        public void empty_wizard_throws_exception_on_move_next()
        {
            _wizard = new Wizard();
            _wizard.MoveNext();
        }

        [Test]
        [ExpectedException("System.ApplicationException")]
        public void empty_wizard_throws_an_exception_on_start()
        {
            _wizard = new Wizard();
            _wizard.Start();
            _wizard.MoveNext();
        }

        [Test]
        public void GivenAOneStepWizard_OnStarting_WizardIsOnFirstStep()
        {
            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            wizard.Start();
            Assert.That(wizard.IsFirstStep());
        }

        [Test]
        public void GivenAOneStepWizard_OnStarting_WizardIsOnLastStep()
        {
            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            wizard.Start();
            Assert.That(wizard.IsLastStep());
        }

        [Test]
        public void GivenAOneStepWizard_OnMovePrevious_WizardIsCancelled()
        {
            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            wizard.Start();
            wizard.MovePrevious();
            Assert.That(wizard.IsInProcess, Is.False);
        }

        [Test]
        public void GivenAOneStepWizard_OnMoveNext_WizardIsFinished()
        {
            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            wizard.Start();
            wizard.MoveNext();
            Assert.That(wizard.IsInProcess, Is.False);
        }

        [Test]
        public void GivenAOneStepWizard_OnExit_WizardIsNotInProcess()
        {
            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            wizard.Start();
            wizard.Exit();
            Assert.That(wizard.IsInProcess, Is.False);
        }

        [Test]
        public void GivenATwoStepWizard_OnMovingToSecondStep_WizardIsNotOnFirstStep()
        {
            var step1 = new WizardStep();
            var step2 = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step1)
                    .AddStep(step2);

            wizard.Start();
            wizard.MoveNext();
            Assert.That(wizard.IsFirstStep(),Is.False);
        }

        [Test]
        public void GivenATwoStepWizard_OnStarting_WizardIsNotOnLastStep()
        {
            var step1 = new WizardStep();
            var step2 = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step1)
                    .AddStep(step2);

            wizard.Start();
            Assert.That(wizard.IsLastStep(), Is.False);
        }


        [Test]
        [ExpectedException("System.ApplicationException")]
        public void can_not_move_next_on_an_unstarted_wizard()
        {
            var step1 = new WizardStep();

            _wizard = new Wizard()
                .AddStep(step1);

            _wizard.MoveNext();
            Assert.AreEqual(true, _wizard.IsInProcess);
            Assert.AreEqual(step1, _wizard.CurrentStep);
        }


        [Test]
        [ExpectedException("System.ApplicationException")]
        public void move_previous_unstarted_wizard_throws_exception()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.MovePrevious();
        }
    }
}
