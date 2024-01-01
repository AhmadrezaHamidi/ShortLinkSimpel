using Visitor;

namespace VisitorTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
       
        
        var fileOne = new  Visitor.File(20);
        var fileTwo = new  Visitor.File(30);
        var fileThree = new  Visitor.File(40);

        var listFiles = new List<Visitor.File>();
        listFiles.Add(fileOne);
        listFiles.Add(fileTwo);
        listFiles.Add(fileThree);
        
        var directories = new Visitor.Directory(listFiles);


        var visitor = new MaxFileSysyemVisitor();
        directories.Accept(visitor);


    }
}