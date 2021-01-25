using System;
using TelepromClient;

namespace TelepromTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teleprom client");

            var telepromClient = new Teleprom
            {
                Credentials = new TelepromCredentials
                {
                    UserName = "your_user",
                    Password = "your_password"
                },
                Origin = TelepromOrigin.SMS_CORTO
            };

            var result = telepromClient.SendSms("phone_number", "prueba");
            Console.WriteLine($"Result: {result}");

        }
    }
}
