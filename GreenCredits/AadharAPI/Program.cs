using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System;
using System.Linq;
using System.Xml.Linq;
using Uidai.Aadhaar.Api;
using Uidai.Aadhaar.Device;
using Uidai.Aadhaar.ResidentData;
using Uidai.Aadhaar.ResidentData.BiometricData;
using Uidai.Aadhaar.ResidentData.Otp;
using Uidai.Aadhaar.Security;
using Uidai.Aadhaar.Utility;


namespace GreenCredits.API
{
    class Program
    {
        private static string BiometricInfo = "Rk1SACAyMAAAAADkAAgAyQFnAMUAxQEAAAARIQBqAGsgPgCIAG0fRwC2AG2dSQBVAIUjPABuALShMgCxAL0jMAByAM6lPgCmAN2kQQBwAN8qNAB1AN8mPADJAOcgOQA8AOorNABoAOomOQC+AO2fMQDFAPqlSgCvAP8lRQB8AQuhPABwAQ4fMgB7ASqcRADAAS4iNwCkATMeMwCFATYeNwBLATYwMQBWATcoMQCkATecMQBEATwyMgBJAUciQQCkAU8cNQB9AVQWNgCEAVUVRACoAVgYOgBBAV69NgCsAWeYNwAA";
        private static ApiContext apiContext = new ApiContext();
        static void Main(string[] args)
        {
            //Authenticate();
            string baseAddress = "http://192.168.0.76:80/";

            WebApp.Start<Startup>(url: baseAddress);
            // Start OWIN host 
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
            //    // Create HttpCient and make a request to api/values 
            //    HttpClient client = new HttpClient();

            //    var response = client.GetAsync(baseAddress + "api/authentication").Result;

            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //}

            Console.ReadLine(); 
        }

        public static void Authenticate()
        {
            try
            {
                // Collect resident info.
                ResidentContext resident = new ResidentContext(999999990019)
                {
                    Demographic = new Demographic()
                    {
                        Identity = new Identity()
                        {
                            Name = "Shivshankar Choudhury",
                            DateOfBirth = new DateTime(1968, 5, 13, 0, 0, 0),
                            Gender = Gender.Male,
                            Phone = "2810806979",
                            Email = "sschoudhury@dummyemail.com"
                        },
                        Address = new Address()
                        {
                            Street = "12 Maulana Azad Marg",
                            State = "New Delhi",
                            Pincode = 110002
                        }
                    }
                };
                // Add fingerprint data
                resident.Biometrics.Add(new Biometric(BiometricType.Minutiae, BiometricPosition.LeftThumb, BiometricInfo));

                // Encrypt.
                SessionKey key = new SessionKey();
                AuthDataContext authData = new AuthDataContext();
                authData.Encrypt(resident, key);

                // Request.
                AuthRequest request = new AuthRequest(authData);

                // Response.
                AuthResponse response = apiContext.GetResponse(request) as AuthResponse;

                Console.WriteLine("Is the resident authentic? " + response.IsAuthentic);
            }
            catch (ApiException error)
            { Console.WriteLine("ERROR. Code: " + error.ErrorCode); }
        }

    }
}
