using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventName
{
    public static string UpdateInforGamePlayScore { get; set; }
    
    public static string UpdateInforGamePlayLevel { get; set; }
    public static string UpdateInforGamePlayTime { get; set; }
    public static string UpdateInforGamePlayCoin { get; set; }


    public static string CharacterCoin { get; set; }
    public static string CharacterPower { get; set; }
    public static string CharacterShield { get; set; }
    public static string CharacterScore { get; set; }

    public static string GameLose { get; set; }
    public static string GameWin { get; set; }
    public static string MoveToCastle { get; set; }

    public static void Init()
    {
        UpdateInforGamePlayScore = "UpdateInforGamePlayScore";

        UpdateInforGamePlayLevel = "UpdateInforGamePlayLevel";
        UpdateInforGamePlayTime = "UpdateInforGamePlayTime";
        UpdateInforGamePlayCoin = "UpdateInforGamePlayCoin";


        CharacterCoin = "CharacterCoin";
        CharacterPower = "CharacterPower";
        CharacterShield = "CharacterShield";
        CharacterScore = "CharacterScore";

        GameLose = "GameLose";
        GameWin = "GameWin";
        MoveToCastle = "MoveToCastle";
}
}
public static  class ManageEvent 
{
    public static Dictionary<string, UnityEvent> Events = new Dictionary<string, UnityEvent>();

    public static bool checkedHasExistKey (string key)
    {
        return Events.ContainsKey(key);
    }
   
    public static void AddEvent(string nameEvent, UnityAction call)
    {
        if (!checkedHasExistKey(nameEvent))
            Events[nameEvent] = new UnityEvent();
        Events[nameEvent].AddListener( call);
    }
    public static void Ivoke(string nameEvent)
    {
        Events[nameEvent].Invoke();
         
    }
    public static void RemoveListen(string NameEvent, UnityAction call)
    {
        Events[NameEvent].RemoveListener(call);
    }
    // Start is called before the first frame update
     
}
public static class ManageEvent <T0>
{
    
    public static Dictionary<string, UnityEvent<T0>> Events = new Dictionary<string , UnityEvent<T0>>() ;

    public static bool checkedHasExistKey(string key)
    {
        return Events.ContainsKey(key);
    }

    public static void AddEvent(string nameEvent, UnityAction<T0> call)
    {
        
        

        if (!checkedHasExistKey(nameEvent))
            Events[nameEvent] = new UnityEvent<T0>();
        Events[nameEvent].AddListener(call);
    }
    public static void Ivoke(string nameEvent, T0 data)
    { 
        Events[nameEvent]?.Invoke(data);
        

    }
    public static void RemoveListen(string NameEvent, UnityAction<T0> call)
    {
        Events[NameEvent].RemoveListener(call);
    }
    // Start is called before the first frame update

}
