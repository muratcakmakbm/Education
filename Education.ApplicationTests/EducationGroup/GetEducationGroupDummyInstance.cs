using Education.Application;
using Education.Application.EducationGroup.Dto;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Education.ApplicationTests.EducationGroup
{
    public class GetEducationGroupDummyInstance
    {
        public List<tb_EducationGroup> GetDummy_tb_EducationGroup()
        {
            List<tb_EducationGroup> dummytbEducationGroups = new List<tb_EducationGroup>()
            {new tb_EducationGroup(){
                EducationGroupId = 1,
                EducationGroupName = "Test",
                EndDate = new DateTime(2023, 7, 28, 10, 12, 14),
                StartDate = new DateTime(2023, 7, 28, 10, 12, 14),
                Status = 1,
                Educations = new List<tb_Education>
                {
                new tb_Education()
                {
                EducationExplanation="Test Açıklaması",
                EducationGroupId=1,
                EducationId=1,
                EducationLink="https://www.youtube.com/watch?y=eZu3IUN1hAI",
                EducationName="Test"
                }
                } }
                };
            return dummytbEducationGroups;
        }

        public List<GetEducationGroupsResult.EducationGroup> GetDummyEducationGroups()
        {
            List<GetEducationGroupsResult.EducationGroup> dummyEducationGroups = new List<GetEducationGroupsResult.EducationGroup>()
            {new GetEducationGroupsResult.EducationGroup(){
                EducationGroupId = 1,
                EducationGroupName = "Test",
                EndDate = new DateTime(2023, 7, 28, 10, 12, 14),
                StartDate = new DateTime(2023, 7, 28, 10, 12, 14),
                Status = ((Status)1).ToString(),
                Educations = new List<EducationDto>
                {
                new EducationDto()
                {
                EducationExplanation="Test Açıklaması",
                EducationGroupId=1,
                EducationId=1,
                EducationLink="https://www.youtube.com/watch?y=eZu3IUN1hAI",
                EducationName="Test"
                }
                } }
                };

            return dummyEducationGroups;
        }

    }
}
