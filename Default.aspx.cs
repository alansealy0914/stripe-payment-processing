using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StripeCustomer current = GetCustomer();
       // int? days = getaTraildays();
        //if (days != null)
        //{
        int chargetotal = 100;//Convert.ToInt32((3.33*Convert.ToInt32(days)*100));
            var mycharge = new StripeChargeCreateOptions();
            mycharge.AmountInCents=chargetotal;
            mycharge.Currency = "USD";
            mycharge.CustomerId = current.Id;
            string key = "sk_test_Uvk2cHkpYRTC2Rl4ZUfs4Fvs";
            var chargeservice = new StripeChargeService(key);
            StripeCharge currentcharge = chargeservice.Create(mycharge);
        //}
    }
    private StripeCustomer GetCustomer()
    {
        var mycust =new  StripeCustomerCreateOptions();
        mycust.Email = "pankaj@hotmail.com";
        mycust.Description = "Rahul Pandey(rahul@gmail.com)";
        mycust.CardNumber = "4242424242424242";
        mycust.CardExpirationMonth = "10";
        mycust.CardExpirationYear = "2014";
       // mycust.PlanId = "100";
        mycust.CardName = "Rahul Pandey";
        mycust.CardAddressCity = "ABC";
        mycust.CardAddressCountry = "USA";
        mycust.CardAddressLine1="asbcd";
        //mycust.TrialEnd = getrialend();

        var customerservice = new StripeCustomerService("sk_test_Uvk2cHkpYRTC2Rl4ZUfs4Fvs");
        return customerservice.Create(mycust);
    }
  

}