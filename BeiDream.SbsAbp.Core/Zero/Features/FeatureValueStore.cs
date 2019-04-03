using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using BeiDream.SbsAbp.Zero.Authorization.Users;
using BeiDream.SbsAbp.Zero.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
    {
        public FeatureValueStore(
            ICacheManager cacheManager,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            IRepository<Tenant> tenantRepository,
            IRepository<EditionFeatureSetting, long> editionFeatureRepository,
            IFeatureManager featureManager, 
            IUnitOfWorkManager unitOfWorkManager
            ) 
            : base(cacheManager, 
                  tenantFeatureRepository,
                  tenantRepository, 
                  editionFeatureRepository, 
                  featureManager,
                  unitOfWorkManager)
        {
        }
    }
}
