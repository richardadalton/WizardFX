using NUnit.Framework;
using WizardFX;

namespace WizardFXTests
{
    [TestFixture]
    class ArgsTests
    {
        [Test]
        public void can_create_empty_args()
        {
            var args = new Args();
            Assert.AreEqual(0, args.Count );
        }

        [Test]
        public void can_replace_arg()
        {
            var args = new Args();
            args.AddOrReplace("arg1", "A");
            args.AddOrReplace("arg1", "B");

            Assert.AreEqual("B", args["arg1"]);
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

            step.Args.AddOrReplace("arg1", "A");
            step.Args.AddOrReplace("arg2", "B");

            Assert.AreEqual(2, step.Args.Count);
            Assert.AreEqual("A", step.Args["arg1"]);
            Assert.AreEqual("B", step.Args["arg2"]);
        }

        [Test]
        public void can_add_colection_of_args_to_a_step_in_constructor()
        {
            var args = new Args();
            args.AddOrReplace("arg1", "A");
            args.AddOrReplace("arg2", "B");

            var step = new WizardStep(args);

            Assert.AreEqual(args, step.Args);
        }
    }
}
