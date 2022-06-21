﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UniNote.Data;

#nullable disable

namespace UniNote.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220621023536_SomeUpd")]
    partial class SomeUpd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UniNote.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("integer")
                        .HasColumnName("created_by_user_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_groups");

                    b.HasIndex("CreatedByUserId")
                        .HasDatabaseName("ix_groups_created_by_user_id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_groups_group_id");

                    b.ToTable("groups", (string)null);
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("integer")
                        .HasColumnName("created_by_user_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean")
                        .HasColumnName("is_favorite");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_notes");

                    b.HasIndex("CreatedByUserId")
                        .HasDatabaseName("ix_notes_created_by_user_id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_notes_group_id");

                    b.ToTable("notes", (string)null);
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Note2Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NoteId")
                        .HasColumnType("integer")
                        .HasColumnName("note_id");

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.HasKey("Id")
                        .HasName("pk_note2tags");

                    b.HasIndex("NoteId")
                        .HasDatabaseName("ix_note2tags_note_id");

                    b.HasIndex("TagId")
                        .HasDatabaseName("ix_note2tags_tag_id");

                    b.ToTable("note2tags", (string)null);
                });

            modelBuilder.Entity("UniNote.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateExpiration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_expiration");

                    b.Property<bool>("IsInvalid")
                        .HasColumnType("boolean")
                        .HasColumnName("is_invalid");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_refresh_tokens");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_refresh_tokens_user_id");

                    b.ToTable("refresh_tokens", (string)null);
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color_hex");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("integer")
                        .HasColumnName("created_by_user_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_tags");

                    b.HasIndex("CreatedByUserId")
                        .HasDatabaseName("ix_tags_created_by_user_id");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("UniNote.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_updated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hashed");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Group", b =>
                {
                    b.HasOne("UniNote.Domain.Entities.User", "CreatedByUser")
                        .WithMany("Groups")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("fk_groups_users_created_by_user_id");

                    b.HasOne("UniNote.Domain.Entities.Group", "ParentGroup")
                        .WithMany("ChildGroups")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_groups_groups_group_id");

                    b.Navigation("CreatedByUser");

                    b.Navigation("ParentGroup");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Note", b =>
                {
                    b.HasOne("UniNote.Domain.Entities.User", "CreatedByUser")
                        .WithMany("Notes")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("fk_notes_users_created_by_user_id");

                    b.HasOne("UniNote.Domain.Entities.Group", "Group")
                        .WithMany("Notes")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_notes_groups_group_id");

                    b.Navigation("CreatedByUser");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Note2Tag", b =>
                {
                    b.HasOne("UniNote.Domain.Entities.Note", "Note")
                        .WithMany("Tags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_note2tags_notes_note_id");

                    b.HasOne("UniNote.Domain.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_note2tags_tags_tag_id");

                    b.Navigation("Note");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("UniNote.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_refresh_tokens_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Tag", b =>
                {
                    b.HasOne("UniNote.Domain.Entities.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("fk_tags_users_created_by_user_id");

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Group", b =>
                {
                    b.Navigation("ChildGroups");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.Note", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("UniNote.Domain.Entities.User", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}