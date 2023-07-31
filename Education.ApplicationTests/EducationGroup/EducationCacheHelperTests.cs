using AutoMapper;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.ApplicationTests.EducationGroup;
using Education.Domain;
using Education.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Education.Application.EducationGroup.Tests
{
    [TestClass()]
    public class EducationCacheHelperTests
    {
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<ICacheService> mockCacheService;
        private Mock<IMapper> mockMapper;
        private readonly GetEducationGroupDummyInstance getDummyInstance;
        private string educationGroupCacheKey = Constant.educationGroupCacheKey;
        public EducationCacheHelperTests()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            mockCacheService = new Mock<ICacheService>(MockBehavior.Strict);
            mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            getDummyInstance = new GetEducationGroupDummyInstance();
        }

        [TestMethod()]
        public void UpdateCacheTest()
        {

            List<tb_EducationGroup> tbEducationGroups = getDummyInstance.GetDummy_tb_EducationGroup();
            List<GetEducationGroupsResult.EducationGroup> educationGroups = getDummyInstance.GetDummyEducationGroups();
            mockUnitOfWork
                 .Setup(i => i.EducationGroup.GetList(null).Result)
                .Returns(tbEducationGroups);

            mockMapper.Setup(i => i.Map<List<GetEducationGroupsResult.EducationGroup>>(tbEducationGroups)).Returns(educationGroups);

            mockCacheService.Setup(i => i.Remove(educationGroupCacheKey)).Verifiable();

            var json = JsonConvert.SerializeObject(educationGroups);

            mockCacheService.Setup(i => i.Add(educationGroupCacheKey, json, new TimeSpan(00, 30, 0))).Verifiable();

            GetCacheTest();
        }

      

        [TestMethod()]
        public void GetCacheTest()
        {
            string dummyJson = "";
            mockCacheService.Setup(i => i.Get<string>(educationGroupCacheKey)).Returns(dummyJson).Verifiable();
            Assert.IsNotNull(dummyJson);
            var educationGroups = JsonConvert.DeserializeObject<List<GetEducationGroupsResult>>(dummyJson);
        }
    }
}