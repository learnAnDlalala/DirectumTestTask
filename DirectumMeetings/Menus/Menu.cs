using DirectumMeetings.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectumMeetings
{
  public class Menu
  {
    public MainMenuService service;
    public List<String> menuItems;

    public Menu()
    {
      this.service = new MainMenuService();
      this.menuItems = new List<String>()
            {"1 - Просмотреть встречи",
              "2 - Создать встречу",
              "3 - Распечатать встречу",
               "0 - Выход"
            };
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
      } while (action > this.menuItems.Count - 1);
      this.service.ChooseAction(action);
    }
  }
}
