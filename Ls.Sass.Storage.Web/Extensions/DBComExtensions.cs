using Ls.Sass.Storage;
using Ls.Sass.Storage.Web;
using Ls.Sass.Storage.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DBComExtensions
    {
        public static IServiceCollection AddStorageService(this IServiceCollection services, IConfiguration configuration)
        {
            var sugarOptions = new DbConnectionConfig
            {
                ConnectionString = $"{configuration["ConnectionString"]};ApplicationName={Assembly.GetEntryAssembly().GetName().Name}",
                PrintLog = true,
                DbType = DbType.PostgreSQL,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            };

            services.AddScoped<ISqlSugarClient>(sp =>
            {
                var sugarClient = new SqlSugarClient(sugarOptions)
                {
                    Ado = { CommandTimeOut = 120 },
                    Aop =
                    {
                        OnLogExecuting = (sql, pars) =>
                        {
                            if (sugarOptions.PrintLog)
                            {
                                Console.WriteLine(sql + "\r\n" + JsonSerializer.Serialize(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                                Console.WriteLine();
                            }
                        }
                    }
                };

                return sugarClient;
            });

            services.AddTransient<IDBCom, DBCom>();

            services.AddDbContext<FonourDbContext>(options => options.UseNpgsql($"{configuration["ConnectionString"]};ApplicationName={Assembly.GetEntryAssembly().GetName().Name}"));

            return services;
        }
    }
}
