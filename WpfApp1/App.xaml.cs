using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Запуск одной копии приложения
        System.Threading.Mutex mutex;

        private ServiceProvider serviceProvider;

        public App()
        {
            // Запрет на включение более одного экземпляра программы
            bool createdNew;
            string mutName = "MainWindow";
            mutex = new System.Threading.Mutex(true, mutName, out createdNew);

            if (!createdNew)
            {
                Shutdown();
            }
            else
            {
                ServiceCollection services = new ServiceCollection();
                ConfigureServices(services);
                serviceProvider = services.BuildServiceProvider();

                var mainWindow = serviceProvider.GetService<MainWindow>();

                // Если работаем через DI, обязательно убирать в app.xaml строку StartupUri="MainWindow.xaml"
                mainWindow.Show();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем главное окно как сервис, и вызываем его в OnStartup
            services.AddSingleton<MainWindow>();

            services.AddTransient<IQueryServiceClient, QueryServiceClient>();
            //services.AddMemoryCache();

            //services.AddControllers()
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.WriteIndented = true;
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});


            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            //services.Configure<Orenpay.Buffet.Models.AppSettings>(configuration);

            // Реализация HTTP через Dependency Injection; корневой путь для подключения указывается один раз и только здесь
            var baseURI = configuration.GetValue<string>("BaseURI");

            // Регистрация HttpClient с его baseURI, а также настройка, чтобы прокси не использовался, даже если он включен на машине
            services.AddHttpClient<IQueryServiceClient, QueryServiceClient>(client =>
            {

                client.BaseAddress = new Uri(baseURI);
                client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            });

        }
    }
}
