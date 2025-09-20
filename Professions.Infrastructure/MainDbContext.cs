using Microsoft.EntityFrameworkCore;
using Professions.Infrastructure.Entities;

namespace Professions.Infrastructure;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> opt) : base(opt)
    {
    }

    public DbSet<ProfessionEntity> Professions { get; set; }
    public DbSet<SkillEntity> Skills { get; set; }
    public DbSet<IndustryEntity> Industries { get; set; }
    public DbSet<ProfessionSkillEntity> ProfessionSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseEntity>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("id");
            builder.UseTpcMappingStrategy();
        });

        modelBuilder.Entity<IndustryEntity>(builder =>
        {
            builder.ToTable("industries");
            builder.Property(x => x.IndustryName).IsRequired()
                .HasMaxLength(50).HasColumnName("industry_name");

            builder.HasMany(x => x.Professions).WithOne(x => x.Industry)
                .HasForeignKey(x => x.IndustryId).IsRequired();

            builder.HasIndex(x => x.IndustryName).IsUnique().HasDatabaseName("INX_INDUSTRY_NAME");
        });

        modelBuilder.Entity<ProfessionSkillEntity>(builder =>
        {
            builder.ToTable("profession_skills");
            builder.HasKey(t => new { t.SkillId, t.ProfessionId, t.Level });

            builder
                .HasOne(sc => sc.Skill)
                .WithMany(s => s.Professions)
                .HasForeignKey(sc => sc.SkillId);

            builder
                .HasOne(sc => sc.Profession)
                .WithMany(c => c.Skills)
                .HasForeignKey(sc => sc.ProfessionId);
        });


        modelBuilder.Entity<ProfessionEntity>(builder =>
        {
            builder.ToTable("professions");
            builder.Property(x => x.ProfessionName).IsRequired()
                .HasMaxLength(50).HasColumnName("profession_name");

            builder.Property(x => x.IndustryId).IsRequired().HasColumnName("industry_id");
            builder.HasIndex(x => x.ProfessionName).IsUnique().HasDatabaseName("INX_PROFESSION_NAME");
        });

        modelBuilder.Entity<SkillEntity>(builder =>
        {
            builder.ToTable("skills");
            builder.Property(x => x.SkillName).IsRequired()
                .HasMaxLength(30).HasColumnName("skill_name");

            builder.HasIndex(x => x.SkillName).IsUnique().HasDatabaseName("INX_SKILL_NAME");
        });

        modelBuilder.SetDefaultData();
    }
}