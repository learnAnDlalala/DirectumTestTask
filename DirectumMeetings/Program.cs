using System;
using System.Timers;

namespace DirectumMeetings
{
  class Program
  {
    static void Main(string[] args)
    {
     Initilize();     
    }
    public static void Initilize ()
    {
      var timer = new Timer
      {
        Interval = 1000,
        Enabled = true
      };
      timer.Elapsed += Utils.TimerElapsed;
      new Menu().Start();
    }
  }
}
