using System;
using NUnit.Framework;
using WizardFX;
using WizardFXTests.MockFactories;

namespace WizardFXTests
{
    [TestFixture]
    public class WizardViewTests
    {
        [Test]
        public void view_move_next_causes_wizard_move_next()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.Stub();
   
            var wizard = new Wizard()
                    .AddStep(step1)
                    .AddStep(step2);

            controller.Start(wizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);

            Assert.AreEqual(step2, wizard.CurrentStep);
        }


        [Test]
        public void view_move_previous_causes_wizard_move_previous()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.ThatCanMovePrevious.Stub();

            var wizard = new Wizard()
                    .AddStep(step1)
                    .AddStep(step2);

            controller.Start(wizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            Assert.AreEqual(step2, wizard.CurrentStep);

            view.Raise(v => v.MovedPrevious += null, EventArgs.Empty);
            Assert.AreEqual(step1, wizard.CurrentStep);
        }

        [Test]
        public void wizard_cancels_on_view_cancel_event()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var wizard = new Wizard()
                    .AddStep(new WizardStep());

            controller.Start(wizard);
            Assert.AreEqual(true, wizard.InProcess);

            view.Raise(v => v.Cancelled += null, EventArgs.Empty);
            Assert.AreEqual(false, wizard.InProcess);
        }

        [Test]
        public void controller_unloads_view_on_cancel()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var wizard = new Wizard()
                    .AddStep(new WizardStep());

            controller.Start(wizard);
            view.Raise(v => v.Cancelled += null, EventArgs.Empty);

            view.Verify(m => m.Unload());
        }

        [Test]
        public void wizard_unloads_view_on_finish()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var wizard = new Wizard()
                    .AddStep(new WizardStep());

            controller.Start(wizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);

            view.Verify(m => m.Unload());
        }
    }
}
