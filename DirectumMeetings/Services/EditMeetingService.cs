using System;
using System.Collections.Generic;
using System.Text;

namespace DirectumMeetings.Services
{
  class EditMeetingService
  {
    public Meeting currentMeeting;
    public EditMeetingService(Meeting meeting)
    {
      this.currentMeeting = meeting;
    }
    public void ChooseAction(int action)
    {
      switch (action)
      {
        case 1:
          ChangeMeetingTitile();
          break;
        case 2:
          ChangeStartDate();
          break;
        case 3:
          ChangeEndDate();
          break;
        case 4:
          ChangeAlarmClock();
          break;
        case 5:
          new Menu().Start();
          break;
      }
    }
    public void ChangeMeetingTitile()
    {
      Console.Clear();
      DailyPlanner.SetTitle(this.currentMeeting);
      new MeetingEditMenu(this.currentMeeting).Start();
    }

    private void ChangeStartDate()
    {
      Console.Clear();
      DailyPlanner.SetStartDate(this.currentMeeting);
      if (DateTime.Compare(this.currentMeeting.StartDate, this.currentMeeting.EndDate) > 0)
      {
        Console.WriteLine("\n Окончание встречи не может быть раньше начала, измените дату окончания встречи. \n Для продолжения нажмите любую клавишу");
        Console.ReadKey();
        ChangeEndDate();
      }
      new MeetingEditMenu(this.currentMeeting).Start();
    }

    public void ChangeEndDate()
    {
      Console.Clear();
      DailyPlanner.SetEndDate(this.currentMeeting);
      new MeetingEditMenu(this.currentMeeting).Start();
    }

    public void ChangeAlarmClock()
    {
      Console.Clear();
      DailyPlanner.SetAlarmClock(this.currentMeeting);
      new MeetingEditMenu(this.currentMeeting).Start();
    }
  }
}
