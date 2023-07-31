using Education.Application.EducationGroup;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.Application.EducationGroup.Tests;
using Education.ApplicationTests.EducationGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Education.ApplicationTests.EducationGroup.Queries.GetEducationGroups
{
    [TestClass()]
    public class GetEducationGroupsQueryTests
    {
        private Mock<EducationCacheHelper> mockEducationCacheHelper;
        private GetEducationGroupDummyInstance dummyInstance;
        [TestInitialize]
        public void Init()
        {
            mockEducationCacheHelper = new Mock<EducationCacheHelper>(MockBehavior.Strict);
            dummyInstance = new GetEducationGroupDummyInstance();
        }

        [TestMethod()]
        public void EducationGroupsCacheIsNull()
        {
            List<GetEducationGroupsResult.EducationGroup> educationGroups = null;
            mockEducationCacheHelper.Setup(i => i.GetCache().Result).Returns(educationGroups).Verifiable();
            Assert.IsNull(educationGroups);
            mockEducationCacheHelper.Setup(i => i.UpdateCache()).Verifiable();
            mockEducationCacheHelper.Setup(i => i.GetCache().Result).Returns(educationGroups).Verifiable();
        }

        [TestMethod()]
        public void EducationGroupsCacheIsNotNull()
        {
            List<GetEducationGroupsResult.EducationGroup> educationGroups = dummyInstance.GetDummyEducationGroups();
            mockEducationCacheHelper.Setup(i => i.GetCache().Result).Returns(educationGroups).Verifiable();
            Assert.IsNotNull(educationGroups);
        }
    }
}