namespace MultiPapleDispache;


public abstract class Board
{
    public abstract void Draw(Circle Circle);
    public abstract  void  Draw(Square Circle);
    public abstract  void Draw(Rectangle Circle);
}

public class WhiteBoard : Board
{
    public override void Draw(Circle Circle)
    {
        throw new NotImplementedException();
    }

    public override void Draw(Square Circle)
    {
        throw new NotImplementedException();
    }

    public override void Draw(Rectangle Circle)
    {
        throw new NotImplementedException();
    }
}