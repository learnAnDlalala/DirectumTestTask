using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DirectumMeetings.Services
{
  public class MainMenuService
  {
    public void ChooseAction(int action)
    {
      switch (action)
      {
        case 1:
          ModificationMeeting();
          break;
        case 2:
          CreateMeeting();
          break;
        case 3:
          PrintMeetings();
          break;
        case 0:
          Exit();
          break;
      }
    }

    public void ShowAllMeetings(List<Meeting> meetings)
    {
      for (int i = 0; i < meetings.Count; i++)
      {
        Console.WriteLine($"\n Встреча номер {i + 1} \n {Utils.TransformMeetingToString(meetings[i])} \n");
      }
    }
    public void ModificationMeeting()
    {
      var queryMeetings = ChooseDateAndGetMeetings();
      ShowAllMeetings(queryMeetings);
      var position = ChooseMeeting();
      new MeetingEditMenu(queryMeetings[position - 1]).Start();
    }
    public int ChooseMeeting()
    {
      Console.WriteLine("Выберите номер встречи");
      return int.Parse(Console.ReadLine());

    }
    public void CreateMeeting()
    {
      Console.Clear();
      DailyPlanner.AddMeeting();// HZZZZ
      Console.WriteLine("Встреча была создана, нажмите 0 для выхода в меню");
      new Menu().Start();
    }
    public void PrintMeetings()
    {
      var queryMeetings = ChooseDateAndGetMeetings();
      ShowAllMeetings(queryMeetings);
      var position = ChooseMeeting();
      var choosenMeeting = queryMeetings[position - 1];
      Console.WriteLine("Введите полный путь к файлу");
      var writePath = $@"{Console.ReadLine()}";

      try
      {
        using (StreamWriter streamWriter = new StreamWriter(writePath, false, System.Text.Encoding.Default))
        {
          streamWriter.Write(Utils.TransformMeetingToString(choosenMeeting));
        }
        Console.WriteLine("Запись в файл была осуществленна \n Нажмите любую клавишу для продолжения");
        Console.ReadKey();
        new Menu().Start();
      }
      catch (Exception ex)
      {

      }
    }

    public List<Meeting> ChooseDateAndGetMeetings()
    {
      Console.Clear();
      Console.WriteLine("Выберите дату начала встречи");
      DateTime queryDate;
      queryDate = Utils.TransformDate();
      var queryMeetings = DailyPlanner.FindAllMeetings(queryDate);
      if (queryMeetings.Count == 0)
      {
        Console.WriteLine("\n Встречи в выбранный день отуствуют.");
        BackToMenuOrKeepGoing();
        ModificationMeeting();
      }
      return queryMeetings;
    }
    public void Exit()
    {
      Environment.Exit(0);
    }
    public void BackToMenuOrKeepGoing()
    {
      Console.WriteLine("\n Нажмите Enter для выхода в главное меню \n Нажмите любую клавишу для продолжения");
      if (Console.ReadKey(true).Key == ConsoleKey.Enter)
      {
        new Menu().Start();
      }
    }
  }
}
