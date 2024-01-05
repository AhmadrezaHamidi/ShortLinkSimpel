namespace Iterator;

public class FruiteBaskate
{
    public string[] Furites = new[] { "Apple", "Banana" };

    public Iterator<string> CreateItertor()
    {
        return new fruiteItertor(Furites);
    } 

}

public class fruiteItertor : Iterator<string>
{
    private readonly string[] _fruites;
    private  int _index;
    public fruiteItertor(string[] fruites)
    {
        _fruites = fruites;
        _index = fruites.Length;
    }


    public bool isDone()
    {
        return _index == -_fruites.Length;
    }

    public void Next()
    {
        _index=+1;
    }

    public string CurrentItem()
    {
        return _fruites[_index];
    }
}



public interface Iterator<T>
{
    bool isDone();
    void Next();
    T CurrentItem();
} 
