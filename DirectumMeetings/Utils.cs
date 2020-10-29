using System;
using System.Collections.Generic;
using System.Text;

namespace DirectumMeetings
{
  class Utils
  {
    public static DateTime TransformDate()
    {
      DateTime outDate;
      while (!DateTime.TryParse(Console.ReadLine(), out outDate))
      {
        Console.WriteLine("Дата была введена некорректно, введите дату заново");
      }
      return outDate;
    }
    public static string TransformMeetingToString(Meeting currentMeeting)
    {
      return ($"\nНазвание встречи : {currentMeeting.Titile} \n" +
         $"Дата начала встречи : {currentMeeting.StartDate:dd MMM yyyy HH:mm} \n" +
         $"Дата конца встречи : {currentMeeting.EndDate:dd MMM yyyy HH:mm}\n" +
         $"Дата напоминания о встрчечи : {currentMeeting.AlarmClock:dd MMM yyyy HH:mm}");
    }

    public static void TimerElapsed(Object sender, EventArgs args)
    {
      foreach (Meeting meeting in DailyPlanner.Meetings)
      {
        if (DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") == meeting.AlarmClock.ToString("dd MMM yyyy HH:mm:ss"))
          Console.WriteLine($"\nВам предстоит встреча!!!\n{Utils.TransformMeetingToString(meeting)}\n");
      }
    }
  }
}
