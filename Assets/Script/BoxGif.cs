using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BoxGif : Box
{
    public GameObject GifPref;
    public bool Received;
    public GameObject BoomPref;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (TimeOfHit > 0)
            {
                if (!Received)
                {
                    Received = true;
                    var gif  = Instantiate(GifPref);
                    gif.transform.position = transform.position + new Vector3(0, 0.3f, 0);

                }
                ani.SetBool("Hit", true);
                ani.SetBool("Idle", false);
                DOVirtual.DelayedCall(0.2f, () =>
                {
                    ani.SetBool("Hit", false);
                    ani.SetBool("Idle", true);

                });
                TimeOfHit -= 1;
            }
            else if (TimeOfHit <= 0)
            {
                ani.SetBool("Break", true);
                ManageEvent<int>.Ivoke(EventName.CharacterScore, score);
                DOVirtual.DelayedCall(0.45f, () =>
                {
                    Destroy(gameObject);
                });
            }
        }
    }
}
