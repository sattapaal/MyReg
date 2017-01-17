using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace MyReg.Models
{
    public class RegistrationPerson
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public DateTime dateOfBirth { get; set; }

        public string saveRegistration(RegistrationPerson person)
        {
            string mysql;
            mysql = "insert into people(Title,FirstName,LastName) Values ('" + person.Title + "','" + person.FirstName + "','" + person.Surname + "')";


            try
            {
                SqlConnection objConnect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sattadb"].ConnectionString);
                objConnect.Open();

                SqlCommand objCommand = new SqlCommand(mysql, objConnect);
                objCommand.Prepare();

                objCommand.ExecuteReader(CommandBehavior.CloseConnection);

                return "User Entered Successfully.";
            }
            catch (Exception e)
            {
                return mysql + " Exception Error : " +e.Message;
            }
            

        }
        public string sendEmailConfirmation(RegistrationPerson person)
        {
            string strBody;
            strBody = "";
            strBody += "<!DOCTYPE html>";
            strBody += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            strBody += "<head>";
            strBody += "    <meta charset=\"utf-8\" />";
            strBody += "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\" />";
            strBody += "    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css\" integrity=\"sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ\" crossorigin=\"anonymous\" />";
            strBody += "    <link rel=\"stylesheet\" href=\"http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css\" />";
            strBody += "    <title>Welcome To Dummy Site.</title>";
            strBody += "</head>";
            strBody += "<body>";
            strBody += "    <h1>Registered</h1>";
            strBody += "    <div class=\"container bg-faded card\">";
            strBody += "        <form method=\"post\" action=\"./index.aspx\" id=\"Form1\">";
            strBody += "            <div class=\"form-group row\"></div>";
            strBody += "            <div class=\"form-group row\">";
            strBody += "                <label for=\"inTitle\" id=\"lblTitle\" class=\"col-2 col-form-label\">Title</label>";
            strBody += "                <div class=\"col-5\">";
            strBody += "                    <input name=\"inTitle\" type=\"text\" value=\"Mr???\" id=\"inTitle\" class=\"form-control\" />";
            strBody += "                </div>";
            strBody += "            </div>";
            strBody += "            <div class=\"form-group row\">";
            strBody += "                <label for=\"inFirstName\" id=\"lblFirstName\" class=\"col-2 col-form-label\">Name</label>";
            strBody += "                <div class=\"col-5\">";
            strBody += "                    <input name=\"inFirstName\" type=\"text\" value=\"Satpal???\" id=\"inFirstName\" class=\"form-control\" />";
            strBody += "                </div>";
            strBody += "            </div>";
            strBody += "            <div class=\"form-group row\">";
            strBody += "                <label for=\"inSurname\" id=\"lblSurname\" class=\"col-2 col-form-label\">Surname</label>";
            strBody += "                <div class=\"col-5\"> <input name=\"inSurname\" type=\"text\" value=\"dsf???\" id=\"inSurname\" class=\"form-control\" /></div>";
            strBody += "            </div>";
            strBody += "            <div class=\"form-group row\">";
            strBody += "                <label for=\"inEmail\" id=\"lblEmail\" class=\"col-2 col-form-label\">Email</label>";
            strBody += "                <div class=\"col-5\">";
            strBody += "                    <input name=\"inEmail\" type=\"text\" value=\"sat@sat.com???\" id=\"inEmail\" class=\"form-control\" />";
            strBody += "                </div>";
            strBody += "            </div>";
            strBody += "            <div class=\"form-group row\">";
            strBody += "                <label for=\"datepicker\" id=\"lblDatepicker\" class=\"col-2 col-form-label\">Date of Birth</label>";
            strBody += "                <div class=\"col-5\">";
            strBody += "                    <input name=\"datepicker\" type=\"text\" value=\"24/12/1979???\" id=\"datepicker\" class=\"form-control\" />";
            strBody += "                </div>";
            strBody += "            </div>";
            strBody += "            <div class=\"form-group row\">";
            strBody += "                <div class=\"col-5\">";
            strBody += "                    <span id=\"MyErrorLabel\"></span>";
            strBody += "                </div>";
            strBody += "            </div>";
            strBody += "        </form>";
            strBody += "    </div>";
            strBody += "</body>";
            strBody += "</html>";

            MailAddress To = new MailAddress(person.EmailAddress);
            MailAddress From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["applicationEmail"]);
            MailAddress Copy = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["publicFolderEmail"]);
            MailMessage msgMail = new MailMessage(From, Copy);

            msgMail.Subject = "Thank you for your registration. Will be fun.";
            msgMail.IsBodyHtml = true;
            msgMail.CC.Add(To);
            msgMail.Body = strBody;
            string server = System.Configuration.ConfigurationManager.AppSettings["emailServerIP"];
            SmtpClient client = new SmtpClient(server);

            try
            {
                client.Send(msgMail);
            }
            catch (Exception e)
            {
                return e.Message;
            }


            return "Email Sent Successfully "/* + strBody*/;
        }
    }
}