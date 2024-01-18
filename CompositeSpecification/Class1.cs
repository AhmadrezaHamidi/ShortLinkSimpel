namespace CompositeSpecification;



public interface ISpecification<T>
{
    public  bool IsStatisfoeldBy(T value);
}



public abstract class Specification<T> : ISpecification<T>
{
    public abstract bool IsStatisfoeldBy(T value);

    public Specification<T> And(ISpecification<T> left)
    {
        var res =  new AndSpecification<T>(this, left);
        return res;
    }

}



public abstract class CompositeSpecification<T> : ISpecification<T>
{

    protected ISpecification<T> _right;
    protected ISpecification<T> _left;

    protected CompositeSpecification(ISpecification<T> right,
        ISpecification<T> left)
    {
        _right = right;
        _left = left;
    }

    public abstract bool IsStatisfoeldBy(T value);
   
}



public class AndSpecification<T> : CompositeSpecification<T>
{
    public AndSpecification(ISpecification<T> right, ISpecification<T> left) : base(right, left)
    {
    }

    public override bool IsStatisfoeldBy(T value)
    {
        return _right.IsStatisfoeldBy(value)
            && _left.IsStatisfoeldBy(value);
    }
}




public class OrSpecification<T> : CompositeSpecification<T>
{
    public OrSpecification(ISpecification<T> right,
        ISpecification<T> left) : base(right, left)
    {
    }

    public override bool IsStatisfoeldBy(T value)
    {
        return _right.IsStatisfoeldBy(value)
            && _left.IsStatisfoeldBy(value);
    }
}