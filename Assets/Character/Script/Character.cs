using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public static Character Instance;
    public float speed , SpeedBullet = 100;
    public float JumpForce = 500;
    public bool Moving{ get;set;}
    public bool Hitting = false, Jumpping;
    bool gamewin = false;
    public Rigidbody2D rig;
    public Animator ani;
    public GameObject BulletPref;
    public int Direction =1;

    public int Score { get; set; }
    public int Coin { get; set; }
    public Vector3 ValueScale= new Vector3(1,1,1);
    public int Shield;
    public int live = 1;

    

    void Start()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        ManageEvent<int>.AddEvent(EventName.CharacterCoin, IncCoin);
        ManageEvent<float>.AddEvent(EventName.CharacterPower, UpgratePowerCharacter);
        ManageEvent<int>.AddEvent(EventName.CharacterShield, UpgratePShieldCharacter);
        ManageEvent<int>.AddEvent(EventName.CharacterScore,updateScore );
        ManageEvent<Vector3>.AddEvent(EventName.MoveToCastle, MoveToCastle );
       

    }
    private void FixedUpdate()
    {
        if (Moving)
        {
           
            rig.AddForce(new Vector2(speed, 0), ForceMode2D.Force);

        }
        else
        {
            if (Jumpping)
            {

            }
        }
        
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, -10);
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Move(int Dir) 
    {
       
        Direction = Dir;
        ani.SetBool("Run", true);
        ani.SetBool("Idle", false);
        ani.SetBool("Jump", false);
        ani.SetBool("Hit", false);
        Vector3 scale = transform.GetChild(0).transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Dir;
        transform.GetChild(0).transform.localScale = scale ;
      
        speed = Mathf.Abs(speed) * Dir;
        Moving = true;
     
    }
    public void idle()
    {
        Moving = false;
        ani.SetBool("Run", false);
        ani.SetBool("Idle", true);
        ani.SetBool("Jump", false);
        ani.SetBool("Hit", false);
    }
    public void Jump()
    {
        if (Jumpping == false)
        {
            rig.AddForce(new Vector2(0, JumpForce));
        }
        
        Jumpping = true;
        ani.SetBool("Run", false);
        ani.SetBool("Idle", false);
        ani.SetBool("Jump", true);
        ani.SetBool("Hit", false);

        
    }
    public void Hit()
    {
      
        ani.SetBool("Run", false);
        ani.SetBool("Idle", false);
        ani.SetBool("Jump", false);
        ani.SetBool("Hit", true);
        
        StartCoroutine(CheckFinishAnimation());
        
        
    }
    IEnumerator CheckFinishAnimation()
    {
        while (true)
        {
            yield return null;
            if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !ani.IsInTransition(0))
            {
                Hitting = false;

                break;
            }
        }
    }
    public void  Attack()
    {
        var Bullet = Instantiate(BulletPref);
        Bullet.transform.localPosition = transform.position+ new Vector3(0,0.3f, 0) ;
        var rigBullet = Bullet.GetComponent<Rigidbody2D>();
        rigBullet.AddForce(new Vector2(Direction * SpeedBullet, 0));
    }
    public void IncCoin(int value)
    {
        Coin += value;
        ManageEvent<int>.Ivoke(EventName.UpdateInforGamePlayCoin, Coin); ;
        
    }
    public void IncLive(int value)
    {
        live += value;
    }
    public void LoseOfLive()
    {
        live--;
        Debug.Log(live);
        if (live <= 0)
        {
            
            ManageEvent.Ivoke(EventName.GameLose);
        }
    }


    public void UpgratePowerCharacter(float valueUpgrate)
    {
        IncLive(1);
        ValueScale += new Vector3(valueUpgrate, valueUpgrate, valueUpgrate);
        transform.localScale =  ValueScale;
    }
    public void UpgratePShieldCharacter(int valueUpgrate)
    {
        Shield+= valueUpgrate;
        IncLive(1);
    }

    public void updateScore(int _score)
    {
        Score += _score;
        ManageEvent<int>.Ivoke(EventName.UpdateInforGamePlayScore, Score);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jar"))
        {
            UpgratePowerCharacter(collision.gameObject.GetComponent<Jar>().valuePower);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            ManageEvent.Ivoke(EventName.GameLose);
        }
        if (collision.gameObject.CompareTag("TileMap") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Ground"))
        {
            Jumpping = false;
            if (!Moving && !gamewin)
            {
                ani.SetBool("Run", false);
                ani.SetBool("Idle", true);
                ani.SetBool("Jump", false);
                ani.SetBool("Hit", false);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseOfLive();
            Hit();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    public float timeMoveToCastle =10;
    public void MoveToCastle( Vector3 pos)
    {
        Move(1);
        gamewin = true;
        transform.DOLocalMoveX(pos.x, timeMoveToCastle);
    }
    
}
