using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCharacter : MonoBehaviour
{
    public int NumCharacter;
    public ButtonEffect Use;
    // Start is called before the first frame update
    void Start()
    {
        Use.onClick.AddListener(use);
    }
    void use()
    {
        DataPlayer.SetDataInt(DataPlayer.NUmCharacter , NumCharacter);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
