using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DotNetCoreMySQL.Models
{
    public partial class DarlyAlmonteContext : DbContext
    {
        public DarlyAlmonteContext()
        {
        }

        public DarlyAlmonteContext(DbContextOptions<DarlyAlmonteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; } = null!;
        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; } = null!;
        public virtual DbSet<Battery> Batteries { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Column> Columns { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Detailsbuilding> Detailsbuildings { get; set; } = null!;
        public virtual DbSet<Elevator> Elevators { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Intervention> Interventions { get; set; } = null!;
        public virtual DbSet<Lead> Leads { get; set; } = null!;
        public virtual DbSet<Map> Maps { get; set; } = null!;
        public virtual DbSet<Mytest> Mytests { get; set; } = null!;
        public virtual DbSet<Quote> Quotes { get; set; } = null!;
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=codeboxx.cq6zrczewpu2.us-east-1.rds.amazonaws.com;user=codeboxx;password=Codeboxx1!;database=DarlyAlmonte", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.ToTable("adresses");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Entity)
                    .HasMaxLength(255)
                    .HasColumnName("entity");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(255)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(255)
                    .HasColumnName("longitude");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.NumberAndStreet)
                    .HasMaxLength(255)
                    .HasColumnName("number_and_street");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postal_code");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.SuiteOrAppartment)
                    .HasMaxLength(255)
                    .HasColumnName("suite_or_appartment");

                entity.Property(e => e.TypeOfAdress)
                    .HasMaxLength(255)
                    .HasColumnName("type_of_adress");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId, "index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.CertificateOfOperations)
                    .HasMaxLength(255)
                    .HasColumnName("certificate_of_operations");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateOfCommissioning).HasColumnName("date_of_commissioning");

                entity.Property(e => e.DateOfLastInspection).HasColumnName("date_of_last_inspection");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.Information)
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AdressId, "index_buildings_on_adress_id");

                entity.HasIndex(e => e.CustomerId, "index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AdressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("adress_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.EmailOfTheAdministratorOfTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("Email_of_the_administrator_of_the_building");

                entity.Property(e => e.FullNameOfTheBuildingAdministrator)
                    .HasMaxLength(255)
                    .HasColumnName("Full_Name_of_the_building_administrator");

                entity.Property(e => e.FullNameOfTheTechnicalContactForTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("Full_Name_of_the_technical_contact_for_the_building");

                entity.Property(e => e.NoOfFloors)
                    .HasColumnType("int(11)")
                    .HasColumnName("No_of_floors");

                entity.Property(e => e.PhoneNumberOfTheBuildingAdministrator)
                    .HasMaxLength(255)
                    .HasColumnName("Phone_number_of_the_building_administrator");

                entity.Property(e => e.TechnicalContactEmailForTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("Technical_contact_email_for_the_building");

                entity.Property(e => e.TechnicalContactPhoneForTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("Technical_contact_phone_for_the_building");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AdressId)
                    .HasConstraintName("fk_rails_a22774accc");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BatteryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("battery_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Information)
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.NbOfFloorsServed)
                    .HasColumnType("int(11)")
                    .HasColumnName("nb_of_floors_served");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.SetType)
                    .HasMaxLength(255)
                    .HasColumnName("set_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AdressId, "index_customers_on_adress_id");

                entity.HasIndex(e => e.UserId, "index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AdressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("adress_id");

                entity.Property(e => e.CompanyContactPhone)
                    .HasMaxLength(255)
                    .HasColumnName("Company_contact_phone");

                entity.Property(e => e.CompanyDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Company_Description");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomersCreationDate)
                    .HasMaxLength(255)
                    .HasColumnName("Customers_Creation_Date");

                entity.Property(e => e.EmailOfTheCompanyContact)
                    .HasMaxLength(255)
                    .HasColumnName("Email_of_the_company_contact");

                entity.Property(e => e.FullNameOfServiveTechnicalAuthority)
                    .HasMaxLength(255)
                    .HasColumnName("Full_Name_of_servive_Technical_Authority");

                entity.Property(e => e.FullNameOfTheCompanyContact)
                    .HasMaxLength(255)
                    .HasColumnName("Full_Name_of_the_company_contact");

                entity.Property(e => e.TechnicalManagerEmailForService)
                    .HasMaxLength(255)
                    .HasColumnName("Technical_Manager_Email_for_Service");

                entity.Property(e => e.TechnicalManagerEmailForServive)
                    .HasMaxLength(255)
                    .HasColumnName("Technical_Manager_Email_for_Servive");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AdressId)
                    .HasConstraintName("fk_rails_f90e160f0c");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Detailsbuilding>(entity =>
            {
                entity.ToTable("detailsbuildings");

                entity.HasIndex(e => e.BuildingId, "index_detailsbuildings_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.InformationKey)
                    .HasMaxLength(255)
                    .HasColumnName("information_key");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Detailsbuildings)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_ff68c81e8c");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CertificateOfInspection)
                    .HasMaxLength(255)
                    .HasColumnName("Certificate_of_inspection");

                entity.Property(e => e.ColumnId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("column_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateOfCommissioning)
                    .HasMaxLength(255)
                    .HasColumnName("Date_of_commissioning");

                entity.Property(e => e.DateOfLastInspection)
                    .HasMaxLength(255)
                    .HasColumnName("Date_of_last_inspection");

                entity.Property(e => e.Information).HasMaxLength(255);

                entity.Property(e => e.Model).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Serial_number");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId, "index_employees_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Intervention>(entity =>
            {
                entity.ToTable("interventions");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .HasColumnName("author");

                entity.Property(e => e.BatteryId)
                    .HasMaxLength(255)
                    .HasColumnName("batteryID");

                entity.Property(e => e.BuildingId)
                    .HasMaxLength(255)
                    .HasColumnName("buildingID");

                entity.Property(e => e.ColumnId)
                    .HasMaxLength(255)
                    .HasColumnName("columnID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(255)
                    .HasColumnName("customerID");

                entity.Property(e => e.ElevatorId)
                    .HasMaxLength(255)
                    .HasColumnName("elevatorID");

                entity.Property(e => e.Employee)
                    .HasMaxLength(255)
                    .HasColumnName("employee");

                entity.Property(e => e.EndIntervention)
                    .HasColumnType("datetime")
                    .HasColumnName("end_intervention");

                entity.Property(e => e.Report)
                    .HasMaxLength(255)
                    .HasColumnName("report");

                entity.Property(e => e.Result)
                    .HasMaxLength(255)
                    .HasColumnName("result")
                    .HasDefaultValueSql("'Incomplete'");

                entity.Property(e => e.StartIntervention)
                    .HasColumnType("datetime")
                    .HasColumnName("start_intervention");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AttachedFiles)
                    .HasColumnType("mediumblob")
                    .HasColumnName("attached_files");

                entity.Property(e => e.CieName)
                    .HasMaxLength(255)
                    .HasColumnName("cie_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DepartmentInCharge)
                    .HasMaxLength(255)
                    .HasColumnName("department_in_charge");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(255)
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("project_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.ToTable("maps");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(255)
                    .HasColumnName("client_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.FullNameOfTechnicalContact)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_technical_contact");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(255)
                    .HasColumnName("latitude");

                entity.Property(e => e.LocationOfTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("location_of_the_building");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(255)
                    .HasColumnName("longitude");

                entity.Property(e => e.NoOfBatteries)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_batteries");

                entity.Property(e => e.NoOfColumns)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_columns");

                entity.Property(e => e.NoOfElevators)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_elevators");

                entity.Property(e => e.NoOfFloorsInTheBuilding)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_floors_in_the_building");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Mytest>(entity =>
            {
                entity.ToTable("mytests");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("companyName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FinalPrice)
                    .HasColumnType("int(11)")
                    .HasColumnName("final_price");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("fullName");

                entity.Property(e => e.InstallationFees)
                    .HasColumnType("int(11)")
                    .HasColumnName("installation_fees");

                entity.Property(e => e.MaxOfOccupantsPerFloor)
                    .HasColumnType("int(11)")
                    .HasColumnName("max_of_occupants_per_floor");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.NoOfApartments)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_apartments");

                entity.Property(e => e.NoOfBasements)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_basements");

                entity.Property(e => e.NoOfBusinesses)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_businesses");

                entity.Property(e => e.NoOfElevatorCages)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_elevator_cages");

                entity.Property(e => e.NoOfElevatorsNeeded)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_elevators_needed");

                entity.Property(e => e.NoOfFloors)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_floors");

                entity.Property(e => e.NoOfHoursOfActivities)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_hours_of_activities");

                entity.Property(e => e.NoOfParkingSpaces)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_of_parking_spaces");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Processed).HasColumnName("processed");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(255)
                    .HasColumnName("product_line");

                entity.Property(e => e.ProjectDesc)
                    .HasMaxLength(255)
                    .HasColumnName("projectDesc");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("projectName");

                entity.Property(e => e.TotalPriceOfElevators)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_price_of_elevators");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("int(11)")
                    .HasColumnName("unit_price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .HasMaxLength(255)
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken).HasColumnName("reset_password_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
