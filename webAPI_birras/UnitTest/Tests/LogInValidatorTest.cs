using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using webAPI_birras.Controllers.Validators;
using webAPI_birras.Models;
using webAPI_birras.Services;

namespace webAPI_birras_UnitTest.Tests
{
    [TestClass]
    public class LogInValidatorTest
    {
        [TestMethod]
        public void UserValidator_cantLogin() 
        {
            User user = new User();
            string msg = UserValidator.LoginValidator(user, "");

            Assert.IsTrue(msg == UserValidatorMessage.cantLogin);        
        }
    }
}
