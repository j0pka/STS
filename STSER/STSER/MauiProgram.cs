using Microsoft.Extensions.Logging;
using Firebase.Database;
using Firebase.Database.Query;
using STSER;
using STSER.Model;

namespace STSER
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            Registration();
            return builder.Build();
        }

        public static void Registration()
        {
            FirebaseClient client = new FirebaseClient("https://stserdb-default-rtdb.firebaseio.com/");
            var orders = client.Child("Orders").OnceAsync<Order>();
            if (orders.Result.Count == 0)
            {
                client.Child("Orders").PostAsync(new Order { Title = "Копание ямы"});
                client.Child("Orders").PostAsync(new Order { Title = "Доставка груза" });
                client.Child("Orders").PostAsync(new Order { Title = "Доставка машины" });
            }
        }
    }
}