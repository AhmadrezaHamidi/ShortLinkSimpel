using System;
namespace CompositeSpecificationv2.Model
{
	public class Movie
	{
		public DateTime CreatedAt { get; set; }
		public Genar Genar { get; set; }
		public Rate Rate { get; set; }


	}

	public enum Rate
	{
		a,
		b,c
	}


	public enum Genar
	{
		comedy,
		scre,
		normal
	}

}

