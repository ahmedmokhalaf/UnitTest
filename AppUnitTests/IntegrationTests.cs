using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using App;
using FluentAssertions;


namespace UnitTestProject1
{           
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Add_User_WithGoodUser_Should_Save()
        {
            User user = new User {
            Name = "Lol",
            Email = "a@a.a231",
            BirthDate = new DateTime(1991,12,13)
            };

            AccessLayer access = new AccessLayer(new WeightContext());
            access.AddUser(user);
            User userToFind = access.GetUser("Lol");
            userToFind.Should().BeEquivalentTo(user);
           
        }

		[TestMethod]
		public void Get_User_WithGoodUser_Should_Return_User()
		{
            AccessLayer access = new AccessLayer(new WeightContext());
            User userToFind = access.GetUser("Lola");

            userToFind.Should()
                .NotBeNull()
                .And.BeOfType<User>();
        }
    }
}
