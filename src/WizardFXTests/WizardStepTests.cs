using NUnit.Framework;
using WizardFX;
using WizardFXTests.MockFactories;

namespace WizardFXTests
{
    [TestFixture]
    class WizardStepTests
    {
        [Test]
        public void a_step_can_prevent_move_next_from_happening()
        {
            var step1 = new MockStepFactory().AStep.ThatCanNotMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.Stub();

            var wizard = new Wizard()
                .AddStep(step1)
                .AddStep(step2);

            wizard.Start();
            Assert.AreEqual(step1, wizard.CurrentStep);

            wizard.MoveNext();
            Assert.AreEqual(step1, wizard.CurrentStep);
        }

        [Test]
        public void a_step_can_prevent_move_previous_from_happening()
        {
            var step1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.ThatCanNotMovePrevious.Stub();

            var wizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2);

            wizard.Start();
            wizard.JumpToStep(2);
            Assert.AreEqual(step2, wizard.CurrentStep);

            wizard.MovePrevious();
            Assert.AreEqual(step2, wizard.CurrentStep);
        }

        [Test]
        public void visit_method_is_called_when_a_step_is_visited()
        {
            var step1 = new MockStepFactory().AStep
                                 .ThatCanMoveNext
                                 .Stub();
            var step2 = new MockStepFactory().AStep
                                 .ThatCanMovePrevious
                                 .Mock();

            var wizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2.Object);

            wizard.Start();
            wizard.JumpToStep(2);
            wizard.MovePrevious();
            wizard.MoveNext();

            step2.Verify(s=>s.Visit(),Moq.Times.Exactly(2));
        }

        [Test]
        public void can_jump_to_step()
        {
            var step1 = new MockStepFactory().AStep.Stub();
            var step2 = new MockStepFactory().AStep.Stub();
            var step3 = new MockStepFactory().AStep.Stub();
            var step4 = new MockStepFactory().AStep.Stub();

            var wizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2)
                                    .AddStep(step3)
                                    .AddStep(step4);

            wizard.Start();
            wizard.JumpToStep(3);
            Assert.AreEqual(step3, wizard.CurrentStep);
        }

        [Test]
        [ExpectedException("System.ApplicationException")]
        public void an_unstarted_wizard_throws_an_exception_on_jump_to_step()
        {
            var step = new WizardStep();

            var wizard = new Wizard()
                .AddStep(step);

            wizard.JumpToStep(1);
        }

    }
}
