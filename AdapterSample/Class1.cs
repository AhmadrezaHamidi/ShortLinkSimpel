namespace AdapterSample;

/// <summary>
/// Adapter is a Structural Design Pattern that allows incompatible interfaces between classes to work together without modifying
/// their source code.
/// It acts as a bridge between two interfaces, making them compatible so
/// that they can collaborate and interact seamlessly
/// </summary>
  
//Change voltaj  
public interface ILogger
{
    void WrtiteDebug(string message);
    void WrtiteInfo(string message);
    void WrtiteWarning(string message);
}


public class SeriLogAdapter : ILogger 
{
    public void WrtiteDebug(string message)
    {
        throw new NotImplementedException();
    }

    public void WrtiteInfo(string message)
    {
        throw new NotImplementedException();
    }

    public void WrtiteWarning(string message)
    {
        throw new NotImplementedException();
    }
}



public class Node4nNetAdapter : ILogger
{
    
    /// <summary>
    ///  ..Log4net
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="NotImplementedException"></exception>
    
    public void WrtiteDebug(string message)
    {
    //Log$NetOgger.
    }

    public void WrtiteInfo(string message)
    {
        throw new NotImplementedException();
    }

    public void WrtiteWarning(string message)
    {
        throw new NotImplementedException();
    }
} 


 