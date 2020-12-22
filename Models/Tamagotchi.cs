using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Game.Models
{

  public class Tamagotchi
  {

    public string Name { get; set; }
    public int Id { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Fatigue { get; set; }
    public string HungerStatus { get; set; }
    public string HappinessStatus { get; set; }
    public string FatigueStatus { get; set; }



    public Tamagotchi(string name)
    {
      Name = name;
      Hunger = 1;
      Happiness = 1;
      Fatigue = 1;
      HungerStatus = "Full";
      HappinessStatus = "Very Happy";
      FatigueStatus = "Well Rested";
    }

    public Tamagotchi(string name, int id)
    {
      // overload constructor
      Name = name;
      Id = id;
    }

    public static List<Tamagotchi> GetAll()
    {
      List<Tamagotchi> allTamagotchis = new List<Tamagotchi> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM tamagotchi;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int TamagotchiId = rdr.GetInt32(1);
        string TamagotchiName = rdr.GetString(0);
        Tamagotchi newTamagotchi = new Tamagotchi(TamagotchiName, TamagotchiId);
        allTamagotchis.Add(newTamagotchi);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allTamagotchis;
    }
    public static Tamagotchi Find(int searchId)
    {
      Tamagotchi placeholderTamagotchi = new Tamagotchi("placeholder Tamagotchi");
      return placeholderTamagotchi;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM tamagotchi;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO tamagotchi (name) VALUES (@TamagotchiName);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@TamagotchiName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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