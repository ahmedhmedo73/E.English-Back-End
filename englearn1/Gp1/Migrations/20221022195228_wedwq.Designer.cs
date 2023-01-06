﻿// <auto-generated />
using Gp1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gp1.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20221022195228_wedwq")]
    partial class wedwq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gp1.model.comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Videoid")
                        .HasColumnType("int");

                    b.Property<string>("comm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Videoid");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("Gp1.model.QuestionAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrectAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("questionAnswers");
                });

            modelBuilder.Entity("Gp1.model.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Videoid")
                        .HasColumnType("int");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Videoid");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("Gp1.model.SentenceAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswePercentage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SentenceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SentenceId");

                    b.HasIndex("UserId");

                    b.ToTable("sentenceAnswers");
                });

            modelBuilder.Entity("Gp1.model.SpokenSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Videoid")
                        .HasColumnType("int");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Videoid");

                    b.ToTable("spokenSentences");
                });

            modelBuilder.Entity("Gp1.model.user", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Gp1.model.Video", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link_Vid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("Gp1.model.Views", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Videoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.HasIndex("Videoid");

                    b.ToTable("Views");
                });

            modelBuilder.Entity("Gp1.model.comment", b =>
                {
                    b.HasOne("Gp1.model.user", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gp1.model.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("Videoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Gp1.model.QuestionAnswers", b =>
                {
                    b.HasOne("Gp1.model.Questions", "Question")
                        .WithMany("QuestionAnswer")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gp1.model.user", "User")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gp1.model.Questions", b =>
                {
                    b.HasOne("Gp1.model.Video", "Video")
                        .WithMany("Questions")
                        .HasForeignKey("Videoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Gp1.model.SentenceAnswers", b =>
                {
                    b.HasOne("Gp1.model.SpokenSentence", "Sentence")
                        .WithMany("SentenceAnswers")
                        .HasForeignKey("SentenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gp1.model.user", "User")
                        .WithMany("SentenceAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sentence");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gp1.model.SpokenSentence", b =>
                {
                    b.HasOne("Gp1.model.Video", "Video")
                        .WithMany("SpokenSentences")
                        .HasForeignKey("Videoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Gp1.model.Views", b =>
                {
                    b.HasOne("Gp1.model.user", "User")
                        .WithMany("Views")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gp1.model.Video", "Video")
                        .WithMany()
                        .HasForeignKey("Videoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Gp1.model.Questions", b =>
                {
                    b.Navigation("QuestionAnswer");
                });

            modelBuilder.Entity("Gp1.model.SpokenSentence", b =>
                {
                    b.Navigation("SentenceAnswers");
                });

            modelBuilder.Entity("Gp1.model.user", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("QuestionAnswers");

                    b.Navigation("SentenceAnswers");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("Gp1.model.Video", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Questions");

                    b.Navigation("SpokenSentences");
                });
#pragma warning restore 612, 618
        }
    }
}
