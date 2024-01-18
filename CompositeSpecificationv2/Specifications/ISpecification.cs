using System;
namespace CompositeSpecificationv2.Specifications
{
	public interface ISpecification<T>
	{
		bool IsStatisFieldBy(T value);
	}


    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsStatisFieldBy(T value);

        public Specification<T> And(ISpecification<T> left)
        {
            var ttt = new AndSpecification<T>(this, left);
            return ttt;
        }


    }



    public class PosetivNUmmber : ISpecification<int>
    {



        //Perdicate
        public bool IsStatisFieldBy(int value)
        {
           return  value > 0;
        }
    }


    //Composite Patterns

    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        protected ISpecification<T> _right;
        protected ISpecification<T> _left;

        protected CompositeSpecification(ISpecification<T> right, ISpecification<T> left)
        {
            _right = right;
            _left = left;
        }

        public abstract bool IsStatisFieldBy(T value);
        
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> right, ISpecification<T> left) : base(right, left)
        {
        }


        public override bool IsStatisFieldBy(T value)
        {
            var res = _right.IsStatisFieldBy(value) && _left.IsStatisFieldBy(value);
            return res;
        }

    }


    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(ISpecification<T> right, ISpecification<T> left) : base(right, left)
        {
        }


        public override bool IsStatisFieldBy(T value)
        {
            var res = _right.IsStatisFieldBy(value) ||  _left.IsStatisFieldBy(value);
            return res;
        }

    }




}

