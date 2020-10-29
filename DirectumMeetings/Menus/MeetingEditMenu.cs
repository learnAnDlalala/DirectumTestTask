using DirectumMeetings.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectumMeetings
{
  class MeetingEditMenu
  {
    public List<String> menuItems;
    public Meeting meeting;
    public EditMeetingService service;
    public MeetingEditMenu(Meeting meeting)
    {
      this.menuItems = new List<String>() {
        "1 - Изменить название встречи",
        "2 - Изменить дату начала встречи",
        "3 - Изменить дату окончания встречи",
        "4 - Изменить дату напоминания",
        "5 - Вернуться в главное меню"
      };
      this.meeting = meeting;
      this.service = new EditMeetingService(meeting);
    }
    public void Start()
    {
      Console.Clear();
      foreach (string item in this.menuItems)
      {
        Console.WriteLine($"{item}");
      }
      Action();
    }

    public void Action()
    {
      int action;
      do
      {
        Console.WriteLine("Выберите действие");
        action = int.Parse(Console.ReadLine());
      } while (action > this.menuItems.Count + 1);
      this.service.ChooseAction(action);
    }

  }
}
