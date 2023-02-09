using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Persistence.EntityFramework.Services;

namespace WorkflowCore.Persistence.Oracle
{
    public static class ServiceCollectionExtensions
    {
        public static WorkflowOptions UseOracle(this WorkflowOptions options, string connectionString, bool canCreateDB, bool canMigrateDB, Action<DbConnection> initAction = null)
        {
            options.UsePersistence(sp => new EntityFrameworkPersistenceProvider(new OracleContextFactory(connectionString, initAction), canCreateDB, canMigrateDB));
            options.Services.AddTransient<IWorkflowPurger>(sp => new WorkflowPurger(new OracleContextFactory(connectionString, initAction)));
            return options;
        }
    }
}
