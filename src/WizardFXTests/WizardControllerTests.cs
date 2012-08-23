using System;
using NUnit.Framework;
using WizardFX;
using WizardFXTests.MockFactories;

namespace WizardFXTests
{
    [TestFixture]
    class WizardControllerTests
    {
        [Test]
        public void on_sub_wizard_completion_previous_wizard_resumes()
        {
            var step1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step3 = new MockStepFactory().AStep.Stub();
            var mainWizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2)
                                    .AddStep(step3);

            var step1_1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var subWizard = new Wizard()
                                    .AddStep(step1_1);

            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);
            
            controller.Start(mainWizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            Assert.AreEqual(step2, controller.CurrentStep, "At Step 2 before starting Sub Wizard");

            controller.Start(subWizard);
            Assert.AreEqual(step1_1, controller.CurrentStep, "In Sub Wizard after starting Sub Wizard");

            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            Assert.AreEqual(step2, controller.CurrentStep, "At Step 2 after ending Sub Wizard");
        }

        [Test]
        public void on_sub_wizard_cancel_previous_wizard_resumes()
        {
            var step1 = new MockStepFactory().AStep.ThatCanMoveNext.Stub();
            var step2 = new MockStepFactory().AStep.Stub();
            var step3 = new MockStepFactory().AStep.Stub();
            var mainWizard = new Wizard()
                                    .AddStep(step1)
                                    .AddStep(step2)
                                    .AddStep(step3);

            var step1_1 = new MockStepFactory().AStep.Stub();
            var subWizard = new Wizard()
                                    .AddStep(step1_1);

            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            controller.Start(mainWizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            Assert.AreEqual(step2, controller.CurrentStep, "At Step 2 before starting Sub Wizard");

            controller.Start(subWizard);
            Assert.AreEqual(step1_1, controller.CurrentStep, "In Sub Wizard after starting Sub Wizard");

            view.Raise(v => v.Cancelled += null, EventArgs.Empty);
            Assert.AreEqual(step2, controller.CurrentStep, "At Step 2 after cancel Sub Wizard");
        }

    }
}
