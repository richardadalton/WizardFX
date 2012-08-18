WizardFx

Richard Dalton
Devjoy Ltd.
www.devjoy.com


SUMMARY

WizardFx is a Framework for WinForms Wizards.

Wizard Steps are implemented using Forms and can be easily assembled to create a Wizard. Navigation is implemented in the Framework.

WizardFx also supports nested Wizards, allowing a sub Wizard to be launched from within a step of a parent Wizard.  For example, a 'Create Folder' button could allow a user to run a Wizard for creating a folder.  On completion of that Sub Wizard, the user is returned to the Wizard Step from which they launched the Sub Wizard.

Quick Start

A WizardView is a UserControl containing Wizard Navigation Buttons (Next, Previous, Cancel), and a workspace where the various Wizard Screens are displayed.  

A WizardController is used to track the navigation through a Wizard and Sub Wizards. The WizardController is also the link between the Wizard and the WizardView.

Create a WizardControler as follows:

	var controller = new WizardController(wizardView);

The Wizard object represents a specific Wizard.  A Wizard can be instantiated, and steps added as follows:


        var wizard = new Wizard();
        wizard.AddStep(new Step1())
              .AddStep(new Step2());


Step1 and Step2 above are forms that inherit from WizardStep

Once the steps have been added you can use the Controller to start the Wizard:

        controller.Start(wizard);
 

