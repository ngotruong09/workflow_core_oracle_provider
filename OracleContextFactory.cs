using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Persistence.EntityFramework.Interfaces;
using WorkflowCore.Persistence.EntityFramework.Services;

namespace WorkflowCore.Persistence.Oracle
{
    public class OracleContextFactory : IWorkflowDbContextFactory
    {
        private readonly string _connectionString;
        private readonly Action<DbConnection> _initAction;

        public OracleContextFactory(string connectionString, Action<DbConnection> initAction = null)
        {
            _connectionString = connectionString;
            _initAction = initAction;
        }

        public WorkflowDbContext Build()
        {
            var result = new OracleContext(_connectionString);
            _initAction?.Invoke(result.Database.GetDbConnection());

            return result;
        }
    }
}
