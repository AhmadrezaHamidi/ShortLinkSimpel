using System;
namespace CompositeSpecification.Model
{
	public class Movie
	{
		public DateTime PublishYear { get; set; }
		public RateRmum Rate { get; set; }
		public Genre Genre { get; set; }
    }

	public enum RateRmum
	{
		a,
		b,
		c
	}


	public enum Genre
	{
		Comedy,
		Drama,
		Documentory
	}


}

