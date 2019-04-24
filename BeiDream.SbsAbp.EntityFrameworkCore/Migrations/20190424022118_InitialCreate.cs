using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeiDream.SbsAbp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeiDreamAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 256, nullable: true),
                    Parameters = table.Column<string>(maxLength: 1024, nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Exception = table.Column<string>(maxLength: 2000, nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    JobType = table.Column<string>(maxLength: 512, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false),
                    Priority = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamBackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamDemoTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamDemoTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamEditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamEditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamEntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamEntityChangeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamLanguageTexts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    LanguageName = table.Column<string>(maxLength: 10, nullable: false),
                    Source = table.Column<string>(maxLength: 128, nullable: false),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 67108864, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamLanguageTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: true),
                    IconClass = table.Column<string>(maxLength: 20, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    PermissionName = table.Column<string>(maxLength: 200, nullable: true),
                    Group = table.Column<bool>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    IsHome = table.Column<bool>(nullable: false),
                    NotClose = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamMenu_BeiDreamMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BeiDreamMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false),
                    UserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    TenantIds = table.Column<string>(maxLength: 131072, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamNotificationSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamNotificationSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamOrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamOrganizationUnitRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamOrganizationUnits_BeiDreamOrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BeiDreamOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamTenantNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamTenantNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserLinkId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Result = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserLoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantNotificationId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserOrganizationUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AuthenticationSource = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    EmailConfirmationCode = table.Column<string>(maxLength: 328, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 328, nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsLockoutEnabled = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamUsers_BeiDreamUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamUsers_BeiDreamUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamUsers_BeiDreamUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamFeatures_BeiDreamEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "BeiDreamEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamEntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamEntityChanges_BeiDreamEntityChangeSets_EntityChangeS~",
                        column: x => x.EntityChangeSetId,
                        principalTable: "BeiDreamEntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamRoles_BeiDreamUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamRoles_BeiDreamUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamRoles_BeiDreamUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamSettings_BeiDreamUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamTenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ConnectionString = table.Column<string>(maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamTenants_BeiDreamUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamTenants_BeiDreamUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamTenants_BeiDreamEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "BeiDreamEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeiDreamTenants_BeiDreamUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamUserClaims_BeiDreamUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamUserLogins_BeiDreamUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamUserRoles_BeiDreamUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamUserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamUserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamUserTokens_BeiDreamUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamEntityPropertyChanges_BeiDreamEntityChanges_EntityCh~",
                        column: x => x.EntityChangeId,
                        principalTable: "BeiDreamEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsGranted = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamPermissions_BeiDreamRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "BeiDreamRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeiDreamPermissions_BeiDreamUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BeiDreamUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeiDreamRoleClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeiDreamRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeiDreamRoleClaims_BeiDreamRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "BeiDreamRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamAuditLogs_TenantId_ExecutionDuration",
                table: "BeiDreamAuditLogs",
                columns: new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamAuditLogs_TenantId_ExecutionTime",
                table: "BeiDreamAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamAuditLogs_TenantId_UserId",
                table: "BeiDreamAuditLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamBackgroundJobs_IsAbandoned_NextTryTime",
                table: "BeiDreamBackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamEntityChanges_EntityChangeSetId",
                table: "BeiDreamEntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamEntityChanges_EntityTypeFullName_EntityId",
                table: "BeiDreamEntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamEntityChangeSets_TenantId_CreationTime",
                table: "BeiDreamEntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamEntityChangeSets_TenantId_Reason",
                table: "BeiDreamEntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamEntityChangeSets_TenantId_UserId",
                table: "BeiDreamEntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamEntityPropertyChanges_EntityChangeId",
                table: "BeiDreamEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamFeatures_EditionId_Name",
                table: "BeiDreamFeatures",
                columns: new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamFeatures_TenantId_Name",
                table: "BeiDreamFeatures",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamLanguages_TenantId_Name",
                table: "BeiDreamLanguages",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamLanguageTexts_TenantId_Source_LanguageName_Key",
                table: "BeiDreamLanguageTexts",
                columns: new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamMenu_ParentId",
                table: "BeiDreamMenu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamNotificationSubscriptions_NotificationName_EntityTyp~",
                table: "BeiDreamNotificationSubscriptions",
                columns: new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamNotificationSubscriptions_TenantId_NotificationName_~",
                table: "BeiDreamNotificationSubscriptions",
                columns: new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamOrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "BeiDreamOrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamOrganizationUnitRoles_TenantId_RoleId",
                table: "BeiDreamOrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamOrganizationUnits_ParentId",
                table: "BeiDreamOrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamOrganizationUnits_TenantId_Code",
                table: "BeiDreamOrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamPermissions_TenantId_Name",
                table: "BeiDreamPermissions",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamPermissions_RoleId",
                table: "BeiDreamPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamPermissions_UserId",
                table: "BeiDreamPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamRoleClaims_RoleId",
                table: "BeiDreamRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamRoleClaims_TenantId_ClaimType",
                table: "BeiDreamRoleClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamRoles_CreatorUserId",
                table: "BeiDreamRoles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamRoles_DeleterUserId",
                table: "BeiDreamRoles",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamRoles_LastModifierUserId",
                table: "BeiDreamRoles",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamRoles_TenantId_NormalizedName",
                table: "BeiDreamRoles",
                columns: new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamSettings_UserId",
                table: "BeiDreamSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamSettings_TenantId_Name",
                table: "BeiDreamSettings",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamTenantNotifications_TenantId",
                table: "BeiDreamTenantNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamTenants_CreatorUserId",
                table: "BeiDreamTenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamTenants_DeleterUserId",
                table: "BeiDreamTenants",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamTenants_EditionId",
                table: "BeiDreamTenants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamTenants_LastModifierUserId",
                table: "BeiDreamTenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamTenants_TenancyName",
                table: "BeiDreamTenants",
                column: "TenancyName");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserAccounts_EmailAddress",
                table: "BeiDreamUserAccounts",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserAccounts_UserName",
                table: "BeiDreamUserAccounts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserAccounts_TenantId_EmailAddress",
                table: "BeiDreamUserAccounts",
                columns: new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserAccounts_TenantId_UserId",
                table: "BeiDreamUserAccounts",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserAccounts_TenantId_UserName",
                table: "BeiDreamUserAccounts",
                columns: new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserClaims_UserId",
                table: "BeiDreamUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserClaims_TenantId_ClaimType",
                table: "BeiDreamUserClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserLoginAttempts_UserId_TenantId",
                table: "BeiDreamUserLoginAttempts",
                columns: new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserLoginAttempts_TenancyName_UserNameOrEmailAddress~",
                table: "BeiDreamUserLoginAttempts",
                columns: new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserLogins_UserId",
                table: "BeiDreamUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserLogins_TenantId_UserId",
                table: "BeiDreamUserLogins",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserLogins_TenantId_LoginProvider_ProviderKey",
                table: "BeiDreamUserLogins",
                columns: new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserNotifications_UserId_State_CreationTime",
                table: "BeiDreamUserNotifications",
                columns: new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserOrganizationUnits_TenantId_OrganizationUnitId",
                table: "BeiDreamUserOrganizationUnits",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserOrganizationUnits_TenantId_UserId",
                table: "BeiDreamUserOrganizationUnits",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserRoles_UserId",
                table: "BeiDreamUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserRoles_TenantId_RoleId",
                table: "BeiDreamUserRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserRoles_TenantId_UserId",
                table: "BeiDreamUserRoles",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUsers_CreatorUserId",
                table: "BeiDreamUsers",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUsers_DeleterUserId",
                table: "BeiDreamUsers",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUsers_LastModifierUserId",
                table: "BeiDreamUsers",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUsers_TenantId_NormalizedEmailAddress",
                table: "BeiDreamUsers",
                columns: new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUsers_TenantId_NormalizedUserName",
                table: "BeiDreamUsers",
                columns: new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserTokens_UserId",
                table: "BeiDreamUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BeiDreamUserTokens_TenantId_UserId",
                table: "BeiDreamUserTokens",
                columns: new[] { "TenantId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeiDreamAuditLogs");

            migrationBuilder.DropTable(
                name: "BeiDreamBackgroundJobs");

            migrationBuilder.DropTable(
                name: "BeiDreamDemoTask");

            migrationBuilder.DropTable(
                name: "BeiDreamEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "BeiDreamFeatures");

            migrationBuilder.DropTable(
                name: "BeiDreamLanguages");

            migrationBuilder.DropTable(
                name: "BeiDreamLanguageTexts");

            migrationBuilder.DropTable(
                name: "BeiDreamMenu");

            migrationBuilder.DropTable(
                name: "BeiDreamNotifications");

            migrationBuilder.DropTable(
                name: "BeiDreamNotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "BeiDreamOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "BeiDreamOrganizationUnits");

            migrationBuilder.DropTable(
                name: "BeiDreamPermissions");

            migrationBuilder.DropTable(
                name: "BeiDreamRoleClaims");

            migrationBuilder.DropTable(
                name: "BeiDreamSettings");

            migrationBuilder.DropTable(
                name: "BeiDreamTenantNotifications");

            migrationBuilder.DropTable(
                name: "BeiDreamTenants");

            migrationBuilder.DropTable(
                name: "BeiDreamUserAccounts");

            migrationBuilder.DropTable(
                name: "BeiDreamUserClaims");

            migrationBuilder.DropTable(
                name: "BeiDreamUserLoginAttempts");

            migrationBuilder.DropTable(
                name: "BeiDreamUserLogins");

            migrationBuilder.DropTable(
                name: "BeiDreamUserNotifications");

            migrationBuilder.DropTable(
                name: "BeiDreamUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "BeiDreamUserRoles");

            migrationBuilder.DropTable(
                name: "BeiDreamUserTokens");

            migrationBuilder.DropTable(
                name: "BeiDreamEntityChanges");

            migrationBuilder.DropTable(
                name: "BeiDreamRoles");

            migrationBuilder.DropTable(
                name: "BeiDreamEditions");

            migrationBuilder.DropTable(
                name: "BeiDreamEntityChangeSets");

            migrationBuilder.DropTable(
                name: "BeiDreamUsers");
        }
    }
}
