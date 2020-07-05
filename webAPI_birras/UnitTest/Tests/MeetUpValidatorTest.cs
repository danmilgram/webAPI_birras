using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using webAPI_birras.Controllers.Validators;
using webAPI_birras.Models;
using webAPI_birras.Models.requestModels;
using webAPI_birras.Services;

namespace webAPI_birras_UnitTest.Tests
{
    [TestClass]
    public class MeetUpValidatorTest
    {
        [TestMethod]
        public void ValidateFin_test1()
        {
            MeetUp meet = new MeetUp();

            meet.date = DateTime.Now.AddDays(2);
            bool fin = MeetUpValidator.ValidateFin(meet);
            Assert.IsFalse(fin);
        }

        public void ValidateFin_test2()
        {
            MeetUp meet = new MeetUp();

            meet.date = DateTime.Now.AddDays(-2);
            bool fin = MeetUpValidator.ValidateFin(meet);
            Assert.IsTrue(fin);
        }      

        [TestMethod]
        public void MeetUpValidation_testNoGuests()
        {
            MeetUp meetUp = new MeetUp();
            List<Guest> guestList = new List<Guest>();

            meetUp.guests = guestList;

            string msg = MeetUpValidator.ValidateGuest(meetUp);

            Assert.IsTrue(msg == MeetUpValidatorMessage.noGuests);
        }

    }
}
