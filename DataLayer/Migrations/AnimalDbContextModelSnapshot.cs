// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(AnimalDbContext))]
    partial class AnimalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BusinessLayer.Diet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Complexity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("BusinessLayer.Habitat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Food")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Light")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<string>("Water")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Habitats");
                });

            modelBuilder.Entity("BusinessLayer.Species", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Lifespan")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("DietSpecies", b =>
                {
                    b.Property<int>("DietsID")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.HasKey("DietsID", "SpeciesID");

                    b.HasIndex("SpeciesID");

                    b.ToTable("DietSpecies");
                });

            modelBuilder.Entity("HabitatSpecies", b =>
                {
                    b.Property<int>("HabitatsID")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.HasKey("HabitatsID", "SpeciesID");

                    b.HasIndex("SpeciesID");

                    b.ToTable("HabitatSpecies");
                });

            modelBuilder.Entity("DietSpecies", b =>
                {
                    b.HasOne("BusinessLayer.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLayer.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HabitatSpecies", b =>
                {
                    b.HasOne("BusinessLayer.Habitat", null)
                        .WithMany()
                        .HasForeignKey("HabitatsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLayer.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
