using WizardFX;
using System;
using System.Windows.Forms;

namespace WizardFXDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var argsForStep2 = new Args();
            argsForStep2.AddOrReplace("arg1", "abcdef");
            argsForStep2.AddOrReplace("arg2", "bcdef");
            argsForStep2.AddOrReplace("arg3", "cdef");
            argsForStep2.AddOrReplace("arg4", "efghi");
            argsForStep2.AddOrReplace("arg5", "fghijkl");
            
            IWizardView view = new SimpleWizardView();
            var controller = new WizardController(view);

            var wizard = new Wizard();
            wizard.AddStep(new Step1(argsForStep2))
                  .AddStep(new Step2(argsForStep2));
            controller.Start(wizard);

            Application.Run(view as Form);
        }
    }
}
