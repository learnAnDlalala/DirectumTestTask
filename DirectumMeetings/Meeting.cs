using System;
using System.Collections.Generic;
using System.Text;

namespace DirectumMeetings
{
 public class Meeting
  {
    private string title;
    private DateTime startDate;
    private DateTime endDate;
    private DateTime alarmClock;

    public String Titile
    {
      get
      {
        return this.title;
      }
      set
      {
        while (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
          Console.WriteLine("Введите название встречи");
          value = Console.ReadLine();
        }
        this.title = value;
      }
    }
    public DateTime StartDate
    {
      get
      {
        return this.startDate;
      }
      set
      {
        while (DateTime.Compare(value, DateTime.Now) <= 0)
        {
          Console.WriteLine("Встреча планируется только на будущий период, введите новую дату встречи");
          //добавить
         value = Utils.TransformDate();
        }
        this.startDate = value;
      }
    }

    public DateTime EndDate
    {
      get
      {
        return this.endDate;
      }
      set
      {
        while (DateTime.Compare(value, this.StartDate) <= 0)
        {
          Console.WriteLine("Окончание встречи не может быть раньше начала");
          //добавить
          value = Utils.TransformDate();
        }
        this.endDate = value;
      }
    }
    public DateTime AlarmClock
    {
      get
      {
        return this.alarmClock;
      }
      set
      {
        while ((DateTime.Compare(value, this.StartDate) > 0) || (DateTime.Compare(value, DateTime.Now) < 0))
        {
          Console.WriteLine("Напоминание должно быть установленно позже сегоднящней даты и не раньше даты начала встречи");
          //добавить
         value = Utils.TransformDate();
        }
        this.alarmClock = value;
      }
    }
    public string ShowMeeting()
    {
      return "sdsadsadsa template";
    }

    public bool Equals (Meeting meeting)
    {
      return false;
    }
  }
}
