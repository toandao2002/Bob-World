using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InforGamePlay : MonoBehaviour
{
    public TMP_Text Level;
    public TMP_Text Score;
    public TMP_Text TimeTxt;
    public TMP_Text Coin;
    public int reverse_count;
    // Start is called before the first frame update
    void Start()
    {
        ManageEvent<int>.AddEvent(EventName.UpdateInforGamePlayScore, UpdateScore);
        ManageEvent<int>.AddEvent(EventName.UpdateInforGamePlayCoin, UpdateCoin);
       
    }
    private void OnEnable()
    {
        UpdateLevel();
        StartCoroutine(IECountdown());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLevel()
    {
        Level.text = "Level\n" + (DataPlayer.GetdataInt(DataPlayer.LevelPlayCurrent)+1).ToString();
    }
    public void UpdateScore(int _Score)
    {
        Score.text ="Score\n"+ _Score.ToString();
    }
    public void UpdateCoin(int value)
    {
        Coin.text = "Coin\n" + value.ToString(); 
    }
    public void HandleTime()
    {

    }
    IEnumerator IECountdown()
    {
        while (reverse_count >= 0)
        {
            var timeSpan = TimeSpan.FromSeconds(reverse_count);

            TimeTxt.text = "Time\n"+ timeSpan.ToString(@"mm\:ss");
            
            yield return new WaitForSeconds(1);
            reverse_count--;
            if (reverse_count == 0) ManageEvent.Ivoke(EventName.GameLose);
        }
    }
}
