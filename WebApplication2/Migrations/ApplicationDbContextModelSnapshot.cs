﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.CourseLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("LevelID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.HasIndex("LevelID");

                    b.ToTable("CourseLevels", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.CourseLevelTeacher", b =>
                {
                    b.Property<int>("CourseLevelTeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseLevelTeacherID"));

                    b.Property<int>("CourseLevelID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("CourseLevelTeacherID");

                    b.HasIndex("CourseLevelID");

                    b.HasIndex("TeacherID");

                    b.ToTable("CourseLevelTeachers", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Level", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LevelID")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LevelID");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.TeacherCourse", b =>
                {
                    b.Property<int>("TeacherCourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherCourseID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("TeacherCourseID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TeacherID");

                    b.ToTable("TeacherCourses", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.CourseLevel", b =>
                {
                    b.HasOne("WebApplication2.Models.Course", "Course")
                        .WithMany("CourseLevels")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Level", "Level")
                        .WithMany("CourseLevels")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("WebApplication2.Models.CourseLevelTeacher", b =>
                {
                    b.HasOne("WebApplication2.Models.CourseLevel", "CourseLevel")
                        .WithMany("CourseLevelTeachers")
                        .HasForeignKey("CourseLevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseLevel");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("WebApplication2.Models.Student", b =>
                {
                    b.HasOne("WebApplication2.Models.Level", "Level")
                        .WithMany("Students")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("WebApplication2.Models.TeacherCourse", b =>
                {
                    b.HasOne("WebApplication2.Models.Course", "Course")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("WebApplication2.Models.Course", b =>
                {
                    b.Navigation("CourseLevels");

                    b.Navigation("TeacherCourses");
                });

            modelBuilder.Entity("WebApplication2.Models.CourseLevel", b =>
                {
                    b.Navigation("CourseLevelTeachers");
                });

            modelBuilder.Entity("WebApplication2.Models.Level", b =>
                {
                    b.Navigation("CourseLevels");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("WebApplication2.Models.Teacher", b =>
                {
                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
