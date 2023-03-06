using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    bool Moving = false;
    bool Hitting = false, Ran = false;
    public int dir = 1;
    public float Speed;
    public Rigidbody2D rig;
    public Animator ani;
    // Start is called before the first frame update
    public void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        if (rig == null) return;
        if (Moving)
        {
            rig.AddForce(new Vector2(dir* Speed, 0));
            if (!Hitting && !Ran  )
            {
                
                Run();
            }

             
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public  virtual  void Run()
    {
        Ran = true;
       
        ani.SetBool("Run", true);
        ani.SetBool("Idle", false);
        ani.SetBool("Hit", false);
    }
    public virtual void Hit()
    {
        Ran = false;
        Hitting = true; 

        StartCoroutine(CheckFinishAnimation());
        ani.SetBool("Run", false);
        ani.SetBool("Idle", false);
        ani.SetBool("Hit", true);
    }
    IEnumerator CheckFinishAnimation()
    {
        while (true)
        {
            yield return null;
            if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !ani.IsInTransition(0))
            {
                Hitting = false;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObject);
                break;
            }
        }
    }
    public virtual void Idle()
    {
        Ran = false;
        ani.SetBool("Run", false);
        ani.SetBool("Idle", true);
        ani.SetBool("Hit", false);
    }
    public virtual void  ChangeDiretionOfEnemy()
    {
        transform.GetChild(0).localScale = new Vector2(dir, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Hit();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("TileMap") 
            || collision.gameObject.tag == "Enemy")
        {
            Moving = true;
        }
        else
        {
            Moving = false;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("TileMap"))
        {
            dir *= -1;
            ChangeDiretionOfEnemy();
        }
    }
}
