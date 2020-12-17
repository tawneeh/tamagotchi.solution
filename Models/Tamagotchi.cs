using System.Collections.Generic;

namespace Game.Models
{

  public class Tamagotchi
  {

    public string Name { get; set; }
    public int Id { get; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Fatigue { get; set; }
    public string HungerStatus { get; set; }
    public string HappinessStatus { get; set; }
    public string FatigueStatus { get; set; }

    private static List<Tamagotchi> _instances = new List<Tamagotchi> { }; 

    public Tamagotchi(string name)
    {
      Name = name;
      Hunger = 1;
      Happiness = 1;
      Fatigue = 1;
      HungerStatus = "Full";
      HappinessStatus = "Very Happy";
      FatigueStatus = "Well Rested";
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }
    public static Tamagotchi Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public int Feed()
    {
      return Hunger = 10;
      
    }

    public int Sleep()
    {
      return Fatigue = 10;
    }

    public int Play()
    {
      return Happiness = 10;
    }



    // public string CheckForDeath()
    // {
    //   if (Hunger == 0 || Happiness == 0 || Fatigue == 0)
    //   {
    //     return "Your Tamagotchi has died";
    //   }
    //   else if (Hunger <= 10 && Hunger >= 7)
    //   {
    //     HungerStatus = "Full";
    //   }
    //   else if (Hunger <= 6 && Hunger >= 3)
    //   {
    //     HungerStatus = "Hungry";
    //   }
    //   else if (Hunger <= 2 && Hunger >= 1)
    //   {
    //     HungerStatus = "Starving";
    //   }
    //   else if ()
    //   {
        
    //   }
    //   else if ()
    //   {
        
    //   }
    // }
  }
}

// if {id} Hunger == 0 || Happiness == 0 || Fatigue == 0
// then return death message then delete that tamagotchi 
// else if stats <= 3 return a warning message 
// else if stats >= 8 return 'doing great!' message (can get more specific per stat
// else - nothing 