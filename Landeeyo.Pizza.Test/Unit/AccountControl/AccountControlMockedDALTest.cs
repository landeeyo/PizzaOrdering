﻿using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlMockedDALTest
    {
        private IAccountControl _accountControl;
        private Mock<IDataAccess> _dataAccessMock;

        public AccountControlMockedDALTest()
        {
            _accountControl = new MockedAccountControl();
            _dataAccessMock = new Mock<IDataAccess>();
        }

        [Fact]
        public void AuthorizeUser()
        {
            //arrange
            string properLogin = "TestLogin";
            string properPassword = "TestPassword";
            string improperLogin = "dfjkhsdfk";
            string improperPassword = "fdjhsdfkf";

            _dataAccessMock
                .Setup(x => x.GetUsers)
                .Returns(new List<User>() { 
                    new User {
                        Login = properLogin, 
                        Password = properPassword
                    }}.AsQueryable());
            _accountControl.SetDataSource = _dataAccessMock.Object;

            //act
            var result1 = _accountControl.AuthorizeUser(properLogin, properPassword);
            var result2 = _accountControl.AuthorizeUser(improperLogin, improperPassword);

            //assert
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}