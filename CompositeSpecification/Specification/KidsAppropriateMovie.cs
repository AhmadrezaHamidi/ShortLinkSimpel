using System;
using CompositeSpecification.Model;

namespace CompositeSpecification.Specification
{
	public class KidsAppropriateMovie : Specification<Movie>
	{
		
        public override bool IsStatisfoeldBy(Movie value)
        {
            return value.Genre is Genre.Drama;
        }
    }




    public class NewMovie : Specification<Movie>
    {

        public override bool IsStatisfoeldBy(Movie value)
        {
            return value.PublishYear >= DateTime.Now.AddYears(-10);
        }
    }

    public class class1
    {
        public void set(int x)
        {
            var oldKidsMovie = new AndSpecification<Movie>(new KidsAppropriateMovie(), new NewMovie());

            var instanceMovie = new Movie()
            {
                Genre = Genre.Comedy,
                PublishYear = DateTime.Now
            };
             
            var ttt =  oldKidsMovie.IsStatisfoeldBy(instanceMovie);



        }
    }


}



