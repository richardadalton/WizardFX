using System;
using NUnit.Framework;
using WizardFX;
using WizardFXTests.MockFactories;
using Moq;

namespace WizardFXTests
{
    [TestFixture]
    public class WizardViewTests
    {
        [Test]
        public void GiveAOneStepWizard_OnStarting_WizardIsOnFirstStep()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            controller.Start(wizard);
            view.Verify(m => m.IsFirstStep(true));
        }

        [Test]
        public void GiveAOneStepWizard_OnStarting_WizardIsOnLastStep()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            controller.Start(wizard);
            view.Verify(m => m.IsLastStep(true));
        }

        [Test]
        public void GiveATwoStepWizard_OnMovingToSecondStep_WizardIsNotOnFirstStep()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var wizard = new Wizard()
                    .AddStep(new WizardStep())
                    .AddStep(new WizardStep());

            controller.Start(wizard);
            view.Verify(m => m.IsLastStep(false));
        }

        [Test]
        public void GiveATwoStepWizard_OnStarting_WizardIsNotOnLastStep()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var wizard = new Wizard()
                    .AddStep(new WizardStep())
                    .AddStep(new WizardStep());

            controller.Start(wizard);
            view.Verify(m => m.IsLastStep(false));
        }

        [Test]
        public void GiveAnUnstartedWizard_OnStarting_TheFirstStepIsSentToTheView()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            controller.Start(wizard);
            view.Verify(m => m.ShowStep(step));
        }

        [Test]
        public void GivenAStartedWizard_OnMoveNext_TheSecondStepIsSentToTheView()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step1 = new WizardStep();
            var step2 = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step1)
                    .AddStep(step2);

            controller.Start(wizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            view.Verify(m => m.ShowStep(step2));
        }

        [Test]
        public void GivenAStartedWizard_OnFinish_NoStepIsSentToTheView()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            controller.Start(wizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            view.Verify(m => m.ShowStep(step), Times.AtMostOnce());
        }

        [Test]
        public void GivenAStartedWizard_OnFinish_ViewIsUnloaded()
        {
            var view = new MockViewFactory().AView.Mock();
            var controller = new WizardController(view.Object);

            var step = new WizardStep();
            var wizard = new Wizard()
                    .AddStep(step);

            controller.Start(wizard);
            view.Raise(v => v.MovedNext += null, EventArgs.Empty);
            view.Verify(m => m.Unload());
        }


    }
}
