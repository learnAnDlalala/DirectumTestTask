using System;
using System.Collections.Generic;
using System.Text;

namespace DirectumMeetings
{
  public static class DailyPlanner
  {
    public static List<Meeting> Meetings = new List<Meeting>();

    public static void AddMeeting()
    {
      var newMeeting = new Meeting();
      SetTitle(newMeeting);
      do
      {
        SetStartDate(newMeeting);
        SetEndDate(newMeeting);
      }
      while (VerificationMeetingByDate(newMeeting) == true);
      SetAlarmClock(newMeeting);
      Meetings.Add(newMeeting);
    }

    public static void SetTitle (Meeting currentMeeting)
    {
      Console.WriteLine("Введите название встречи");
      currentMeeting.Titile = Console.ReadLine();
    }

    public static void SetStartDate (Meeting currentMeeting)
    {
      Console.WriteLine("Введите дату начала встречи");
      currentMeeting.StartDate = Utils.TransformDate();
    }
    public static void SetEndDate(Meeting currentMeeting)
    {
      Console.WriteLine("Введите дату окончания встречи");
      currentMeeting.EndDate = Utils.TransformDate();
    }
    public static void SetAlarmClock (Meeting currentMeeting)
    {
      Console.WriteLine("Введите дату напоминания о встрече");
      currentMeeting.AlarmClock = Utils.TransformDate();
    }
    public static List<Meeting> FindAllMeetings (DateTime date)
    {
      return Meetings.FindAll(el => el.StartDate <= date.AddDays(1) && el.EndDate>= date);
    }
    public static bool VerificationMeetingByDate (Meeting newMeeting)
    {
     if (Meetings.Exists(meeting => DateTime.Compare(newMeeting.StartDate, meeting.EndDate)<= 0 && DateTime.Compare(newMeeting.EndDate, meeting.StartDate) >= 0))
      {
        Console.WriteLine("Встречи пересекаются, выберите другие даты");
        return true;
      }
      return false;
    }
  }
}
