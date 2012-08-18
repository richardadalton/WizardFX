using NUnit.Framework;
using WizardFX;
using WizardFXTests.MockFactories;

namespace WizardFXTests
{
    [TestFixture]
    class WizardStepTests
    {
        [Test]
        public void step_can_stop_move_next()
        {
            var step1 = new MockStepFactory().AStep.ThatCanNotMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.Stub();

            var wizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2);

            wizard.MoveNext();
            Assert.AreEqual(step1, wizard.CurrentStep);

            wizard.MoveNext();
            Assert.AreEqual(step1, wizard.CurrentStep);
        }

        [Test]
        public void step_can_stop_move_previous()
        {
            var step1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.ThatCanNotMovePrevious.Stub();

            var wizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2);

            wizard.JumpToStep(2);
            Assert.AreEqual(step2, wizard.CurrentStep, "Not at Step2 before MovePrevious");

            wizard.MovePrevious();
            Assert.AreEqual(step2, wizard.CurrentStep, "Not at Step2 after MovePrevious");
        }

        [Test]
        public void new_step_has_0_args()
        {
            var step = new WizardStep();
            Assert.AreEqual(0, step.Args.Count);
        }

        [Test]
        public void can_add_individual_args_to_a_step()
        {
            var step = new WizardStep();

            step.Args.Add("arg1", "A");
            step.Args.Add("arg2", "B"); 

            Assert.AreEqual(2, step.Args.Count);
            Assert.AreEqual("A", step.Args["arg1"]);
            Assert.AreEqual("B", step.Args["arg2"]);
        }

        [Test]
        public void can_add_colection_of_args_to_a_step_in_constructor()
        {
            var args = new Args();
            args.Add("arg1", "A");
            args.Add("arg2", "B");

            var step = new WizardStep(args);

            Assert.AreEqual(args, step.Args);
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

            wizard.JumpToStep(3);
            Assert.AreEqual(step3, wizard.CurrentStep);
        }
    }
}
