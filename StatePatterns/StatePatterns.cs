using System;
using System.Reflection.Emit;

namespace StatePatterns
{
	public class StatePatterns
	{
		public StatePatterns()
		{
		}
	}
    /// <summary>
    /// ImmutableUserType for save Custome DataType in database in inhibenet
    /// Value Convension forn dave Custome DataType in database in entityFramWork 
    /// </summary>



    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder
    //        .Entity<Rider>()
    //        .Property(e => e.Mount)
    //        .HasConversion(
    //            v => v.ToString(),
    //            v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));
    //}
    ///https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations


    public class AdvencedLoanReqest
    {
        public long Amounte { get; private set; }
        public TimeSpan LoanDuration { get; private set; }
        public LoadReqestState state { get; private set; }

        public AdvencedLoanReqest()
        {
          this.state = new DraftSate();
        }

         

        public void Update(long amounte,
            TimeSpan duration)
        {
            if (this.state.CanUpdateReqest())
            {
                this.Amounte = amounte;
                this.LoanDuration = duration;
            }
            else
            {
                throw new Exception("Invalid data");
            }
        }
    }




    /// <summary>
    /// class Context classi ast loadReqest yani raftresh ba tavajio
    /// be on statesh farq mikonad 
    /// </summary>
    public abstract class LoadReqestState
	{
		public virtual bool CanUpdateReqest() => false;
        public virtual bool CanAcccept() => false;
	}

    public class DraftSate : LoadReqestState
    {
        public override bool CanUpdateReqest() => true;
    }


    public class InProgressSate : LoadReqestState
    {
        public override bool CanAcccept() => true;
    }


    public class RegectedSate : LoadReqestState
    {

    }


    public class AcceptedSate : LoadReqestState
    {

    }


}

