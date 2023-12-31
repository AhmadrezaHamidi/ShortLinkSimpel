namespace ClassLibrary1;

public class Class1
{
}



public interface ISpecification<T>
{
    public bool IsStatisFieldBy(T entity);
}

public abstract class CompositeSpecification<T> : ISpecification<T>
{
    public CompositeSpecification<T> And(ISpecification<T> right)
    {
        return new AndSpecification<T>(this, right);
    }
    
    public CompositeSpecification<T> Or(ISpecification<T> right)
    {
        return new OrSpecification<T>(this, right);
    }
    
    public CompositeSpecification<T> Not()
    {
        return new NotSpecification<T>(this);
    } 
    
    public abstract bool IsStatisFieldBy(T entity);
}





public class EventNUmber: CompositeSpecification<int>
{
    public override bool IsStatisFieldBy(int entity)
    {
        return entity % 2 == 0;
    }
}

public class PosetiveNUmber : CompositeSpecification<int>
{
    public override bool IsStatisFieldBy(int entity)
    {
        return entity > 0;
    }
}



public class NegetiveNUmber : CompositeSpecification<int>
{
    public override bool IsStatisFieldBy(int entity)
    {
        return entity < 0;
    }
}

public class AndSpecification<T> : CompositeSpecification<T>
{
    public ISpecification<T> Right  { get; set; }
    public ISpecification<T> Left  { get; set; }

    public AndSpecification(ISpecification<T> right, ISpecification<T> left)
    {
        Right = right;
        Left = left;
    }
    public override bool IsStatisFieldBy(T entity)
    {
        return Left.IsStatisFieldBy(entity) && Right.IsStatisFieldBy(entity);
    }
} 

public class OrSpecification<T> : CompositeSpecification<T>
{
    public ISpecification<T> Right  { get; set; }
    public ISpecification<T> Left  { get; set; }

    public OrSpecification(ISpecification<T> right, ISpecification<T> left)
    {
        Right = right;
        Left = left;
    }
    public override bool IsStatisFieldBy(T entity)
    {
        return Left.IsStatisFieldBy(entity) || Right.IsStatisFieldBy(entity);
    }
}



public class NotSpecification<T> : CompositeSpecification<T>
{
    public ISpecification<T> Right  { get; set; }

    public NotSpecification(ISpecification<T> right)
    {
        Right = right;
    }
    public override bool IsStatisFieldBy(T entity)
    {
        return  !Right.IsStatisFieldBy(entity);
    }
}



