using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.WCFServiceReference;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LDAPLoginServiceClient();
            logTest(client);
            loginTest(client);
        }

        private static void logTest(LDAPLoginServiceClient client)
        {
            var logResponse = client.GetLogs();
            foreach (var item in logResponse.Logs)
            {
                Console.WriteLine(item.Username + " " + item.LoginDate);
            }
        }

        private static void loginTest(LDAPLoginServiceClient client)
        {
            var response = client.Login(new LoginRequest { Domain = "OGU-KARTALMAIN", Password = "***", Username = "ADMIN" });
            Console.WriteLine(response.Message);
            Console.ReadLine();
        }
    }
}
