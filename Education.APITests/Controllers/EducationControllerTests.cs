using Microsoft.VisualStudio.TestTools.UnitTesting;
using Education.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MediatR;
using Education.Application.EducationGroup.Commands;
using System.Threading;
using Education.Application.EducationGroup.Commands.SaveEducationGroup;

namespace Education.API.Controllers.Tests
{
    [TestClass()]
    public class EducationControllerTests
    {
        public Mock<IMediator> _mediator = new Mock<IMediator>();

        [TestMethod()]
        public void SaveEducationTest()
        {
            _mediator.Setup(m => m.Send(new SaveEducationGroupCommand() { }, default(CancellationToken))).Verifiable();

            //_mediator.Setup(m => m.Send(It.IsAny<SaveEducationGroupCommand>(), default(CancellationToken))).Verifiable("Notification was not sent.");

            //Assert.IsTrue();
        }

        [TestMethod()]
        public void GetEducationsTest()
        {
            Assert.Fail();
        }
    }
}