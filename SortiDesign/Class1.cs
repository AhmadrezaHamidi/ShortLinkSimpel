namespace SortiDesign;


public class Prodeuct
{
    public Prodeuct()
    {
            
    }

    private Prodeuct(string name, long prise)
    {
        Name = name;
        Prise = prise;
    }

    public string Name { get; set; }
    public long Prise { get; set; }
    
    public List<Prodeuct> GetProductes()
    {
        var res = new List<Prodeuct>();
        for (int i = 0; i < 100; i++)
        {
            res.Add(new Prodeuct($"name{i}" ,i+956 ));
        }

        return res;
    }   

}

public interface ISortEstertegi
{
    public List<Prodeuct> Sort(List<Prodeuct> products );
}

public class SortByName : ISortEstertegi
{
    public List<Prodeuct> Sort(List<Prodeuct> products )
    {
         products.Sort((product1, product2) => product1.Name.CompareTo(product2.Name));
         return products;      
    }
}



public class SortById : ISortEstertegi
{
    public List<Prodeuct> Sort(List<Prodeuct> products )
    {
         products.Sort((product1, 
             product2) => product1.Prise.CompareTo(product2.Prise));
         return products;      
    }
}


public class SortPeodustes
{
    private ISortEstertegi _sortEstertegi;

    public SortPeodustes(ISortEstertegi sortEstertegi)
    {
        this._sortEstertegi = sortEstertegi;
    }
    public List<Prodeuct> Sort(List<Prodeuct> products )
    {
        return _sortEstertegi.Sort(products);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var pro = new Prodeuct();

        var pros = pro.GetProductes();

        var sort = new SortById();
        
        var navigator = new SortPeodustes(sort);

       var ttt =  navigator.Sort(pros);

        foreach (var VARIABLE in ttt)
        {
            Console.WriteLine(VARIABLE.Prise);
        }
    }
}


