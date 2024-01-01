namespace StrategyiDesign;





public interface IRouteStrategy
{
    public string CalculateRoute(string start, string End);
}


public class CarStrategy : IRouteStrategy
{
    public string CalculateRoute(string start, string end)
    {
        return $"Route calculated for car from {start} to {end}";
    }
}

public class TrainStrategy : IRouteStrategy
{
    public string CalculateRoute(string start, string end)
    {
        return $"Route calculated for train from {start} to {end}";
    }
}

public class WalkingStrategy : IRouteStrategy
{
    public string CalculateRoute(string start, string end)
    {
        return $"Route calculated for walking from {start} to {end}";
    }
}


public class Navigator
{
    private IRouteStrategy _strategy;

    public void SetStrategy(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public string CalculateRoute(string start, string end)
    {
        return _strategy.CalculateRoute(start, end);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var navigator = new Navigator();

        // انتخاب استراتژی رانندگی با اتومبیل
        navigator.SetStrategy(new CarStrategy());
        Console.WriteLine(navigator.CalculateRoute("خانه", "دفتر کار"));

        // تغییر استراتژی به قطار
        navigator.SetStrategy(new TrainStrategy());
        Console.WriteLine(navigator.CalculateRoute("خانه", "دانشگاه"));
    }
}


