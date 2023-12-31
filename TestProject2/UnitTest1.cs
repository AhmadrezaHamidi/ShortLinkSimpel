using ClassLibrary1;

namespace TestProject2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var posetiveNUmber = new EventNUmber().And(new PosetiveNUmber());
        posetiveNUmber.IsStatisFieldBy(30);


    }
}