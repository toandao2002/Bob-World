using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Joystick : MonoBehaviour
{
    public ButtonEffect Left;
    public ButtonEffect Right;
    public ButtonEffect Up;
    public ButtonEffect Attack;
    public ButtonEffect Pasue;
    public int Dir = 1;
    public float horizontal, vertical;
    public float time; 
    // Start is called before the first frame update

    void Start()
    {
        Left.onDown.AddListener(MoveBackward);
        Right.onDown.AddListener(MoveForward);
        Up.onDown.AddListener(Jump);
        Attack.onDown.AddListener(Attacked);
        Pasue.onDown.AddListener(Pause);

        Left.onUp.AddListener(Stop);
        Right.onUp.AddListener(Stop);
        
    }

    void MoveForward()
    {
        if (!Character.Instance.Hitting)
            Character.Instance.Move(Dir);
    }
    void MoveBackward()
    {
        if (!Character.Instance.Hitting)
            Character.Instance.Move(-Dir);
    }
    void Stop()
    {
        Character.Instance.idle();
       
    }
    void Jump()
    {

        Character.Instance.Jump();
    }
    void Attacked()
    {
        Character.Instance.Attack();
    }
    void Pause()
    {
        CanvasManage.Instance.ShowPopup(PopupName.Pause);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
