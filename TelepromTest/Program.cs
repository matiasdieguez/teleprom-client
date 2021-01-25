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
                    UserName = "asocagolf",
                    Password = "asocagolf"
                },
                Origin = TelepromOrigin.SMS_CORTO
            };

            var result = telepromClient.SendSms("1165748002", "prueba");
            Console.WriteLine($"Result: {result}");

        }
    }
}
