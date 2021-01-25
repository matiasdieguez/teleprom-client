using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using RestSharp;

namespace TelepromClient
{
    public class Teleprom
    {
        public TelepromCredentials Credentials { get; set; }
        public TelepromOrigin Origin { get; set; }

        public bool SendSms(string phoneNumber, string message)
        {
            var client = new RestClient("http://mayten.cloud");

            var authRequest = new RestRequest(Method.POST);
            authRequest.Resource = "auth";
            authRequest.AddJsonBody(JsonConvert.SerializeObject(Credentials));

            var authResponse = client.Execute(authRequest);
            Debug.WriteLine($"{authResponse.StatusCode} - {authResponse.Content}");

            if(!authResponse.IsSuccessful)
                return false;

            var auth = JsonConvert.DeserializeObject<TelepromAuthResponse>(authResponse.Content);

            var sendSmsRequest = new RestRequest(Method.POST);
            sendSmsRequest.Resource = "api/Mensajes/Texto";

            var telepromMessage = new TelepromMessage 
            {
                origen = Origin.ToString(),
                mensajes = new List<Mensaje>
                {
                    new Mensaje
                    {
                        identificador = Guid.NewGuid().ToString(),
                        mensaje = message,
                        telefono = phoneNumber
                    }
                }
            };
            
            sendSmsRequest.AddHeader("Authorization", $"Bearer {auth.token}");
            sendSmsRequest.AddJsonBody(JsonConvert.SerializeObject(telepromMessage));

            var response = client.Execute(sendSmsRequest);
            Debug.WriteLine($"{response.StatusCode} - {response.Content}");
            
            return response.IsSuccessful;
        }
    }
}
