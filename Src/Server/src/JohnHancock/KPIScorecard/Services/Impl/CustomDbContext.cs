/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Data.Entity;
using JohnHancock.KPIScorecard.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JohnHancock.KPIScorecard.Impl
{
    /// <summary>
    /// This class provides access to the database.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class CustomDbContext : DbContext
    {
        /// <summary>
        /// The connection string name to use when creating <see cref="CustomDbContext"/> instance.
        /// </summary>
        private const string ConnectionStringName = "KSTConnectionString";

        /// <summary>
        /// Gets or sets the business unit set.
        /// </summary>
        /// <value>
        /// The business unit set.
        /// </value>
        public DbSet<BusinessUnit> BusinessUnitSet { get; set; }

        /// <summary>
        /// Gets or sets the month value set.
        /// </summary>
        /// <value>
        /// The month value set.
        /// </value>
        public DbSet<MonthValue> MonthValueSet { get; set; }

        /// <summary>
        /// Gets or sets the year value set.
        /// </summary>
        /// <value>
        /// The year value set.
        /// </value>
        public DbSet<YearValue> YearValueSet { get; set; }

        /// <summary>
        /// Gets or sets the business unit KPI scorecard set.
        /// </summary>
        /// <value>
        /// The business unit KPI scorecard set.
        /// </value>
        public DbSet<BusinessUnitKPIScorecard> BusinessUnitKPIScorecardSet { get; set; }

        /// <summary>
        /// Gets or sets the operational incident set.
        /// </summary>
        /// <value>
        /// The operational incident set.
        /// </value>
        public DbSet<OperationalIncident> OperationalIncidentSet { get; set; }

        /// <summary>
        /// Gets or sets the audit finding set.
        /// </summary>
        /// <value>
        /// The audit finding set.
        /// </value>
        public DbSet<AuditFinding> AuditFindingSet { get; set; }

        /// <summary>
        /// Gets or sets the privacy incident set.
        /// </summary>
        /// <value>
        /// The privacy incident set.
        /// </value>
        public DbSet<PrivacyIncident> PrivacyIncidentSet { get; set; }

        /// <summary>
        /// Gets or sets the audit finding impact value set.
        /// </summary>
        /// <value>
        /// The audit finding impact value set.
        /// </value>
        public DbSet<AuditFindingImpactValue> AuditFindingImpactValueSet { get; set; }

        /// <summary>
        /// Gets or sets the audit finding status value set.
        /// </summary>
        /// <value>
        /// The audit finding status value set.
        /// </value>
        public DbSet<AuditFindingStatusValue> AuditFindingStatusValueSet { get; set; }

        /// <summary>
        /// Gets or sets the audit finding reported to GORM value set.
        /// </summary>
        /// <value>
        /// The audit finding reported to GORM value set.
        /// </value>
        public DbSet<AuditFindingReportedToGORMValue> AuditFindingReportedToGORMValueSet { get; set; }

        /// <summary>
        /// Gets or sets the audit finding source value.
        /// </summary>
        /// <value>
        /// The audit finding source value.
        /// </value>
        public DbSet<AuditFindingSourceValue> AuditFindingSourceValue { get; set; }

        /// <summary>
        /// Gets or sets the audit finding root cause value set.
        /// </summary>
        /// <value>
        /// The audit finding root cause value set.
        /// </value>
        public DbSet<AuditFindingRootCauseValue> AuditFindingRootCauseValueSet { get; set; }

        /// <summary>
        /// Gets or sets the status value set.
        /// </summary>
        /// <value>
        /// The status value set.
        /// </value>
        public DbSet<StatusValue> StatusValueSet { get; set; }

        /// <summary>
        /// Gets or sets the volume type value set.
        /// </summary>
        /// <value>
        /// The volume type value set.
        /// </value>
        public DbSet<VolumeTypeValue> VolumeTypeValueSet { get; set; }

        /// <summary>
        /// Gets or sets the operational incident source value set.
        /// </summary>
        /// <value>
        /// The operational incident source value set.
        /// </value>
        public DbSet<OperationalIncidentSourceValue> OperationalIncidentSourceValueSet { get; set; }

        /// <summary>
        /// Gets or sets the operational incident root cause value set.
        /// </summary>
        /// <value>
        /// The operational incident root cause value set.
        /// </value>
        public DbSet<OperationalIncidentRootCauseValue> OperationalIncidentRootCauseValueSet { get; set; }

        /// <summary>
        /// Gets or sets the operational incident status value set.
        /// </summary>
        /// <value>
        /// The operational incident status value set.
        /// </value>
        public DbSet<OperationalIncidentStatusValue> OperationalIncidentStatusValueSet { get; set; }

        /// <summary>
        /// Gets or sets the operational incident impact value set.
        /// </summary>
        /// <value>
        /// The operational incident impact value set.
        /// </value>
        public DbSet<OperationalIncidentImpactValue> OperationalIncidentImpactValueSet { get; set; }

        /// <summary>
        /// Gets or sets the operational incident reported to GORM value set.
        /// </summary>
        /// <value>
        /// The operational incident reported to GORM value set.
        /// </value>
        public DbSet<OperationalIncidentReportedToGORMValue> OperationalIncidentReportedToGORMValueSet { get; set; }

        /// <summary>
        /// Gets or sets the privacy incident mitigation code value set.
        /// </summary>
        /// <value>
        /// The privacy incident mitigation code value set.
        /// </value>
        public DbSet<PrivacyIncidentMitigationCodeValue> PrivacyIncidentMitigationCodeValueSet { get; set; }

        /// <summary>
        /// Gets or sets the privacy incident root cause value set.
        /// </summary>
        /// <value>
        /// The privacy incident root cause value set.
        /// </value>
        public DbSet<PrivacyIncidentRootCauseValue> PrivacyIncidentRootCauseValueSet { get; set; }

        /// <summary>
        /// Gets or sets the privacy incident status value set.
        /// </summary>
        /// <value>
        /// The privacy incident status value set.
        /// </value>
        public DbSet<PrivacyIncidentStatusValue> PrivacyIncidentStatusValueSet { get; set; }

        /// <summary>
        /// Gets or sets the privacy incident type value set.
        /// </summary>
        /// <value>
        /// The privacy incident type value set.
        /// </value>
        public DbSet<PrivacyIncidentTypeValue> PrivacyIncidentTypeValueSet { get; set; }

        /// <summary>
        /// Gets or sets the low performance reason set.
        /// </summary>
        /// <value>
        /// The low performance reason set.
        /// </value>
        public DbSet<LowPerformanceReason> LowPerformanceReasonSet { get; set; }

        /// <summary>
        /// Gets or sets the KPI volume score set.
        /// </summary>
        /// <value>
        /// The KPI volume score set.
        /// </value>
        public DbSet<KPIVolumeScore> KPIVolumeScoreSet { get; set; }

        /// <summary>
        /// Gets or sets the KPI scorecard item set.
        /// </summary>
        /// <value>
        /// The KPI scorecard item set.
        /// </value>
        public DbSet<KPIScorecardItem> KPIScorecardItemSet { get; set; }

        /// <summary>
        /// Gets or sets the KPI score set.
        /// </summary>
        /// <value>
        /// The KPI score set.
        /// </value>
        public DbSet<KPIScore> KPIScoreSet { get; set; }

        /// <summary>
        /// Gets or sets the financial exposure value set.
        /// </summary>
        /// <value>
        /// The financial exposure value set.
        /// </value>
        public DbSet<FinancialExposureValue> FinancialExposureValueSet { get; set; }

        /// <summary>
        /// Gets or sets the decimal or percentage value set.
        /// </summary>
        /// <value>
        /// The decimal or percentage value set.
        /// </value>
        public DbSet<DecimalOrPercentageValue> DecimalOrPercentageValueSet { get; set; }

        /// <summary>
        /// Initializes the <see cref="CustomDbContext"/> class.
        /// </summary>
        static CustomDbContext()
        {
            Database.SetInitializer<CustomDbContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDbContext"/> class.
        /// </summary>
        public CustomDbContext()
            : base(ConnectionStringName)
        {
        }

        /// <summary>
        /// Customizes mappings between entity model and database.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // add KST_ prefix to all types
            modelBuilder.Types().Configure(entity => entity.ToTable("KST_" + entity.ClrType.Name));

            // configure many to many relationships
            modelBuilder.Entity<AuditFinding>().HasMany(x => x.Impact)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("AuditFindingId");
                    x.MapRightKey("AuditFindingImpactValueId");
                    x.ToTable("KST_AuditFinding_AuditFindingImpactValue");
                });

            modelBuilder.Entity<BusinessUnitKPIScorecard>().HasMany(x => x.OperationPerformanceScores)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("BusinessUnitKPIScorecardId");
                    x.MapRightKey("KPIVolumeScoreId");
                    x.ToTable("KST_BusinessUnitKPIScorecard_OperationPerformanceScore");
                });

            modelBuilder.Entity<BusinessUnitKPIScorecard>().HasMany(x => x.FinancialIndicatorScores)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("BusinessUnitKPIScorecardId");
                    x.MapRightKey("KPIScoreId");
                    x.ToTable("KST_BusinessUnitKPIScorecard_FinancialIndicatorScore");
                });

            modelBuilder.Entity<BusinessUnitKPIScorecard>().HasMany(x => x.BusinessContinuityPlanningScores)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("BusinessUnitKPIScorecardId");
                    x.MapRightKey("KPIScoreId");
                    x.ToTable("KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore");
                });

            modelBuilder.Entity<BusinessUnitKPIScorecard>().HasMany(x => x.SecurityScores)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("BusinessUnitKPIScorecardId");
                    x.MapRightKey("KPIScoreId");
                    x.ToTable("KST_BusinessUnitKPIScorecard_SecurityScore");
                });

            modelBuilder.Entity<BusinessUnitKPIScorecard>().HasMany(x => x.ConcentrationRiskScores)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("BusinessUnitKPIScorecardId");
                    x.MapRightKey("KPIScoreId");
                    x.ToTable("KST_BusinessUnitKPIScorecard_ConcentrationRiskScore");
                });

            modelBuilder.Entity<KPIScore>().HasMany(x => x.LowPerformanceReasons)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("KPIScoreId");
                    x.MapRightKey("LowPerformanceReasonId");
                    x.ToTable("KST_KPIScore_LowPerformanceReason");
                });

            modelBuilder.Entity<OperationalIncident>().HasMany(x => x.Impact)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("OperationalIncidentId");
                    x.MapRightKey("OperationalIncidentImpactValueId");
                    x.ToTable("KST_OperationalIncident_OperationalIncidentImpactValue");
                });

            modelBuilder.Entity<PrivacyIncident>().HasMany(x => x.MitigationCode)
                .WithMany().Map(x =>
                {
                    x.MapLeftKey("PrivacyIncidentId");
                    x.MapRightKey("PrivacyIncidentMitigationCodeValueId");
                    x.ToTable("KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
