using Microsoft.EntityFrameworkCore;
using Professions.Domain;
using Professions.Infrastructure.Entities;

namespace Professions.Infrastructure;

public static class DefaultDataSetter
{
    public static void SetDefaultData(this ModelBuilder modelBuilder)
    {
        // ====== INDUSTRIES ======
        var other = new IndustryEntity { IndustryName = "Другое" };
        var it = new IndustryEntity { IndustryName = "IT и технологии" };
        var marketing = new IndustryEntity { IndustryName = "Маркетинг и продажи" };

        // ======  SKILLS ======

        // ======  ECOLOGIST SKILLS ======
        var iso14001 = new SkillEntity { SkillName = "ISO 14001" };
        var simaPro = new SkillEntity { SkillName = "SimaPro" };
        var advocacy = new SkillEntity { SkillName = "Advocacy" };
        var ecology = new SkillEntity { SkillName = "Экология" };

        // ======  STORE MANAGER SKILLS ======
        var retailNext = new SkillEntity { SkillName = "RetailNext" };
        var teamManagement = new SkillEntity { SkillName = "Team management" };

        // ======  PRODUCT ANALYST SKILLS ======
        var optimizely = new SkillEntity { SkillName = "Optimizely" };
        var dataDriven = new SkillEntity { SkillName = "Data-driven" };

        // ====== IT COMMON SKILLS ======
        var git = new SkillEntity { SkillName = "Git" };
        var codeReview = new SkillEntity { SkillName = "Код-ревью" };
        var jenkins = new SkillEntity { SkillName = "Jenkins" };
        var githubActions = new SkillEntity { SkillName = "GitHub Actions" };
        var optimization = new SkillEntity { SkillName = "Оптимизация" };

        // ====== FRONTEND SKILLS ======
        var html = new SkillEntity { SkillName = "HTML" };
        var css = new SkillEntity { SkillName = "CSS" };
        var js = new SkillEntity { SkillName = "JavaScript" };
        var ts = new SkillEntity { SkillName = "TypeScript" };
        var react = new SkillEntity { SkillName = "React" };

        // ====== BACKEND SKILLS ======
        var python = new SkillEntity { SkillName = "Python (Django/Flask/FastAPI)" };
        var nodejs = new SkillEntity { SkillName = "Node.js (Express/NestJS)" };
        var sql = new SkillEntity { SkillName = "SQL (PostgreSQL/MySQL)" };
        var rest = new SkillEntity { SkillName = "REST" };
        var docker = new SkillEntity { SkillName = "Docker" };
        var microservices = new SkillEntity { SkillName = "Микросервисы" };
        var cloud = new SkillEntity { SkillName = "AWS/GCP/Azure" };
        var scaling = new SkillEntity { SkillName = "Масштабирование" };

        // ====== FULLSTACK SKILLS ======
        var angular = new SkillEntity { SkillName = "Angular" };
        var awsEc2 = new SkillEntity { SkillName = "AWS EC2" };

        // ====== MARKETING SKILLS ======
        var swotMiro = new SkillEntity { SkillName = "SWOT (Miro)" };
        var surveyMonkey = new SkillEntity { SkillName = "SurveyMonkey" };
        var googleForms = new SkillEntity { SkillName = "Google Forms" };
        var canva = new SkillEntity { SkillName = "Canva" };
        var illustrator = new SkillEntity { SkillName = "Adobe Illustrator" };
        var productboard = new SkillEntity { SkillName = "Productboard" };
        var similarWeb = new SkillEntity { SkillName = "SimilarWeb" };
        var crunchbase = new SkillEntity { SkillName = "Crunchbase" };
        var aarrr = new SkillEntity { SkillName = "AARRR-модель" };

        // ====== COPYWRITER SKILLS ======
        var googleDocs = new SkillEntity { SkillName = "Google Docs" };
        var notion = new SkillEntity { SkillName = "Notion" };
        var grammarly = new SkillEntity { SkillName = "Grammarly" };
        var yoast = new SkillEntity { SkillName = "Yoast SEO" };
        var semrush = new SkillEntity { SkillName = "SEMrush" };
        var wordpress = new SkillEntity { SkillName = "WordPress" };
        var tilda = new SkillEntity { SkillName = "Tilda" };
        var wix = new SkillEntity { SkillName = "Wix" };
        var storytelling = new SkillEntity { SkillName = "Сторителлинг" };
        var adPsychology = new SkillEntity { SkillName = "Маркетинг и психология рекламы" };
        var seoStrategy = new SkillEntity { SkillName = "SEO-стратегии" };
        var targetAdaptation = new SkillEntity { SkillName = "Адаптация под ЦА" };

        // ====== PROFESSIONS ======
        var frontendDeveloper = new ProfessionEntity
            { ProfessionName = "Frontend-разработчик", IndustryId = it.Id };
        var backendDeveloper = new ProfessionEntity
            { ProfessionName = "Backend-разработчик", IndustryId = it.Id };
        var fullstackDeveloper = new ProfessionEntity
            { ProfessionName = "Fullstack-разработчик", IndustryId = it.Id };
        var productAnalyst = new ProfessionEntity
            { ProfessionName = "Продакт-аналитик", IndustryId = it.Id };
        var brandManager = new ProfessionEntity
            { ProfessionName = "Brand-менеджер", IndustryId = marketing.Id };
        var productMarketer = new ProfessionEntity
            { ProfessionName = "Продакт-маркетолог", IndustryId = marketing.Id };
        var copywriter = new ProfessionEntity
            { ProfessionName = "Копирайтер", IndustryId = marketing.Id };
        var storeManager = new ProfessionEntity
            { ProfessionName = "Менеджер магазина", IndustryId = marketing.Id };
        var ecologist = new ProfessionEntity { ProfessionName = "Эколог", IndustryId = other.Id };

        // ====== SEED DATA ======
        modelBuilder.Entity<ProfessionSkillEntity>().HasData(
            new() { ProfessionId = frontendDeveloper.Id, SkillId = html.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = css.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = js.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = git.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = react.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = ts.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = codeReview.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = frontendDeveloper.Id, SkillId = optimization.Id, Level = SkillLevel.Senior },

            // Backend Developer
            new() { ProfessionId = backendDeveloper.Id, SkillId = python.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = backendDeveloper.Id, SkillId = nodejs.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = backendDeveloper.Id, SkillId = sql.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = backendDeveloper.Id, SkillId = git.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = backendDeveloper.Id, SkillId = rest.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = backendDeveloper.Id, SkillId = docker.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = backendDeveloper.Id, SkillId = microservices.Id, Level = SkillLevel.Senior },
            new() { ProfessionId = backendDeveloper.Id, SkillId = cloud.Id, Level = SkillLevel.Senior },
            new() { ProfessionId = backendDeveloper.Id, SkillId = scaling.Id, Level = SkillLevel.Senior },

            // Fullstack Developer
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = html.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = css.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = js.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = react.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = nodejs.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = python.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = sql.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = git.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = angular.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = rest.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = jenkins.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = githubActions.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = codeReview.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = awsEc2.Id, Level = SkillLevel.Senior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = cloud.Id, Level = SkillLevel.Senior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = microservices.Id, Level = SkillLevel.Senior },
            new() { ProfessionId = fullstackDeveloper.Id, SkillId = optimization.Id, Level = SkillLevel.Senior },

            // Brand Manager
            new() { ProfessionId = brandManager.Id, SkillId = swotMiro.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = brandManager.Id, SkillId = surveyMonkey.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = brandManager.Id, SkillId = googleForms.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = brandManager.Id, SkillId = canva.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = brandManager.Id, SkillId = illustrator.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = brandManager.Id, SkillId = illustrator.Id, Level = SkillLevel.Senior },

            // Product Marketer
            new() { ProfessionId = productMarketer.Id, SkillId = productboard.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = productMarketer.Id, SkillId = similarWeb.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = productMarketer.Id, SkillId = crunchbase.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = productMarketer.Id, SkillId = aarrr.Id, Level = SkillLevel.Senior },

            // Copywriter
            new() { ProfessionId = copywriter.Id, SkillId = googleDocs.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = copywriter.Id, SkillId = grammarly.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = copywriter.Id, SkillId = yoast.Id, Level = SkillLevel.Junior },
            new() { ProfessionId = copywriter.Id, SkillId = notion.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = semrush.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = wordpress.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = tilda.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = wix.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = storytelling.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = adPsychology.Id, Level = SkillLevel.Middle },
            new() { ProfessionId = copywriter.Id, SkillId = seoStrategy.Id, Level = SkillLevel.Senior },
            new() { ProfessionId = copywriter.Id, SkillId = targetAdaptation.Id, Level = SkillLevel.Senior },

            // Эколог
            new() { ProfessionId = ecologist.Id, SkillId = iso14001.Id, Level = SkillLevel.None },
            new() { ProfessionId = ecologist.Id, SkillId = simaPro.Id, Level = SkillLevel.None },
            new() { ProfessionId = ecologist.Id, SkillId = advocacy.Id, Level = SkillLevel.None },
            new() { ProfessionId = ecologist.Id, SkillId = ecology.Id, Level = SkillLevel.None },

            // Менеджер магазина
            new() { ProfessionId = storeManager.Id, SkillId = retailNext.Id, Level = SkillLevel.None },
            new() { ProfessionId = storeManager.Id, SkillId = teamManagement.Id, Level = SkillLevel.None },

            // Продакт-аналитик
            new() { ProfessionId = productAnalyst.Id, SkillId = sql.Id, Level = SkillLevel.None },
            new() { ProfessionId = productAnalyst.Id, SkillId = python.Id, Level = SkillLevel.None },
            new() { ProfessionId = productAnalyst.Id, SkillId = optimizely.Id, Level = SkillLevel.None },
            new() { ProfessionId = productAnalyst.Id, SkillId = dataDriven.Id, Level = SkillLevel.None }
        );

        modelBuilder.Entity<IndustryEntity>().HasData(it, marketing, other);
        modelBuilder.Entity<SkillEntity>().HasData(
            git, codeReview, jenkins, githubActions, optimization, html, css, js, ts, react,
            python, nodejs, sql, rest, docker, microservices, cloud, scaling, angular, awsEc2,
            swotMiro, surveyMonkey, googleForms, canva, illustrator,
            productboard, similarWeb, crunchbase, aarrr,
            googleDocs, notion, grammarly, yoast, semrush, wordpress, tilda, wix,
            storytelling, adPsychology, seoStrategy, targetAdaptation,
            iso14001, simaPro, advocacy, ecology,
            retailNext, teamManagement,
            optimizely, dataDriven
        );
        modelBuilder.Entity<ProfessionEntity>().HasData(
            frontendDeveloper, backendDeveloper, fullstackDeveloper,
            brandManager, productMarketer, copywriter, ecologist, storeManager, productAnalyst
        );
    }
}