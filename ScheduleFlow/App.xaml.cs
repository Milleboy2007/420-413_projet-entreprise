using Domaine.Context;
using Domaine.Interface;
using Domaine.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Employeur;
using ScheduleFlow.Pages.Gerant;
using ScheduleFlow.ViewModels.Employeur;
using ScheduleFlow.Pages.Employee;
using ScheduleFlow.Pages.Gerant;
using ScheduleFlow.Pages.Global;
using ScheduleFlow.Pages.Gerant.Components;
using ScheduleFlow.ViewModels.Employe;
using ScheduleFlow.ViewModels.Gerant;
using System.Configuration;
using System.Data;
using System.Windows;
using ScheduleFlow.ViewModels.Global;
using ScheduleFlow.NavBar;

namespace ScheduleFlow
{
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public App()
        {
            //1 - Charger le fichier appsettings.json en utilisant IConfiguration
            //Utilise SetBasePath en donnant le chemin par défaut AppDomain.CurrentDomain.BaseDirectory


            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();


            // 2 -  Créer la collection de services
            var services = new ServiceCollection();


            //3 - Ajouter DBContext dans la collection de service
            //Utilise SQLLIte et il faut aller chercher le chemin dans appsettings en utilisant GetConnectionString
            var connectionString = config.GetConnectionString("Default")
                .Replace("{AppBasePath}", AppDomain.CurrentDomain.BaseDirectory);

            services.AddDbContext<ScheduleFlowDBContexte>(options =>
            {
                options.UseSqlite(connectionString);
            });


            //4 - Ajouter les repository dans les services ainsi que son implémentation
            //Scoped ou Singleton ou Trascient?
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            services.AddScoped<IQuartRepository, QuartRepository>();
            services.AddScoped<IDispoRepository, DispoRepository>();
            services.AddScoped<ICreneauRepository, CreneauRepository>();
            services.AddScoped<IDemandeCongeRepository, DemandeCongeRepository>();
            services.AddScoped<IAnnonceRepository, AnnonceRepository>();

            // 5 - Ajouter les viewModels repository dans les services
            //Scoped ou Singleton ou Trascient?
            services.AddTransient<CreationCompteParGerantViewModel>();
            services.AddTransient<CreationCompteParEmployeurViewModel>();
            services.AddTransient<PageQuartGerantViewModel>();
            services.AddTransient<CreerQuartViewModel>();
            services.AddTransient<DetailQuartViewModel>();
            services.AddTransient<QuartEmployeViewModel>();
            services.AddTransient<DemandeCongeViewModel>();
            services.AddTransient<UtilisateurViewModel>();
            services.AddTransient<PageProfilViewModel>();

            // 6 - Ajouter les vues repository dans les services
            //Scoped ou Singleton ou Trascient?

            // --- NavBar ---
            services.AddTransient<NavEmployeur>();
            services.AddTransient<NavGerant>();
            services.AddTransient<NavEmploye>();

            // --- Page Global ---
            services.AddTransient<MainWindow>();
            services.AddTransient<Connexion>();
            services.AddTransient<PageProfil>();

            // --- Page Employe ---
            services.AddTransient<AccueilEmploye>();
            services.AddTransient<Dispo>();
            services.AddTransient<Page_Quart_Employee>();
            services.AddTransient<PageDemandeConge>();

            // --- Page Employeur ---
            services.AddTransient<CreationCompteParEmployeur>();

            // --- Page Gerant ---
            services.AddTransient<AccueilGerant>();
            services.AddTransient<Conge>();
            services.AddTransient<CreationCompteParGerant>();
            services.AddTransient<Page_Quart_Gerant>();
            services.AddTransient<CreationQuart>();
            services.AddTransient<DetailQuart>();
            services.AddTransient<PubAnnonceGerant>();

            // --- Gestionnaire de Seesion ---
            services.AddSingleton<GestionnaireSession>();
            
            // 7 - Construit le service provider avec la méthode BuildServiceProvider
            ServiceProvider = services.BuildServiceProvider();

            /*Ceci est pour exécuter les migrations automatiquement s'il y en qui ne sont pas
             * exécutés, puisqu'en production, on ne pas executer la commande manuellement
             * */
            using (var scope = ServiceProvider.CreateScope())
            {
                // 2. On demande le DBContext à l'intérieur de cette zone
                var db = scope.ServiceProvider.GetRequiredService<ScheduleFlowDBContexte>();
                db.Database.Migrate();
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Ici demande Le MainWindow à partir du service provider
            //et affiche avec la méthode Show

            ServiceProvider.GetRequiredService<MainWindow>().Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (ServiceProvider is IDisposable d)
            {
                d.Dispose();
            }
            base.OnExit(e);
        }
    }

}
