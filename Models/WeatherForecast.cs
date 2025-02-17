namespace ASP_TEST_3ITB.Models
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);


        public WeatherForecast(DateOnly date, int tempC, string sum)
        {
            this.Date = date;
            this.TemperatureC = tempC;
            this.Summary = sum;
        }
    }
}