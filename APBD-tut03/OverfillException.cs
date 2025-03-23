namespace APBD_tut03;

public class OverfillException : Exception
{
   public OverfillException()
   {
      
   }

   public OverfillException(string message):base(message)
   {
   }

   public OverfillException(string message, Exception inner) : base(message, inner)
   {
   }
}