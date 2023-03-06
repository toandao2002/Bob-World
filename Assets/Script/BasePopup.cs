using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BasePopup : MonoBehaviour
{
    public float duration = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        duration = 0.2f;
    }
    public void OnEnable()
    {
        transform.DOScale(1, duration).From(0).OnComplete(()=> {
            Time.timeScale = 0;
        });
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
