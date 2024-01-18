namespace StatePatterns;
public class Class1
{

}

public class LoanReqest
{
    public long Amounte { get;private set; }
    public TimeSpan LoanDuration { get;private set; }
    public LoanReqestState state { get;private set; }

    public void Update(long amounte,
        TimeSpan duration)
    {
        if (this.state == LoanReqestState.Draft)
        {
            this.Amounte = amounte;
            this.LoanDuration = duration;
        }
        else
        {
            throw new Exception("Invalid data");
        }
         }

    /// <summary>
    /// after some time we have a lot of if and esle
    /// for this problem we use the state patterns 
    /// </summary>
    /// <exception cref="Exception"></exception>
    public void accept()
    {
        if (this.state is LoanReqestState.InProgress)
            this.state = LoanReqestState.Acceptd;
        else
            throw new Exception("!!!!!!!");

    }
    


}

public enum LoanReqestState
{
    Draft,
    Regected,
    Acceptd,
    InProgress
}

