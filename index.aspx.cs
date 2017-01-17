using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyReg.Models;

namespace MyReg
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            /*
            if hiddenAge is valid then
                    submit the data into the database
                send an email to the user.
            else
                sender message to the page saying the user is not in the desired age group.
            end if.
            */

            if (Double.Parse(calculatedAge.Value) < 18 || Double.Parse(calculatedAge.Value) > 100)
            {
                MyErrorLabel.Text = calculatedAge.Value + " Is not in the desired age range. Goodbye.";
            }
            else
            {
                RegistrationPerson myPerson = new RegistrationPerson();
                myPerson.FirstName = inFirstName.Text;
                myPerson.Surname = inSurname.Text;
                myPerson.Title = inTitle.SelectedValue;
                myPerson.EmailAddress = inEmail.Text;
                myPerson.dateOfBirth = Convert.ToDateTime(datepicker.Text);

                string myPersonResult, myEmailResult;

                myPersonResult = myPerson.saveRegistration(myPerson);
                MyErrorLabel.Text = myPersonResult;

                myEmailResult = myPerson.sendEmailConfirmation(myPerson);
                MyErrorLabel.Text += myEmailResult;
                submit.Enabled = false;

            }

        }
    }
}