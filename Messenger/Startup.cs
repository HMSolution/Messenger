using System;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EventStores.EventStore.Extensions;
using EventFlow.Extensions;
using EventFlow.MongoDB.Extensions;
using EventFlow.Subscribers;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Messenger.Eventflow.Messaging;
using Messenger.Eventflow.Messaging.Events;
using Messenger.Eventflow.Messaging.Subscriber;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Messenger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Session state ermöglichen
            services.AddRazorPages();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddMemoryCache();
            services.AddMvc();

            //Eventflow Konfiguration
            var eventflowDatabasesettings = new DatabaseSettings();
            this.Configuration.GetSection("DatabaseSettings").Bind(eventflowDatabasesettings);

            ConnectionSettingsBuilder connectionSettings = ConnectionSettings.Create()
                .SetDefaultUserCredentials(new UserCredentials(eventflowDatabasesettings.EventstoreUser, eventflowDatabasesettings.EventstorePW));

            services.AddEventFlow(o =>
            {
                o.AddDefaults(typeof(Program).Assembly); //Reinladen der Assembly (Projekt wo Commands, Handler und Events sind, können auch mehrere Projekte sein)
                o.Configure(c => c.IsAsynchronousSubscribersEnabled = true); //Enable subscribers

                o.UseEventStoreEventStore(new Uri(eventflowDatabasesettings.EventStoreUri), connectionSettings);//Eventstore einrichten
                o.ConfigureMongoDb(eventflowDatabasesettings.MongoDBUri, eventflowDatabasesettings.DatabaseReadModels); //MOngoDb einrichten

                o.UseMongoDbReadModel<ConversationReadModel>(); //ReadModel registrieren

                o.AddAspNetCore(); //Asp.Net core bootstrapper verwenden (startet den IBootstrapper von Eventflow), ab core 3.0 notwendig
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
