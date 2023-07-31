using AutoMapper;
using Education.Domain;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Education.Application.EducationGroup.Queries.GetEducationGroups
{
    public class GetEducationGroupsQuery : IRequestHandler<GetEducationGroupsFilter, GetEducationGroupsResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private readonly EducationCacheHelper educationCacheHelper;
        public GetEducationGroupsQuery(IUnitOfWork uow, ICacheService cache, IMapper mapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = mapper;
            educationCacheHelper = new EducationCacheHelper(_uow, _cache, _mapper);
        }
        public async Task<GetEducationGroupsResult> Handle(GetEducationGroupsFilter request, CancellationToken cancellationToken)
        {
            List<GetEducationGroupsResult.EducationGroup> educationGroups = null;

            var cachedEducationGroups = await educationCacheHelper.GetCache();
            if (cachedEducationGroups != null)
            {
                educationGroups = cachedEducationGroups;
            }
            else
            {
                await educationCacheHelper.UpdateCache();

                educationGroups = await educationCacheHelper.GetCache();
            }

            var result = new GetEducationGroupsResult()
            {
                EducationGroups = educationGroups
            };

            return result;
        }
    }
}
