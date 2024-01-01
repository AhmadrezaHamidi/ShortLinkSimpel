namespace Visitor;

public interface IFileSysyemVisitor
{
    public void Accept(Directory item);
    public void Accept(File item);
}


public class FileSysyemVisitor : IFileSysyemVisitor
{
    private long maxSize;
    public void Accept(Directory item)
    {
        //if (item.size() > maxSize)
        //{
        //    maxSize = item.size();
        //}
    }

    public void Accept(File item)
    {
        if (item.size() > maxSize)
        {
            maxSize = item.size();
        }
    }
}


public class MaxFileSysyemVisitor : IFileSysyemVisitor
{
    private long maxSize;
    public void Accept(Directory item)
    {
        //if (item.size() > maxSize)
        //{
        //    maxSize = item.size();
        //}
    }

    public void Accept(File item)
    {
        if (item.size() > maxSize)
        {
            maxSize = item.size();
        }
    }
}

// public class Test
//
// {
//     var file = new File(29);
//     var file2 = new File(40);
//     var file3 = new File(550);
//     var file -
//
//     var root = new Directory(new List<File>().Add(File));
//     var root2 = new Directory(new List<File>()
//         .Add(file2));
//
//         
// }