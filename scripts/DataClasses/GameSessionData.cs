using System.Collections.Generic;
using System.IO;
using System.Net;
using Godot;
using Newtonsoft.Json;

namespace MartiansDutyCS.scripts.DataClasses;

public class GameSessionData
{
    private string _fileName =  Path.Combine(OS.GetUserDataDir(), "GameSessionData.json");
    [JsonProperty("items")] public List<string> Items { get; set; }
    [JsonProperty("money")] public int Money { get; set; }  
    [JsonProperty("round")] public int Round { get; set; }
    [JsonProperty("player_x")] public float PlayerX { get; set; }
    [JsonProperty("player_y")] public float PlayerY { get; set; }
    [JsonProperty("current_section")] public int CurrentSection { get; set; }
    
    public GameSessionData() {}

    public GameSessionData(List<string> items, int money, int round, float playerX, float playerY, int currentSection)
    {
        Items = items;
        Money = money;
        Round = round;
        PlayerX = playerX;
        PlayerY = playerY;
        CurrentSection = currentSection;
    }
    
    public void SaveJsonData(List<string> items, int money, int round, float playerX, float playerY, int currentSection)
    {
        EnsureSaveFileExists();
        Items = items;
        Money = money;
        Round = round;
        PlayerX = playerX;
        PlayerY = playerY;
        CurrentSection = currentSection;
        
        string json = JsonConvert.SerializeObject(this);

        if (File.Exists(_fileName))
        {
            File.WriteAllText(_fileName, json);
        }
        else
        {
            GD.Print(_fileName + " does not exist");
        }
    }

    public void ReadJsonData()
    {
        if (File.Exists(_fileName))
        {
            string json = File.ReadAllText(_fileName);
            GameSessionData JsonData = JsonConvert.DeserializeObject<GameSessionData>(json);

            this.Items = JsonData.Items;
            this.Money = JsonData.Money;
            this.Round = JsonData.Round;
            this.PlayerX = JsonData.PlayerX;
            this.PlayerY = JsonData.PlayerY;
            this.CurrentSection = JsonData.CurrentSection;
        }
        else
        {
            GD.Print(_fileName + " does not exist");
        }
    }

    public void ClearData()
    {
        EnsureSaveFileExists();
        File.WriteAllText(_fileName, "");
    }

    public bool HasSave()
    {   
        EnsureSaveFileExists();
        return File.ReadAllText(_fileName) != "";
    }
    
    private void EnsureSaveFileExists()
    {
        if (!File.Exists(_fileName))
        {
            File.WriteAllText(_fileName, "{}");
        }
    }
}