using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseCharacter : MonoBehaviour
{
    public ButtonEffect Home;

    // Start is called before the first frame update
    void Start()
    {
        Home.onClick.AddListener(Hide);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
