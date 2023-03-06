using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameWin : BasePopup
{
    public GameObject main1, main2 ;

    public ButtonEffect ContinueMain2;

    public ButtonEffect Next;
    public ButtonEffect Restart;
    public ButtonEffect Home;


    // Start is called before the first frame update
    void Start()
    {

        ContinueMain2.onClick.AddListener(continueMan2);

        Next.onClick.AddListener(NextGame);
        Restart.onClick.AddListener(restart);
        Home.onClick.AddListener(home);
         
    }
    private void OnEnable()
    {
        base.OnEnable();
        if (DataPlayer.GetdataInt(DataPlayer.LevelPlayCurrent) >= DataPlayer.GetdataInt(DataPlayer.Level))
        {
            DataPlayer.SetDataInt(DataPlayer.Level, DataPlayer.GetdataInt(DataPlayer.Level) + 1);
        }
    }
    public void continueMan2()
    {
        main1.SetActive(false);
        main2.SetActive(true);
        main1.transform.DOScale(1, duration).From(0);
    }
    void restart()
    {
        Time.timeScale = 1;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
       
    }
    public void  NextGame()
    {
        Time.timeScale = 1;
        if (DataPlayer.GetdataInt(DataPlayer.LevelPlayCurrent) >= DataPlayer.GetdataInt(DataPlayer.Level)){
            DataPlayer.SetDataInt(DataPlayer.Level, DataPlayer.GetdataInt(DataPlayer.LevelPlayCurrent)+1);
        }
        SceneManager.LoadScene("Level"+(DataPlayer.GetdataInt(DataPlayer.LevelPlayCurrent)+1) );
    }
    public void home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
    public void show()
    {
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
