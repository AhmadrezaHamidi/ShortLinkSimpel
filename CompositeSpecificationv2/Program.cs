// See https://aka.ms/new-console-template for more information
using CompositeSpecificationv2.Model;
using CompositeSpecificationv2.Specifications;

Console.WriteLine("Hello, World!");


var movieInstance = new Movie()
{
    CreatedAt = DateTime.Now,
    Genar = Genar.comedy,
    Rate = Rate.a
};


var oldKisdsMovie = new  KidsAppropaiteMovie().And(new CommmedeyAppropaiteMovie());
var tttt =  oldKisdsMovie.IsStatisFieldBy(movieInstance);
