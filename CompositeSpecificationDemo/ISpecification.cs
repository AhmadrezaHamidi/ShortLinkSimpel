namespace CompositeSpecificationDemo;

public interface ISpecification<T>
{
    public bool IsStatisFieldBy(T entity);
}

public class EventNUmber: ISpecification<int>
{
    public bool IsStatisFieldBy(int entity)
    {
        return entity % 2 == 0;
    }
}

public class PosetiveNUmber : ISpecification<int>
{
    public bool IsStatisFieldBy(int entity)
    {
        return entity > 0;
    }
}



public class NegetiveNUmber : ISpecification<int>
{
    public bool IsStatisFieldBy(int entity)
    {
        return entity < 0;
    }
}

public class AndSpecification<T> : ISpecification<T>
{
    public ISpecification<T> Right  { get; set; }
    public ISpecification<T> Left  { get; set; }

    public AndSpecification(ISpecification<T> right, ISpecification<T> left)
    {
        Right = right;
        Left = left;
    }
    public bool IsStatisFieldBy(T entity)
    {
        return Left.IsStatisFieldBy(entity) && Right.IsStatisFieldBy(entity);
    }
} 

public class OrSpecification<T> : ISpecification<T>
{
    public ISpecification<T> Right  { get; set; }
    public ISpecification<T> Left  { get; set; }

    public OrSpecification(ISpecification<T> right, ISpecification<T> left)
    {
        Right = right;
        Left = left;
    }
    public bool IsStatisFieldBy(T entity)
    {
        return Left.IsStatisFieldBy(entity) || Right.IsStatisFieldBy(entity);
    }
}



public class NotSpecification<T> : ISpecification<T>
{
    public ISpecification<T> Right  { get; set; }

    public NotSpecification(ISpecification<T> right)
    {
        Right = right;
    }
    public bool IsStatisFieldBy(T entity)
    {
        return  !Right.IsStatisFieldBy(entity);
    }
}




