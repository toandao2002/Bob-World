using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    public ButtonEffect Shield;
    public ButtonEffect Power;
    public float ValuePower;
    public int  ValueShield;
    // Start is called before the first frame update
    void Start()
    {
        Power.onClick.AddListener(upgratePower);
        Shield.onClick.AddListener(updateShield);
    }
    void upgratePower()
    {
        ManageEvent<float>.Ivoke(EventName.CharacterPower, ValuePower);
    }
    void updateShield()
    {
        ManageEvent<int>.Ivoke(EventName.CharacterShield, ValueShield);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
