 namespace strategyDesingPatterns;

 public class Basket
 {
     public long  TotalPrice { get; set; }
 
     public void ApplayeDisCount(IDisCountStrategi disCount)
     {
         //...
         ///...TotalPrice
         this.TotalPrice -= disCount.Calculate(200);
     }
 }
 public class VipCustomerOff : IDisCountStrategi
  {
      public long Calculate(long totalPrice)
      {
          return totalPrice % 2;
      }
  }
 public interface IDisCountStrategi
 {
     long Calculate(long totalPrice);
 }