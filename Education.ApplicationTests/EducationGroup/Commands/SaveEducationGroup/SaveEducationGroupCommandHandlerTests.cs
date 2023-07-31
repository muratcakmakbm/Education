using AutoMapper;
using Education.Application.EducationGroup;
using Education.Application.EducationGroup.Commands.SaveEducationGroup;
using Education.Application.EducationGroup.Tests;
using Education.ApplicationTests.EducationGroup;
using Education.Domain;
using Education.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Education.ApplicationTests.EducationGroup.Commands.SaveEducationGroup
{
    [TestClass()]
    public class SaveEducationGroupCommandHandlerTests
    {
        private Mock<IEducationGroupRepository> mockRepository;
        private Mock<ICacheService> mockCacheService;
        private Mock<IMapper> mockMapper;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<EducationCacheHelper> mockEducationCacheHelper;
        private GetEducationGroupDummyInstance getDummyInstance;
        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IEducationGroupRepository>(MockBehavior.Strict);
            mockCacheService = new Mock<ICacheService>(MockBehavior.Strict);
            mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockEducationCacheHelper = new Mock<EducationCacheHelper>(MockBehavior.Strict);
            mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            getDummyInstance = new GetEducationGroupDummyInstance();
        }

        [TestMethod()]
        public void UpdateEducationGroupCommandHandlerTest()
        {
            GetEducationGroup();

            mockUnitOfWork.Setup(i => i.TransactionHelper.BeginTransaction());
            int? dummyEducationGroupId = 1;
            Assert.IsNotNull(dummyEducationGroupId);
            mockUnitOfWork.Setup(i => i.EducationGroup.Update(It.IsAny<tb_EducationGroup>())).Verifiable();
            mockUnitOfWork.Setup(i => i.SaveChangesAsync());
            mockUnitOfWork.Setup(i => i.TransactionHelper.Complete());
            mockEducationCacheHelper.Setup(i => i.UpdateCache()).Verifiable();
        }

        [TestMethod()]
        public void AddEducationGroupCommandHandlerTest()
        {
            GetEducationGroup();

            mockUnitOfWork.Setup(i => i.TransactionHelper.BeginTransaction());
            int? educationGroupId = null;
            Assert.IsNull(educationGroupId);
            mockUnitOfWork.Setup(i => i.EducationGroup.Add(It.IsAny<tb_EducationGroup>())).Verifiable();
            mockUnitOfWork.Setup(i => i.SaveChangesAsync());
            mockUnitOfWork.Setup(i => i.TransactionHelper.Complete());
            mockEducationCacheHelper.Setup(i => i.UpdateCache()).Verifiable();
        }

        [TestMethod()]
        public void GetEducationGroup()
        {
            int? dummyEducationGroupId = 1;

            tb_EducationGroup educationGroup = getDummyInstance.GetDummy_tb_EducationGroup().FirstOrDefault();

            Assert.IsNotNull(dummyEducationGroupId);

            mockRepository.Setup(i => i.GetById(dummyEducationGroupId.Value).Result).Returns(educationGroup).Verifiable();

            mockMapper.Setup(i => i.Map(It.IsAny<SaveEducationGroupCommand>(), educationGroup)).Verifiable();
        }
    }
}