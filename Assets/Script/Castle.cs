using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Castle : MonoBehaviour
{
    public float duration ;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            door.transform.DOLocalMoveY(3.4f, duration).From(0).OnComplete(() =>
            {
                ManageEvent.Ivoke(EventName.GameWin);
            });
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
