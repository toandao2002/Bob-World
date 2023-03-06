using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopupName
{
    Pause ,
    GameLose,
    GameWin,
}

public class CanvasManage : MonoBehaviour
{
    public static CanvasManage Instance;
    public List<GameObject> Popup;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;    
        }

        HadleAddEvents();
    }
    void HadleAddEvents()
    {
        ManageEvent.AddEvent(EventName.GameLose, Popup[(int)PopupName.GameLose].GetComponent<GameLose>().show);
        ManageEvent.AddEvent(EventName.GameWin, Popup[(int)PopupName.GameWin].GetComponent<GameWin>().show);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPopup(PopupName name)
    {
        Popup[(int)name].SetActive(true);
    }public void HidePopup(PopupName name)
    {
        Popup[(int)name].SetActive(false);
    }
}
