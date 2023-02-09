using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Persistence.EntityFramework.Services;
using WorkflowCore.Persistence.EntityFramework.Models;

namespace WorkflowCore.Persistence.Oracle
{
    public class OracleContext : WorkflowDbContext
    {
        private readonly string _connectionString;
        private const string DbTablePrefix = "WF_";
        private const string DbSchema = "HLV_EMAIL_PRO";
        public OracleContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseOracle(_connectionString, db => db.UseOracleSQLCompatibility("11"));
        }

        protected override void ConfigureSubscriptionStorage(EntityTypeBuilder<PersistedSubscription> builder)
        {
            builder.ToTable(DbTablePrefix + "SUBSCRIPTION", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.SubscriptionId).HasColumnName("SUBSCRIPTIONID");
            builder.Property(x => x.WorkflowId).HasColumnName("WORKFLOWID");
            builder.Property(x => x.StepId).HasColumnName("STEPID");
            builder.Property(x => x.ExecutionPointerId).HasColumnName("EXECUTIONPOINTERID");
            builder.Property(x => x.EventName).HasColumnName("EVENTNAME");
            builder.Property(x => x.EventKey).HasColumnName("EVENTKEY");
            builder.Property(x => x.SubscribeAsOf).HasColumnName("SUBSCRIBEASOF");
            builder.Property(x => x.SubscriptionData).HasColumnName("SUBSCRIPTIONDATA");
            builder.Property(x => x.ExternalToken).HasColumnName("EXTERNALTOKEN");
            builder.Property(x => x.ExternalWorkerId).HasColumnName("EXTERNALWORKERID");
            builder.Property(x => x.ExternalTokenExpiry).HasColumnName("EXTERNALTOKENEXPIRY");
        }

        protected override void ConfigureWorkflowStorage(EntityTypeBuilder<PersistedWorkflow> builder)
        {
            builder.ToTable(DbTablePrefix + "WORKFLOW", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.InstanceId).HasColumnName("INSTANCEID");
            builder.Property(x => x.WorkflowDefinitionId).HasColumnName("WORKFLOWDEFINITIONID");
            builder.Property(x => x.Version).HasColumnName("VERSION");
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION");
            builder.Property(x => x.Reference).HasColumnName("REFERENCE");
            builder.Property(x => x.NextExecution).HasColumnName("NEXTEXECUTION");
            builder.Property(x => x.Data).HasColumnName("DATAVALUE");
            builder.Property(x => x.CreateTime).HasColumnName("CREATETIME");
            builder.Property(x => x.CompleteTime).HasColumnName("COMPLETETIME");
            builder.Property(x => x.Status).HasColumnName("STATUS");
        }

        protected override void ConfigureExecutionPointerStorage(EntityTypeBuilder<PersistedExecutionPointer> builder)
        {
            builder.ToTable(DbTablePrefix + "EXECUTIONPOINTER", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.WorkflowId).HasColumnName("WORKFLOWID");
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.StepId).HasColumnName("STEPID");
            builder.Property(x => x.Active).HasColumnName("ACTIVE");
            builder.Property(x => x.SleepUntil).HasColumnName("SLEEPUNTIL");
            builder.Property(x => x.PersistenceData).HasColumnName("PERSISTENCEDATA");
            builder.Property(x => x.StartTime).HasColumnName("STARTTIME");
            builder.Property(x => x.EndTime).HasColumnName("ENDTIME");
            builder.Property(x => x.EventName).HasColumnName("EVENTNAME");
            builder.Property(x => x.EventKey).HasColumnName("EVENTKEY");
            builder.Property(x => x.EventPublished).HasColumnName("EVENTPUBLISHED");
            builder.Property(x => x.EventData).HasColumnName("EVENTDATA");
            builder.Property(x => x.StepName).HasColumnName("STEPNAME");
            builder.Property(x => x.RetryCount).HasColumnName("RETRYCOUNT");
            builder.Property(x => x.Children).HasColumnName("CHILDREN");
            builder.Property(x => x.ContextItem).HasColumnName("CONTEXTITEM");
            builder.Property(x => x.PredecessorId).HasColumnName("PREDECESSORID");
            builder.Property(x => x.Outcome).HasColumnName("OUTCOME");
            builder.Property(x => x.Status).HasColumnName("STATUS");
            builder.Property(x => x.Scope).HasColumnName("SCOPE");
        }

        protected override void ConfigureExecutionErrorStorage(EntityTypeBuilder<PersistedExecutionError> builder)
        {
            builder.ToTable(DbTablePrefix + "EXECUTIONERROR", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.WorkflowId).HasColumnName("WORKFLOWID");
            builder.Property(x => x.ExecutionPointerId).HasColumnName("EXECUTIONPOINTERID");
            builder.Property(x => x.ErrorTime).HasColumnName("ERRORTIME");
            builder.Property(x => x.Message).HasColumnName("MESSAGE");
        }

        protected override void ConfigureExetensionAttributeStorage(EntityTypeBuilder<PersistedExtensionAttribute> builder)
        {
            builder.ToTable(DbTablePrefix + "EXTENSIONATTRIBUTE", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.ExecutionPointerId).HasColumnName("EXECUTIONPOINTERID");
            builder.Property(x => x.AttributeKey).HasColumnName("ATTRIBUTEKEY");
            builder.Property(x => x.AttributeValue).HasColumnName("ATTRIBUTEVALUE");
        }

        protected override void ConfigureEventStorage(EntityTypeBuilder<PersistedEvent> builder)
        {
            builder.ToTable(DbTablePrefix + "EVENT", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.EventId).HasColumnName("EVENTID");
            builder.Property(x => x.EventName).HasColumnName("EVENTNAME");
            builder.Property(x => x.EventKey).HasColumnName("EVENTKEY");
            builder.Property(x => x.EventData).HasColumnName("EVENTDATA");
            builder.Property(x => x.EventTime).HasColumnName("EVENTTIME");
            builder.Property(x => x.IsProcessed).HasColumnName("ISPROCESSED");
        }

        protected override void ConfigureScheduledCommandStorage(EntityTypeBuilder<PersistedScheduledCommand> builder)
        {
            builder.ToTable(DbTablePrefix + "SCHEDULEDCOMMAND", DbSchema);
            builder.Property(x => x.PersistenceId).UseIdentityColumn();
            builder.Property(x => x.PersistenceId).HasColumnName("PERSISTENCEID");
            builder.Property(x => x.CommandName).HasColumnName("COMMANDNAME");
            builder.Property(x => x.Data).HasColumnName("DATAVALUE");
            builder.Property(x => x.ExecuteTime).HasColumnName("EXECUTETIME");
        }
    }
}
