using System;
using CompositeSpecificationv2.Model;

namespace CompositeSpecificationv2.Specifications
{
    public class KidsAppropaiteMovie : Specification<Movie>
    {
        public override bool IsStatisFieldBy(Movie value)
        {
            return value.CreatedAt > DateTime.Now.AddYears(-10);
        }
    }



    public class CommmedeyAppropaiteMovie : Specification<Movie>
    {
        public override bool IsStatisFieldBy(Movie value)
        {
            return value.Genar > Genar.comedy;
        }
    }
}

