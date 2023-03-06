using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Coin : MonoBehaviour
{
    public int ValueCoin;
    public float duration;
     
    // Start is called before the first frame update
    void Start()
    {
        EffectSpin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EffectSpin()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360).SetLoops(-1);
    }
    public void EffectSound()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EffectSound();
            ManageEvent<int>.Ivoke(EventName.CharacterCoin, ValueCoin);
            Destroy(gameObject);
        }
    }
}
