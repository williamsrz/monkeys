using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using MonkeysApi.DataObjects;
using MonkeysApi.Models;
using Owin;

namespace MonkeysApi
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<Monkey> monkeys = new List<Monkey>
            {
                new Monkey {
                    Id = Guid.NewGuid().ToString(),
                    Name = "William S. Rodriguez",
                    MiniBio = "Mobile developer, community enthusiast @Microsoft & @Xamarin MVP, Co-Founder/Host @MonkeyNightsDev",
                    AvatarUrl = "https://pbs.twimg.com/profile_images/810196936674447360/aLsB7NAg.jpg",
                    Twitter = "@WilliamSRodz"
                },
                 new Monkey {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Angelo Belchior",
                    MiniBio = "Microsoft MVP, Xamarin Moonwalker, .Net Developer, Lead Software Developer @ ESX",
                    AvatarUrl = "https://pbs.twimg.com/profile_images/714553677122547713/srRapcdC.jpg",
                    Twitter = "@angelobelchior"
                },
                  new Monkey {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Alexandre Chohfi",
                    MiniBio = "UWP, Xamarin, MVVMCross, MonoGame, WinPhone, XBox! Software Engineer at @Microsoft! Former-Microsoft MVP.",
                    AvatarUrl = "https://pbs.twimg.com/profile_images/847819814274027520/wrPJaXhG.jpg",
                    Twitter = "@AlexandreChohfi"
                },
                   new Monkey {
                    Id = Guid.NewGuid().ToString(),
                    Name = "William Barbosa",
                    MiniBio = "Professional Nerd, Speaker, Speed Cuber, Amateur Musician, @Microsoft MVP, Mobile Developer @toggl, Co-Founder/Host @MonkeyNightsDev",
                    AvatarUrl = "https://pbs.twimg.com/profile_images/836881775787913216/RywpQcFk.jpg",
                    Twitter = "@willdotnet"
                }  
            };

            foreach (Monkey monkey in monkeys)
            {
                context.Set<Monkey>().Add(monkey);
            }

            base.Seed(context);
        }
    }
}

