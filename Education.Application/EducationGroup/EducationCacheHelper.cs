using AutoMapper;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.Application.EducationGroup
{
    public class EducationCacheHelper
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private readonly string cacheKeyName = Constant.educationGroupCacheKey;
        public EducationCacheHelper(IUnitOfWork uow, ICacheService cache, IMapper maapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = maapper;
        }
        public async virtual Task UpdateCache()
        {
            List<GetEducationGroupsResult.EducationGroup> educationGroups = null;

            var educationGroups_ = await _uow.EducationGroup.GetList();


            educationGroups = _mapper.Map<List<GetEducationGroupsResult.EducationGroup>>(educationGroups_);

            _cache.Remove(cacheKeyName);

            var json = JsonConvert.SerializeObject(educationGroups);
            var minute = Constant.EducationGroupCacheExpireMinute;
            _cache.Add(cacheKeyName, json, new TimeSpan(00, minute, 0));
        }

        public async virtual Task<List<GetEducationGroupsResult.EducationGroup>> GetCache()
        {
            var json = _cache.Get<string>(cacheKeyName);

            List<GetEducationGroupsResult.EducationGroup> educationGroups = null;
            if (json != null)
            {
                educationGroups = JsonConvert.DeserializeObject<List<GetEducationGroupsResult.EducationGroup>>(json);
            }
            return educationGroups;
        }
    }
}
