using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using InspirationSite.Models;

namespace InspirationSite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160305012912_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InspirationSite.Models.BlogPosts", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorMemberId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostDate");

                    b.Property<string>("Title");

                    b.HasKey("BlogPostId");
                });

            modelBuilder.Entity("InspirationSite.Models.PackMembers", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("FacebookURL");

                    b.Property<string>("ImageURL");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("TwitterURL");

                    b.Property<string>("Username");

                    b.HasKey("MemberId");
                });

            modelBuilder.Entity("InspirationSite.Models.Photos", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("ImageURL");

                    b.Property<bool>("InAlbum");

                    b.Property<int?>("PhotoOfMemberId");

                    b.HasKey("PhotoId");
                });

            modelBuilder.Entity("InspirationSite.Models.Videos", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Title");

                    b.Property<string>("VideoURL");

                    b.HasKey("VideoId");
                });

            modelBuilder.Entity("InspirationSite.Models.BlogPosts", b =>
                {
                    b.HasOne("InspirationSite.Models.PackMembers")
                        .WithMany()
                        .HasForeignKey("AuthorMemberId");
                });

            modelBuilder.Entity("InspirationSite.Models.Photos", b =>
                {
                    b.HasOne("InspirationSite.Models.PackMembers")
                        .WithMany()
                        .HasForeignKey("PhotoOfMemberId");
                });
        }
    }
}
