using ConsoleApp1;

//1
Root requete11 = await Service.Requete("q=Kingdom of Morocco");
Console.WriteLine("Weather like in Kingdom of Morocco is "+requete11.weather[0].description);

Root requete12 = await Service.Requete("q=Morocco");
Console.WriteLine("Weather like in Morocco is "+requete12.weather[0].description);

//2
Root requete2 = await Service.Requete("q=Oslo");
DateTime dateTimeRise = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
dateTimeRise = dateTimeRise.AddSeconds(requete2.sys.sunrise).ToLocalTime();
DateTime dateTimeSet = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
dateTimeSet = dateTimeSet.AddSeconds(requete2.sys.sunset).ToLocalTime();
Console.WriteLine("Oslo sunrise "+ dateTimeRise + " / "+ "Oslo sun set "+ dateTimeSet );

//3
Root requete3 = await Service.Requete("q=Jakarta");
Console.WriteLine("Jakarta temperature is "+requete3.main.temp+ "°c");

//4
string[] country = {"New York City,us", "Tokyo,JP","Paris,FR"};
var a = 0.0;
var index = 0;
var b = 0;
foreach (string i in country) 
{
    Root requete4 = await Service.Requete("q="+i);
    if (a < requete4.wind.speed)
    {
        a = requete4.wind.speed;
        b = index;
    }
    index++;
}
Console.WriteLine("the place where there is the most wind "+country[b]+ " wind speed is "+ a);

//5
string[] country2 = {"Kyiv,UA","Moscow,RU","Berlin,DE"};
foreach (string i in country2) 
{
    Root requete5 = await Service.Requete("q="+i);
    Console.WriteLine(i+" pressure level: "+requete5.main.pressure+" hPa humidity level: "+requete5.main.humidity+"%");
}