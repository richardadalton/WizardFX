using System.Collections.Generic;
using WizardFX;

namespace EmbeddedWizardDemo
{
    public partial class Step2 : WizardStep
    {
        public Step2()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var createCourse = new Wizard()
                .AddStep(new CreateCourse());

            StartSubWizard(createCourse);
        }

        public override void LeavingStep()
        {
            var courses = new List<string>();

            foreach(var item in lstCourses.Items)
                courses.Add(item.ToString());

            StoreValue("Courses", courses);
        }

        public override void ResumeFrom(string wizardName, Args args)
        {
            lstCourses.Items.Add(string.Format("{0} [{1}]",args["Title"], args["Code"]));
        }
                
    }
}
