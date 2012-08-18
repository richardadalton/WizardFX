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
        public void can_add_arg()
        {
            var args = new Args();
            args.Add("arg1", 1);

            Assert.AreEqual(1, args.Count);
        }

        [Test]
        public void can_retrieve_arg()
        {
            var args = new Args();
            args.Add("arg1", "Test");

            Assert.AreEqual("Test", args["arg1"]);
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
        [ExpectedException("System.ApplicationException")]
        public void add_arg_when_already_exists_throws_exception()
        {
            var args = new Args();
            args.Add("arg1", "A");
            args.Add("arg1", "B");
        }
    }
}
