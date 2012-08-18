using NUnit.Framework;
using WizardFX;

namespace WizardFXTests
{
    [TestFixture]
    public class WizardTests
    {
        private Wizard _wizard;

        [Test]
        public void new_wizard_has_zero_steps()
        {
            _wizard = new Wizard();
            Assert.AreEqual(0, _wizard.NumberOfSteps);
        }

        [Test]
        public void new_wizard_is_not_started()
        {
            _wizard = new Wizard();
            Assert.AreEqual(false, _wizard.InProcess);
        }

        [Test]
        [ExpectedException("System.ApplicationException")]
        public void empty_wizard_throws_exception_on_move_next()
        {
            _wizard = new Wizard();
            _wizard.MoveNext();
        }

        [Test]
        public void can_add_step_to_a_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            Assert.AreEqual(1, _wizard.NumberOfSteps);
        }

        [Test]
        public void can_add_multiple_steps_to_a_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep())
                  .AddStep(new WizardStep());

            Assert.AreEqual(2, _wizard.NumberOfSteps);
        }

        [Test]
        public void step_parent_wizard_is_set()
        {
            var step = new WizardStep();

            var wizard = new Wizard()
                                    .AddStep(step);

            Assert.AreEqual(wizard, step.ParentWizard);
        }


        [Test]
        public void move_next_increments_current_step()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.AddStep(new WizardStep());
            _wizard.MoveNext();
            Assert.AreEqual(1, _wizard.CurrentStepIndex);
            _wizard.MoveNext();
            Assert.AreEqual(2, _wizard.CurrentStepIndex);
        }

        [Test]
        public void move_next_on_unstarted_wizard_starts_it()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.AddStep(new WizardStep());
            _wizard.MoveNext();
            Assert.AreEqual(true, _wizard.InProcess);
            Assert.AreEqual(1, _wizard.CurrentStepIndex);
        }

        [Test]
        public void move_past_last_step_finishes_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.MoveNext();  // Starts Wizard and Moves to First Step
            _wizard.MoveNext();  // Only one step so this ends the wizard
            Assert.AreEqual(false, _wizard.InProcess);
        }

        [Test]
        public void move_previous_decrements_current_step()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.AddStep(new WizardStep());
            _wizard.MoveNext();
            _wizard.MoveNext();
            _wizard.MovePrevious();
            Assert.AreEqual(1, _wizard.CurrentStepIndex);
        }

        [Test]
        [ExpectedException("System.ApplicationException")]
        public void move_previous_unstarted_wizard_throws_exception()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.MovePrevious();
        }

        [Test]
        public void move_previous_first_step_cancels_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.MoveNext();  // Starts Wizard and Moves to First Step
            _wizard.MovePrevious();  // Only one step so this ends the wizard
            Assert.AreEqual(false, _wizard.InProcess);
        }

        [Test]
        public void cancel_wizard_cancels_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.MoveNext();
            Assert.AreEqual(true, _wizard.InProcess);
            _wizard.Cancel();
            Assert.AreEqual(false, _wizard.InProcess);
        }

        /*
         *  Wizard Status Properties
         */
        [Test]
        public void wizard_reports_when_at_first_step()
        {
            var wizard = new Wizard()
                                    .AddStep(new WizardStep())
                                    .AddStep(new WizardStep());

            wizard.MoveNext();
            Assert.AreEqual(true, wizard.IsAtFirstStep);
            Assert.AreEqual(false, wizard.IsAtLastStep);

            wizard.MoveNext();
            Assert.AreEqual(false, wizard.IsAtFirstStep);
            Assert.AreEqual(true, wizard.IsAtLastStep);
        } 
    }
}
