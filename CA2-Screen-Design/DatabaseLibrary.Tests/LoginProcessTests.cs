using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;
using Xunit;

namespace DatabaseLibrary.Tests
{
    public class LoginProcessTests
    {
        [Theory]
        //Username contains something & password contains something
        [InlineData("M", "m", true)]
        //Username is blank 
        [InlineData("", "m", false)]
        //Password is blank
        [InlineData("M", "", false)]
        //username & password both blank
        [InlineData("", "", false)]
        //username more than 30 characters
        [InlineData("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", "3", false)]
        //pasword more than 30 characters
        [InlineData("M", "3333333333333333333333333333333", false)]
        //username can have "-" symbol
        [InlineData("-user", "3", false)]
        public void ValidatedUserInput_StringShouldVerify(string username, string password, bool expected)
        {
            //Arrange
            LoginProcess loginProcess = new LoginProcess();
            
            //Act
            bool actual = loginProcess.ValidatedUserInput(username, password);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
