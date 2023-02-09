using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowCore.Persistence.Oracle
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<OracleContext>
    {
        public OracleContext CreateDbContext(string[] args)
        {
            return new OracleContext(@"DATA SOURCE=10.84.1.233:1521/ebao;PASSWORD=email233pro;PERSIST SECURITY INFO=True;USER ID=HLV_EMAIL_PRO");
        }
    }
}
