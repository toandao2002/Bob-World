using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public ButtonEffect Play;
    public ButtonEffect Setting;
    public ButtonEffect ChoseCharacter;
    // Start is called before the first frame update
    void Start()
    {
        Setting.onClick.AddListener(setting);
        ChoseCharacter.onClick.AddListener(choseCharacter);
        Play.onClick.AddListener(play);
    }

    void play()
    {
        CanvasHome.Instance.ShowPopup(PopupHomeName.ChoseLevel);
    }
    void choseCharacter()
    {
        CanvasHome.Instance.ShowPopup(PopupHomeName.ChoseCharacter);
    }
    void setting()
    {
        CanvasHome.Instance.ShowPopup(PopupHomeName.Setting);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
