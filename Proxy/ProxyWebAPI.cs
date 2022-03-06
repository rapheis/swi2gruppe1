namespace swi2gruppe1.Proxy

{
    using swi2gruppe1.Data;
    public class ProxyWebAPI
    {
        public static WeatherForecast GetWeatherForecast()
        {
            Console.WriteLine("hier wäre der WebAPI Get-Aufruf...");
            WeatherForecast forecast = new WeatherForecast();
            forecast.TemperatureC = 25;
            forecast.Date = DateTime.Now;
            forecast.Summary = "Wetter von St. Gallen";
            return forecast;
        }
        public static void SendWeatherForecast(WeatherForecast forecast)
        {
            Console.WriteLine("hier würde das WebAPI aufgerufen.." + forecast.TemperatureC +
                " " + forecast.Summary);
        }
    }
}

