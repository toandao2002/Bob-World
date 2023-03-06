using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Flag : MonoBehaviour
{
    public GameObject flag;
    public GameObject Castle;
    public float duration=1;
    bool Down = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (!Down) EffectFlagDown();
        }
    }
    void EffectFlagDown()
    {
        Down = true;
        flag.transform.DOLocalMoveY(-0.3f, duration).From(0.3f).OnComplete(()=> {
            ManageEvent<Vector3>.Ivoke(EventName.MoveToCastle, Castle.transform.GetChild(1).position);
        });
    }
    
}
