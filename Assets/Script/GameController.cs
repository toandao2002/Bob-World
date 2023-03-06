using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum StateGame { 
    GameWin,
    GameLose,
    
}
public static class DataPlayer
{
    public static string Coin = "Coin"; 
    public static string Level = "Level";
    public static string LevelPlayCurrent = "LevelPlayCurrent";
    public static string NUmCharacter = "NUmCharacter";
    public static int GetdataInt(string name)
    {

        if (!PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.SetInt(name, 0);
            return 0;
        }
        return PlayerPrefs.GetInt(name);
        
    }
    public static void SetDataInt(string name ,int value)
    {
        PlayerPrefs.SetInt(name, value);
    }
    public static void SaveData()
    {
        PlayerPrefs.Save();
         
    }
}
public class GameController : MonoBehaviour
{
    public static GameController Insctacne;
    public int CurrentLevel;
    public StateGame stateGame;
    
    
    private void Awake()
    {
        EventName.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Insctacne == null)
        {
            Insctacne = this;
        }
        
       
    }
    private void OnEnable()
    {
        Debug.Log(DataPlayer.GetdataInt(DataPlayer.Level)); 
        int currentCharacter = DataPlayer.GetdataInt(DataPlayer.NUmCharacter);
        var character = Instantiate((GameObject) Resources.Load($"Character/Character{currentCharacter}"));
        character.transform.localPosition = Vector3.zero;
    }
    private void OnDisable()
    {
        SaveData();
    }
    public void GameWin()
    {
        stateGame = StateGame.GameWin;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SaveData()
    {
        DataPlayer.SaveData();
    }
    
}
