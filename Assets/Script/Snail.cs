using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Run()
    {
        base.Run();
        ani.SetBool("Hit", false);
    }
    public override void ChangeDiretionOfEnemy()
    {
        transform.GetChild(0).localScale = new Vector2(-dir, 1);
    }
}
