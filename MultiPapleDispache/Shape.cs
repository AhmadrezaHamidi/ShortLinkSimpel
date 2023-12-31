namespace MultiPapleDispache;

public abstract class Shape
{
    public abstract void DrawOn(Board board);
}

public class Circle : Shape
{
    public override void DrawOn(Board board)
    {
        board.Draw(this);
    }
}

public class Square : Shape
{
    public override void DrawOn(Board board)
    {
        board.Draw(this);
    } 
}
public class Rectangle : Shape
{
    public override void DrawOn(Board board)
    {
        board.Draw(this);
    }  
}



