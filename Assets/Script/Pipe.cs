using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Pipe : MonoBehaviour
{
    public GameObject FlowerBite;
    public GameObject PipeLine;
    public GameObject FlowerOppen;
    public float TimeAttacked;
    // Start is called before the first frame update
    void Start()
    {
        PipeHandle();
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void PipeHandle()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(FlowerOppen.transform.parent.DOLocalMoveY(0.58f, TimeAttacked));
        seq.AppendCallback(() =>
        {

            FlowerOppen.gameObject.SetActive(false);
            FlowerBite.gameObject.SetActive(true);
        });
        seq.AppendInterval(1);
        seq.Append(FlowerOppen.transform.parent.DOLocalMoveY(0, TimeAttacked));
        
        seq.AppendCallback(() =>
        {

            FlowerOppen.gameObject.SetActive(true);
            FlowerBite.gameObject.SetActive(false);
        });
        seq.AppendInterval(2);
        seq.SetLoops(-1);
    }
     
}
