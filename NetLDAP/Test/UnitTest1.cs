using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTestMethod()
        {
            var service = new WcfService.LDAPLoginService();
            service.Login(new WcfService.LoginRequest { Domain = "", Password = "1234", Username = "Manager" });
        }
    }
}
