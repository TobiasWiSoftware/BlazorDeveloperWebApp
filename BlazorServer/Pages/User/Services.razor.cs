using SharedLibrary.Dtos;

namespace BlazorServer.Pages.User
{
    public partial class Services
    {
        public List<SectionComponentProjectsDto> SectionComponentItems { get; set; } = new();

        public Services()
        {
            SectionComponentItems.Add(new SectionComponentProjectsDto(
                   title: "Frontend Lösungen",
                   description: "Frontend-Designs für ausgezeichnete, moderne und responsive Benutzeroberflächen.",
                   new List<SectionComponentProjectDto> {
                new SectionComponentProjectDto(
                    title: "Tax Calculator UI entwickelt mit Blazor",
                    description: @"Ein einfaches responsives Bootstrap- und CSS-Design. Schauen Sie sich die <a href='https://taxcal.tobias-wi-software.com' target='_blank'>Live-Version</a> und den <a href='https://github.com/TobiasWiSoftware/TaxCalculatorWithAPI' target=""_blank"">Quellcode.</a>",
                    sliderImagesBase64Data: new List<string> { "Pictures/projects/frontend_blazor.png", "Pictures/projects/backend_java_1.png" }
                ),
                new(
                    title: "AI Chat Bot entwickelt mit React und Flask",
                    description: @"Ein einfaches, responsives Bootstrap- und CSS-Design. Schauen Sie sich die <a href='https://brutto-netto-steuerrechner.de' target=""_blank"">Live-Version</a> an und den <a href=""https://github.com/TobiasWiSoftware/TaxCalculatorWithAPI"" target=""_blank"">Quellcode.</a> an",
                    sliderImagesBase64Data: new List<string> { "Pictures/projects/frontend_react_1.png", "Pictures/projects/frontend_react_2.png" }
                ),
                new(
                    title: "Schülerspiel entwickelt mit Angular und Spring API",
                    description: @"Ein einfaches Spiel um Schülernamen anhand von Fotos zu erraten. Schauen Sie sich den <a href=""https://github.com/TobiasWiSoftware/PupilGuessing"" target=""_blank"">Quellcode.</a> an",
                    sliderImagesBase64Data: new List<string> { "Pictures/projects/frontend_angular_1.png", "Pictures/projects/frontend_angular_2.png" }
                ),
                new(
                    title: "E-Commerce Shop entwickelt mit WPF",
                    description: @"Ein einfaches Tool zur Verwaltung von Produkten inkl. Bildern, Bestellungen und Kundenanmeldungen. Schauen Sie sich den <a href=""https://github.com/TobiasWiSoftware/WebShop"" target=""_blank"">Quellcode.</a> an",
                    sliderImagesBase64Data: new List<string> { "Pictures/projects/frontend_wpf_1.png", "Pictures/projects/frontend_wpf_2.png" }
                 )

                   },

                new List<SectionComponentIconDto> {
                    new(iconsBase64Data: "Pictures/symbols/Blazor.png", linkData: "https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor"),
                    new(iconsBase64Data: "Pictures/symbols/Dotnet.png", linkData: "https://dotnet.microsoft.com/"),
                    new(iconsBase64Data: "Pictures/symbols/Angular.png", linkData: "https://angular.io/"),
                    new(iconsBase64Data: "Pictures/symbols/React.png", linkData: "https://react.dev/"),
                    new(iconsBase64Data: "Pictures/symbols/Wpf.png", linkData: "https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0")
                   },
                "frontend"
                   ));


            SectionComponentItems.Add(new SectionComponentProjectsDto(
                    title: "Backend Vorlagen",
                    description: "Backend-Daten bereitgestellt mit sauberem Code und modernem Datenbankdesign.",
            new List<SectionComponentProjectDto> {
            new SectionComponentProjectDto(
                title: "Taxcalculator Server-Code mit ASP.Net Web API",
                description: "Eine einfache, saubere und schnelle C# API mit automatischer JSON-Serialisierung, Identity Framework und Entity Framework mit SQLite",
                sliderImagesBase64Data: new List<string> { "Pictures/projects/backend_asp_1.png", "Pictures/projects/backend_asp_2.png" }
            ),
            new(
                title: "AI Chat Bot Server-Code mit Flask",
                description: "Python API basierend auf einfacher Skripterstellung Test und AI-Bibliothek",
                sliderImagesBase64Data: new List<string> { "Pictures/projects/backend_python_1.png" }
            ),
            new(
                title: "Schülerspiel Server-Code mit Spring Boot",
                description: "Professionelle Java-Lösung mit JPA und MySQL",
                sliderImagesBase64Data: new List<string> { "Pictures/projects/backend_java_1.png", "Pictures/projects/backend_java_2.png" }
            ),
            new(
                title: "Konsolenspiele",
                description: "Übungen zur Verbesserung meiner Praxis mit Algorithmen und Architektur",
                sliderImagesBase64Data: new List<string> { "Pictures/projects/backend_consolegame_1.png", "Pictures/projects/backend_consolegame_2.png" }
            )
             },
            new List<SectionComponentIconDto> {
                new(iconsBase64Data: "Pictures/symbols/Dotnet.png", linkData: "https://dotnet.microsoft.com/"),
                new(iconsBase64Data: "Pictures/symbols/Springboot.png", linkData: "https://spring.io/"),
                new(iconsBase64Data: "Pictures/symbols/Flask.png", linkData: "https://flask.palletsprojects.com/"),
                new(iconsBase64Data: "Pictures/symbols/MySql.png", linkData: "https://www.mysql.com/"),
                new(iconsBase64Data: "Pictures/symbols/Postgres.png", linkData: "https://www.postgresql.org"),
                new(iconsBase64Data: "Pictures/symbols/SQLite.png", linkData: "https://www.sqlite.org/index.html"),
                new(iconsBase64Data: "Pictures/symbols/SqlServer.png", linkData: "https://en.wikipedia.org/wiki/Microsoft_SQL_Server")
             },
            "backend"
            ));

            SectionComponentItems.Add(new SectionComponentProjectsDto(
    title: "DevOps und Hosting Lösungen",
    description: "Engineering, Testen und Hosting aller modernen Frameworks in Docker. Diese Methode ist sauber, zuverlässig, plattformunabhängig und vermeidet die meisten Fehler beim traditionellen Serverhosting.",
    new List<SectionComponentProjectDto> {
        new SectionComponentProjectDto(
            title: "Steuerrechner mit Client-Server-Architektur",
            description: "Gehostet auf einem Ubuntu VPS mit Docker, Docker Compose und internem Netzwerk",
            sliderImagesBase64Data: new List<string> { "Pictures/projects/devops_taxcalculator_1.png", "Pictures/projects/devops_taxcalculator_2.png" }

        ),
        new(
            title: "TimeStamp mit MVC-Architektur",
            description: "Funktioniert auf VPS und Docker Desktop mit https. Importiert ein Postgres DB-Image und Backup-Volume",
            sliderImagesBase64Data: new List<string> { "Pictures/projects/devops_timestamp_1.png", "Pictures/projects/devops_timestamp_2.png" }
        )
    },
    new List<SectionComponentIconDto> {
        new(iconsBase64Data: "Pictures/symbols/Docker.png", linkData: "https://www.docker.com/"),
        new(iconsBase64Data: "Pictures/symbols/Docker-Compose.png", linkData: "https://docs.docker.com/compose/"),
        new(iconsBase64Data: "Pictures/symbols/Linux.png", linkData: "https://www.linux.org/"),
        new(iconsBase64Data: "Pictures/symbols/Windows.png", linkData: "https://microsoft.com/"),
        new(iconsBase64Data: "Pictures/symbols/VS.png", linkData: "https://visualstudio.microsoft.com/de/"),
        new(iconsBase64Data: "Pictures/symbols/VSC.png", linkData: "https://code.visualstudio.com/"),
        new(iconsBase64Data: "Pictures/symbols/Git.png", linkData: "https://git-scm.com/"),
        new(iconsBase64Data: "Pictures/symbols/AwsLamda.png", linkData: "https://aws.amazon.com/de/lambda/")
    },
    "devops"
        ));





        }
    }
}
