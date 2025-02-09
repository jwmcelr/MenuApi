using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace JWTTokenGenerator
{
    public class JWTGenerator
    {
        public JWTGenerator() { }

        public string generateJWTToken(string certificateFilePath, string password, string signingCertSubjectName)
        {

            var certificate2Collection = new X509Certificate2Collection();
            certificate2Collection.Import(certificateFilePath, password, X509KeyStorageFlags.DefaultKeySet);

            // Print certs in file
            // var cert2 = certificate2Collection.Find(X509FindType.FindBySubjectName, signingCertSubjectName, true);
            var cert2 = certificate2Collection.Find(X509FindType.FindBySubjectName, signingCertSubjectName, false);

            Console.WriteLine(cert2 != null);

            

            if (certificate2Collection != null && certificate2Collection.Count == 1)
            {
                Console.WriteLine("Hello World3");
                //extract the RSA private key.
                var privateKey = certificate2Collection[0].GetRSAPrivateKey();
                var rsaSecurityKey = new RsaSecurityKey(privateKey);

                // Create signing credentials
                var signingCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256);


                var token = new JwtSecurityToken(
                    issuer: "CompanyX",
                    audience: "youraudience",
                    claims: new[] {
                      new Claim("username", "test")
                    },
                    expires: DateTime.Now.AddDays(365),
                    signingCredentials: signingCredentials);

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                Console.WriteLine(jwtToken);

                //initialise the header using the private key, and signing algorithm.
                /*
                var header = new JwtHeader(new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.EcdsaSha256));

                var token = new JwtSecurityToken(
                issuer: "yourissuer",
                audience: "youraudience",
                claims: new[] {
                  new Claim("sub", "user1")
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                */
            }

            Console.WriteLine("Hello World2");

            return "test";
        }

        public bool ValidateToken(string token, string certificateFilePath, string password, string signingCertSubjectName)
        {
            var certificate2Collection = new X509Certificate2Collection();
            certificate2Collection.Import(certificateFilePath, password, X509KeyStorageFlags.DefaultKeySet);
            var cert2 = certificate2Collection.Find(X509FindType.FindBySubjectName, signingCertSubjectName, false);

            if (cert2 == null || cert2.Count == 0) return false;

            var rsaSecurityKey = new RsaSecurityKey(cert2[0].GetRSAPublicKey());
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "CompanyX",
                ValidateAudience = true,
                ValidAudience = "youraudience",
                ValidateLifetime = true,
                IssuerSigningKey = rsaSecurityKey
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
