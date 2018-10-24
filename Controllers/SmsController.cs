using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


class Program
{
    static void Main(string[] args)
    {
        //Model.PhoneNumber for client that needs SMS
        SendSms().Wait();
        Console.Write("Press any key to continue.");
        Console.ReadKey();
    }

    static async Task SendSms(string RecPhone)
    {
        // Find your Account Sid and Token at twilio.com/console
        const string accountSid = process.env.TWILIO_ACCT_SID;
        const string authToken = process.env.TWILIO_AUTHTOKEN;

        TwilioClient.Init(accountSid, authToken);

        var message = await MessageResource.CreateAsync(
            body: "Would you like to recieve text notifications? Please reply Yes or No.",
            from: new Twilio.Types.PhoneNumber("+18064244476"),
            to: new Twilio.Types.PhoneNumber(RecPhone)
        );

        Console.WriteLine(message.Sid);
    }
}