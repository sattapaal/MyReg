using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyReg
{
    public partial class GetAge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dtDOB;
            dtDOB = Request.QueryString["dob"];

            //dtDOB = "24/12/1979";

            DateTime dtNow;
            dtNow = System.DateTime.Now;
            System.TimeSpan diff1 = dtNow.Subtract(Convert.ToDateTime(dtDOB));

            var age = 0.0;

            age = Convert.ToDouble(diff1.TotalDays) / 365.25;

            Response.Write(age.ToString());
        }
    }
}