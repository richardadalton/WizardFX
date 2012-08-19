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
        public void step_parent_wizard_is_set()
        {
            var step = new WizardStep();

            var wizard = new Wizard()
                .AddStep(step);

            Assert.AreEqual(wizard, step.ParentWizard);
        }



        [Test]
        public void new_wizard_is_not_started()
        {
            _wizard = new Wizard();
            Assert.AreEqual(false, _wizard.InProcess);
        }


        [Test]
        public void move_next_increments_current_step()
        {
            var step1 = new WizardStep();
            var step2 = new WizardStep();

            _wizard = new Wizard()
                .AddStep(step1)
                .AddStep(step2);

            _wizard.Start();
            _wizard.MoveNext();
            Assert.AreEqual(step2, _wizard.CurrentStep);
        }

        [Test]
        [ExpectedException("System.ApplicationException")]
        public void can_not_move_next_on_an_unstarted_wizard()
        {
            var step1 = new WizardStep();

            _wizard = new Wizard()
                .AddStep(step1);

            _wizard.MoveNext();
            Assert.AreEqual(true, _wizard.InProcess);
            Assert.AreEqual(step1, _wizard.CurrentStep);
        }

        [Test]
        public void move_past_last_step_finishes_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.Start();  // Starts Wizard and Moves to First Step
            _wizard.MoveNext();  // Only one step so this ends the wizard
            Assert.AreEqual(false, _wizard.InProcess);
        }

        [Test]
        public void move_previous_decrements_current_step()
        {
            var step1 = new WizardStep();
            var step2 = new WizardStep();

            _wizard = new Wizard()
                .AddStep(step1)
                .AddStep(step2);

            _wizard.Start();
            _wizard.JumpToStep(2);
            _wizard.MovePrevious();
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

        [Test]
        public void move_previous_first_step_cancels_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.Start();  // Starts Wizard and Moves to First Step
            _wizard.MovePrevious();  // Only one step so this ends the wizard
            Assert.AreEqual(false, _wizard.InProcess);
        }

        [Test]
        public void cancel_wizard_cancels_wizard()
        {
            _wizard = new Wizard();
            _wizard.AddStep(new WizardStep());
            _wizard.Start();

            Assert.AreEqual(true, _wizard.InProcess);
            _wizard.Exit();
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

            wizard.Start();
            Assert.AreEqual(true, wizard.IsFirstStep());
            Assert.AreEqual(false, wizard.IsLastStep());

            wizard.MoveNext();
            Assert.AreEqual(false, wizard.IsFirstStep());
            Assert.AreEqual(true, wizard.IsLastStep());
        }
    }
}
