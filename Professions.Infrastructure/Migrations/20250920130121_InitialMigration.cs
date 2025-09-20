using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Professions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "industries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    industry_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_industries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    skill_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    profession_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    industry_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professions", x => x.id);
                    table.ForeignKey(
                        name: "FK_professions_industries_industry_id",
                        column: x => x.industry_id,
                        principalTable: "industries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profession_skills",
                columns: table => new
                {
                    ProfessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profession_skills", x => new { x.SkillId, x.ProfessionId, x.Level });
                    table.ForeignKey(
                        name: "FK_profession_skills_professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "professions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profession_skills_skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "industries",
                columns: new[] { "id", "industry_name" },
                values: new object[,]
                {
                    { new Guid("2ef8c75d-b9ae-49e4-a3a3-79d8fc3bba22"), "Другое" },
                    { new Guid("8530f0a0-14de-4a1c-acbc-4279acb79034"), "IT и технологии" },
                    { new Guid("a338e31c-41aa-4d10-9439-4f02a990e28c"), "Маркетинг и продажи" }
                });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "id", "skill_name" },
                values: new object[,]
                {
                    { new Guid("00a2affd-5ea7-4c64-b44c-df8ed6c44c9b"), "Notion" },
                    { new Guid("02892dea-3bc5-4c90-915c-56e3ec0b61d0"), "Wix" },
                    { new Guid("0b11d0b8-972f-449b-8ba3-99e120168e06"), "React" },
                    { new Guid("12af686c-7f56-453c-bcfb-5b0b511478b6"), "TypeScript" },
                    { new Guid("165d592f-3e67-440a-951e-03d334525a18"), "Optimizely" },
                    { new Guid("1855bccc-35ed-4026-b560-53d48cc04f1d"), "ISO 14001" },
                    { new Guid("23660949-a2a5-4700-b333-ed0bee0c3a42"), "Yoast SEO" },
                    { new Guid("23ed6db0-aaf6-4bf8-b0bb-8e3a6564ffba"), "SEO-стратегии" },
                    { new Guid("2669521c-2632-48c9-81d8-469a3de63869"), "Git" },
                    { new Guid("27519c94-1cf9-4dbb-9d17-c921849db12b"), "Код-ревью" },
                    { new Guid("28c29fa0-7aec-4f3b-8184-3fa214d4a7c4"), "Google Docs" },
                    { new Guid("3de32036-7524-4843-99a3-59bb6847adde"), "SimaPro" },
                    { new Guid("45c6d15c-a58c-4ad0-a68b-b8f88c6ece93"), "HTML" },
                    { new Guid("54b97981-2e1e-4954-91b5-55947b874d59"), "Экология" },
                    { new Guid("5ae23d6d-b8ef-4240-8bc6-ef883444f791"), "JavaScript" },
                    { new Guid("5e1497e4-ae25-4142-a41e-cf58f20793ba"), "AWS EC2" },
                    { new Guid("679d6428-0ed2-4e72-ac0b-2e4f0e03a6e7"), "SimilarWeb" },
                    { new Guid("6bd3ea61-f565-4af8-862f-49a442baa79f"), "Python (Django/Flask/FastAPI)" },
                    { new Guid("6c9a43be-804a-4e83-9664-6452b274c513"), "Масштабирование" },
                    { new Guid("6e74f32e-de01-49f5-bd5d-dd928b172267"), "Advocacy" },
                    { new Guid("71cfcbd8-832a-451f-916e-c158f229698b"), "REST" },
                    { new Guid("73bfc8f1-a319-4912-a3cb-006dee8bb53c"), "Node.js (Express/NestJS)" },
                    { new Guid("7508a871-70a0-44b3-94d9-ea90df02129b"), "Сторителлинг" },
                    { new Guid("7e03a0b7-850f-42f5-8664-7f819dba625c"), "SEMrush" },
                    { new Guid("83e797ab-d048-4d06-8260-33a9d695ac32"), "WordPress" },
                    { new Guid("89301f93-9fa0-4e0c-a76f-d63ca8686c83"), "SQL (PostgreSQL/MySQL)" },
                    { new Guid("8e881b7c-255a-478d-ae39-bb321b21cec4"), "Data-driven" },
                    { new Guid("8ebb9b00-e970-4fbe-8864-bbc3c2ab7e7b"), "Docker" },
                    { new Guid("8fade48d-dd25-4869-b19f-4cf944b91fce"), "Маркетинг и психология рекламы" },
                    { new Guid("949e526b-be0b-40b3-9843-bf3fda3ae0eb"), "Team management" },
                    { new Guid("97309ec7-defe-4f94-b7ae-3d027a26029d"), "Angular" },
                    { new Guid("9863b431-7907-4173-8d9a-0bcaf9374589"), "Jenkins" },
                    { new Guid("9b087a12-5142-454d-b205-5b8a1bd4603b"), "AARRR-модель" },
                    { new Guid("9d849fb7-6007-443d-9b3a-676ef72edbb4"), "CSS" },
                    { new Guid("a0be2b76-976c-4954-b13f-bd4fbf6cc315"), "SWOT (Miro)" },
                    { new Guid("a177c46b-2a87-48bc-89c8-f10b47c1d633"), "GitHub Actions" },
                    { new Guid("a9efd608-83e6-4a62-9a16-ff16d7f8efbf"), "Crunchbase" },
                    { new Guid("aeb668ff-9ba4-4a9e-b097-cf050bf5b42b"), "SurveyMonkey" },
                    { new Guid("b68e288f-432e-4e79-93e2-5d3134ddd7ab"), "AWS/GCP/Azure" },
                    { new Guid("b702b46b-5695-47df-aac5-d6427cefc95b"), "Оптимизация" },
                    { new Guid("b8b19c53-3729-4b50-92cc-e05c43f303f3"), "Adobe Illustrator" },
                    { new Guid("c850290c-5e3f-4abe-b370-2e8d0cb5a3b4"), "Tilda" },
                    { new Guid("cae35984-265c-43e8-96e3-94d200398436"), "Canva" },
                    { new Guid("cc83e336-f920-48ba-af4f-c5016427a8f5"), "RetailNext" },
                    { new Guid("d4b7f267-27b6-4c47-b53f-6d15b6340781"), "Google Forms" },
                    { new Guid("d5634588-7459-4c4e-9a1b-23de9a78dc44"), "Микросервисы" },
                    { new Guid("d5736426-981e-44bf-9e48-6ab38def4ee9"), "Адаптация под ЦА" },
                    { new Guid("ea329312-6c7b-4092-b131-d7faf8b810d8"), "Grammarly" },
                    { new Guid("f770f0ca-164f-4f41-85a5-05d042416b8a"), "Productboard" }
                });

            migrationBuilder.InsertData(
                table: "professions",
                columns: new[] { "id", "industry_id", "profession_name" },
                values: new object[,]
                {
                    { new Guid("00953951-2737-46d6-9c6e-c2be1a81d925"), new Guid("2ef8c75d-b9ae-49e4-a3a3-79d8fc3bba22"), "Эколог" },
                    { new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("a338e31c-41aa-4d10-9439-4f02a990e28c"), "Копирайтер" },
                    { new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("8530f0a0-14de-4a1c-acbc-4279acb79034"), "Frontend-разработчик" },
                    { new Guid("58682ecf-0ac9-4f3a-a62a-65090dfdad69"), new Guid("a338e31c-41aa-4d10-9439-4f02a990e28c"), "Продакт-маркетолог" },
                    { new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("a338e31c-41aa-4d10-9439-4f02a990e28c"), "Brand-менеджер" },
                    { new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("8530f0a0-14de-4a1c-acbc-4279acb79034"), "Backend-разработчик" },
                    { new Guid("80736387-153f-4b56-9271-2476df6566cb"), new Guid("8530f0a0-14de-4a1c-acbc-4279acb79034"), "Продакт-аналитик" },
                    { new Guid("8ef53ba4-881c-4f4f-8db4-175e9a92a181"), new Guid("a338e31c-41aa-4d10-9439-4f02a990e28c"), "Менеджер магазина" },
                    { new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("8530f0a0-14de-4a1c-acbc-4279acb79034"), "Fullstack-разработчик" }
                });

            migrationBuilder.InsertData(
                table: "profession_skills",
                columns: new[] { "Level", "ProfessionId", "SkillId" },
                values: new object[,]
                {
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("00a2affd-5ea7-4c64-b44c-df8ed6c44c9b") },
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("02892dea-3bc5-4c90-915c-56e3ec0b61d0") },
                    { 1, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("0b11d0b8-972f-449b-8ba3-99e120168e06") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("0b11d0b8-972f-449b-8ba3-99e120168e06") },
                    { 2, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("12af686c-7f56-453c-bcfb-5b0b511478b6") },
                    { 0, new Guid("80736387-153f-4b56-9271-2476df6566cb"), new Guid("165d592f-3e67-440a-951e-03d334525a18") },
                    { 0, new Guid("00953951-2737-46d6-9c6e-c2be1a81d925"), new Guid("1855bccc-35ed-4026-b560-53d48cc04f1d") },
                    { 1, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("23660949-a2a5-4700-b333-ed0bee0c3a42") },
                    { 3, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("23ed6db0-aaf6-4bf8-b0bb-8e3a6564ffba") },
                    { 1, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("2669521c-2632-48c9-81d8-469a3de63869") },
                    { 1, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("2669521c-2632-48c9-81d8-469a3de63869") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("2669521c-2632-48c9-81d8-469a3de63869") },
                    { 2, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("27519c94-1cf9-4dbb-9d17-c921849db12b") },
                    { 2, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("27519c94-1cf9-4dbb-9d17-c921849db12b") },
                    { 1, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("28c29fa0-7aec-4f3b-8184-3fa214d4a7c4") },
                    { 0, new Guid("00953951-2737-46d6-9c6e-c2be1a81d925"), new Guid("3de32036-7524-4843-99a3-59bb6847adde") },
                    { 1, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("45c6d15c-a58c-4ad0-a68b-b8f88c6ece93") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("45c6d15c-a58c-4ad0-a68b-b8f88c6ece93") },
                    { 0, new Guid("00953951-2737-46d6-9c6e-c2be1a81d925"), new Guid("54b97981-2e1e-4954-91b5-55947b874d59") },
                    { 1, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("5ae23d6d-b8ef-4240-8bc6-ef883444f791") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("5ae23d6d-b8ef-4240-8bc6-ef883444f791") },
                    { 3, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("5e1497e4-ae25-4142-a41e-cf58f20793ba") },
                    { 2, new Guid("58682ecf-0ac9-4f3a-a62a-65090dfdad69"), new Guid("679d6428-0ed2-4e72-ac0b-2e4f0e03a6e7") },
                    { 1, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("6bd3ea61-f565-4af8-862f-49a442baa79f") },
                    { 0, new Guid("80736387-153f-4b56-9271-2476df6566cb"), new Guid("6bd3ea61-f565-4af8-862f-49a442baa79f") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("6bd3ea61-f565-4af8-862f-49a442baa79f") },
                    { 3, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("6c9a43be-804a-4e83-9664-6452b274c513") },
                    { 0, new Guid("00953951-2737-46d6-9c6e-c2be1a81d925"), new Guid("6e74f32e-de01-49f5-bd5d-dd928b172267") },
                    { 2, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("71cfcbd8-832a-451f-916e-c158f229698b") },
                    { 2, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("71cfcbd8-832a-451f-916e-c158f229698b") },
                    { 1, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("73bfc8f1-a319-4912-a3cb-006dee8bb53c") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("73bfc8f1-a319-4912-a3cb-006dee8bb53c") },
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("7508a871-70a0-44b3-94d9-ea90df02129b") },
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("7e03a0b7-850f-42f5-8664-7f819dba625c") },
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("83e797ab-d048-4d06-8260-33a9d695ac32") },
                    { 1, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("89301f93-9fa0-4e0c-a76f-d63ca8686c83") },
                    { 0, new Guid("80736387-153f-4b56-9271-2476df6566cb"), new Guid("89301f93-9fa0-4e0c-a76f-d63ca8686c83") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("89301f93-9fa0-4e0c-a76f-d63ca8686c83") },
                    { 0, new Guid("80736387-153f-4b56-9271-2476df6566cb"), new Guid("8e881b7c-255a-478d-ae39-bb321b21cec4") },
                    { 2, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("8ebb9b00-e970-4fbe-8864-bbc3c2ab7e7b") },
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("8fade48d-dd25-4869-b19f-4cf944b91fce") },
                    { 0, new Guid("8ef53ba4-881c-4f4f-8db4-175e9a92a181"), new Guid("949e526b-be0b-40b3-9843-bf3fda3ae0eb") },
                    { 2, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("97309ec7-defe-4f94-b7ae-3d027a26029d") },
                    { 2, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("9863b431-7907-4173-8d9a-0bcaf9374589") },
                    { 3, new Guid("58682ecf-0ac9-4f3a-a62a-65090dfdad69"), new Guid("9b087a12-5142-454d-b205-5b8a1bd4603b") },
                    { 1, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("9d849fb7-6007-443d-9b3a-676ef72edbb4") },
                    { 1, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("9d849fb7-6007-443d-9b3a-676ef72edbb4") },
                    { 1, new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("a0be2b76-976c-4954-b13f-bd4fbf6cc315") },
                    { 2, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("a177c46b-2a87-48bc-89c8-f10b47c1d633") },
                    { 2, new Guid("58682ecf-0ac9-4f3a-a62a-65090dfdad69"), new Guid("a9efd608-83e6-4a62-9a16-ff16d7f8efbf") },
                    { 1, new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("aeb668ff-9ba4-4a9e-b097-cf050bf5b42b") },
                    { 3, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("b68e288f-432e-4e79-93e2-5d3134ddd7ab") },
                    { 3, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("b68e288f-432e-4e79-93e2-5d3134ddd7ab") },
                    { 3, new Guid("3baf2a20-6e44-4586-bf39-6fa7caa5aa03"), new Guid("b702b46b-5695-47df-aac5-d6427cefc95b") },
                    { 3, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("b702b46b-5695-47df-aac5-d6427cefc95b") },
                    { 2, new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("b8b19c53-3729-4b50-92cc-e05c43f303f3") },
                    { 3, new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("b8b19c53-3729-4b50-92cc-e05c43f303f3") },
                    { 2, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("c850290c-5e3f-4abe-b370-2e8d0cb5a3b4") },
                    { 1, new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("cae35984-265c-43e8-96e3-94d200398436") },
                    { 0, new Guid("8ef53ba4-881c-4f4f-8db4-175e9a92a181"), new Guid("cc83e336-f920-48ba-af4f-c5016427a8f5") },
                    { 1, new Guid("7bb487e3-9997-46e4-aed8-84fe2839a0e5"), new Guid("d4b7f267-27b6-4c47-b53f-6d15b6340781") },
                    { 3, new Guid("7e2b1b35-6211-4157-9a11-2e3214fced85"), new Guid("d5634588-7459-4c4e-9a1b-23de9a78dc44") },
                    { 3, new Guid("945f817b-faf1-4db0-a90b-dcddb215e70b"), new Guid("d5634588-7459-4c4e-9a1b-23de9a78dc44") },
                    { 3, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("d5736426-981e-44bf-9e48-6ab38def4ee9") },
                    { 1, new Guid("37d1dc2d-a920-489e-9add-c585b49ca186"), new Guid("ea329312-6c7b-4092-b131-d7faf8b810d8") },
                    { 1, new Guid("58682ecf-0ac9-4f3a-a62a-65090dfdad69"), new Guid("f770f0ca-164f-4f41-85a5-05d042416b8a") }
                });

            migrationBuilder.CreateIndex(
                name: "INX_INDUSTRY_NAME",
                table: "industries",
                column: "industry_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profession_skills_ProfessionId",
                table: "profession_skills",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "INX_PROFESSION_NAME",
                table: "professions",
                column: "profession_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_professions_industry_id",
                table: "professions",
                column: "industry_id");

            migrationBuilder.CreateIndex(
                name: "INX_SKILL_NAME",
                table: "skills",
                column: "skill_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profession_skills");

            migrationBuilder.DropTable(
                name: "professions");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "industries");
        }
    }
}
