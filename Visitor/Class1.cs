namespace Visitor;

public class Class1
{
}


public abstract class FileSysytemItem 
{
    public string Name;
    public abstract long size();

    public abstract void Accept(IFileSysyemVisitor visitor);
}

public  class File : FileSysytemItem
{
    private readonly long _ItemSize;

    public File(long itemSize)
    {
        _ItemSize = itemSize;
    }

    public override void Accept(IFileSysyemVisitor visitor)
    {
        visitor.Accept(this);
    }

    public override long size()
    {
        return _ItemSize;
    }
}


public class Directory : FileSysytemItem
{
    private readonly List<File> _files;

    public Directory( List<File> files)
    {
        _files = files;
    }

    public override void Accept(IFileSysyemVisitor visitor)
    {
        visitor.Accept(this);
    }

    public override long size()
    { 
        long res = 0;
        foreach (var VARIABLE in _files)
        {
            res += VARIABLE.size();
        }

        return res;
    }
}

//Which Directory has a longger files 
//Which Dorrectory hsa a lannger size 
//We must user Visitor Design pattern
