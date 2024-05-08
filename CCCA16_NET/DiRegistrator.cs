﻿using CCCA16_NET.Infra.Database;
using CCCA16_NET.Infra.Gateway;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET
{
    public class DiRegistrator
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDbService, DbService>();
            services.AddTransient<IAccountRepository, AccountRepositoryInMemory>();
            services.AddTransient<IMailerGateway, MailerGateway>();
        }
    }
}
