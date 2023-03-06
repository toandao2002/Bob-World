using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PopupHomeName
{
     Setting,
     ChoseCharacter,
     ChoseLevel,
}
public class CanvasHome : MonoBehaviour
{
    public static CanvasHome Instance;
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

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPopup(PopupHomeName name)
    {
        Popup[(int)name].SetActive(true);
    }
    public void HidePopup(PopupHomeName name)
    {
        Popup[(int)name].SetActive(false);
    }
}
