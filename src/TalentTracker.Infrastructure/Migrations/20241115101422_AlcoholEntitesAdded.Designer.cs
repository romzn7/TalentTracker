﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentTracker.Infrastructure;

#nullable disable

namespace TalentTracker.Infrastructure.Migrations
{
    [DbContext(typeof(TalentTrackerDBContext))]
    [Migration("20241115101422_AlcoholEntitesAdded")]
    partial class AlcoholEntitesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("candidateseq", "tt")
                .IncrementsBy(10);

            modelBuilder.HasSequence("eventlogseq", "tt")
                .IncrementsBy(10);

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Candidates.Entities.Candidate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"), "candidateseq", "tt");

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CandidateGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreeTextComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeIntervalToCall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Candidates", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.Container", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ContainerGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Containers", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("ContainerId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkProcessCount")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkProcessGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("WorkProcesses", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcessDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAlcohol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("WaterChangeCount")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkProcessDetailGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("WorkProcessID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkProcessID");

                    b.ToTable("WorkProcessDetails", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcessIngredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IngredientID")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("WorkProcessID")
                        .HasColumnType("bigint");

                    b.Property<long>("WorkProcessId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("WorkProcessIngredientGUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngredientID");

                    b.HasIndex("WorkProcessID");

                    b.HasIndex("WorkProcessId");

                    b.ToTable("WorkProcessIngredients", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Enumerations.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Enumerations.MeasurementUnitType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MeasurementUnitTypes", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Events.Entities.EventLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"), "eventlogseq", "tt");

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("EventLogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventLogGUID")
                        .IsUnique();

                    b.HasIndex("EventTypeId");

                    b.ToTable("EventLogs", "tt");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Events.Enumerations.EventType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes", "tt");
                });

            modelBuilder.Entity("TalentTracker.Shared.DomainDesign.DbContextBase<TalentTracker.Infrastructure.TalentTrackerDBContext>+StringSplitResult", b =>
                {
                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("StringSplitResult", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Candidates.Entities.Candidate", b =>
                {
                    b.OwnsOne("TalentTracker.Domain.Aggregates.Candidates.ValueObjects.SocialMediaLinks", "SocialMediaLinks", b1 =>
                        {
                            b1.Property<long>("CandidateId")
                                .HasColumnType("bigint");

                            b1.Property<string>("GithubProfileUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LinkedinProfileUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CandidateId");

                            b1.ToTable("Candidates", "tt");

                            b1.WithOwner()
                                .HasForeignKey("CandidateId");
                        });

                    b.Navigation("SocialMediaLinks")
                        .IsRequired();
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcess", b =>
                {
                    b.HasOne("TalentTracker.Domain.Aggregates.Container.Entities.Container", "Container")
                        .WithMany("WorkProcesses")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcessDetail", b =>
                {
                    b.HasOne("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcess", "WorkProcess")
                        .WithMany("WorkProcessDetails")
                        .HasForeignKey("WorkProcessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkProcess");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcessIngredient", b =>
                {
                    b.HasOne("TalentTracker.Domain.Aggregates.Container.Enumerations.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcess", null)
                        .WithMany("WorkProcessIngredients")
                        .HasForeignKey("WorkProcessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcess", "WorkProcess")
                        .WithMany()
                        .HasForeignKey("WorkProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TalentTracker.Domain.Aggregates.Container.ValueObjects.MeasurementUnit", "MeasurementUnit", b1 =>
                        {
                            b1.Property<long>("WorkProcessIngredientId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WorkProcessIngredientId");

                            b1.ToTable("WorkProcessIngredients", "tt");

                            b1.WithOwner()
                                .HasForeignKey("WorkProcessIngredientId");
                        });

                    b.OwnsOne("TalentTracker.Domain.Aggregates.Container.ValueObjects.Quantity", "Quantity", b1 =>
                        {
                            b1.Property<long>("WorkProcessIngredientId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Value");

                            b1.HasKey("WorkProcessIngredientId");

                            b1.ToTable("WorkProcessIngredients", "tt");

                            b1.WithOwner()
                                .HasForeignKey("WorkProcessIngredientId");
                        });

                    b.Navigation("Ingredient");

                    b.Navigation("MeasurementUnit")
                        .IsRequired();

                    b.Navigation("Quantity")
                        .IsRequired();

                    b.Navigation("WorkProcess");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Events.Entities.EventLog", b =>
                {
                    b.HasOne("TalentTracker.Domain.Aggregates.Events.Enumerations.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.Container", b =>
                {
                    b.Navigation("WorkProcesses");
                });

            modelBuilder.Entity("TalentTracker.Domain.Aggregates.Container.Entities.WorkProcess", b =>
                {
                    b.Navigation("WorkProcessDetails");

                    b.Navigation("WorkProcessIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
