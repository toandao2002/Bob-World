using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour
{
    bool Moving = false;
    public int dir =1;
    public float valuePower =0.5f;
    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Moving)
        {
            rig.AddForce(new Vector2(dir, 0));
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box")|| collision.gameObject.CompareTag("TileMap"))
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
        else
        {
            dir *= -1;
        }
    }
}
