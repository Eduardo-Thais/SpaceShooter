using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private _GC _GC;

    private Rigidbody2D playerRb;
    private Animator    playerAnimator;

    public float        velocity;
    private int         direction;

    public float HPMax;
    public float HP;
    private float percLife;

    public Transform HPBar;

    public GameObject explosionPrefab;

    public GameObject extraGuns;

    public Transform top, bottom, left, right;
    

    // Start is called before the first frame update
    void Start()
    {
        _GC = FindObjectOfType(typeof(_GC)) as _GC;

        top = GameObject.Find("Top").transform;
        bottom = GameObject.Find("Bottom").transform;
        left = GameObject.Find("Left").transform;
        right = GameObject.Find("Right").transform;

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        HPBar = GameObject.Find("LifeBar").transform;
        HPBar.localScale = new Vector3(1,1,1);

        HP = HPMax;
        percLife = HP / HPMax;
    }

    void Update()
    {
        


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimentX = Input.GetAxis("Horizontal");
        float movimentY = Input.GetAxis("Vertical");

        
            playerRb.velocity = new Vector2(movimentX * velocity, movimentY * velocity);

        if(transform.position.x < left.position.x)
        {
            transform.position = new Vector3(left.position.x, transform.position.y, transform.position.z);
        } 
        if(transform.position.x > right.position.x)
        {
            transform.position = new Vector3(right.position.x, transform.position.y, transform.position.z);
        } 
        if(transform.position.y > top.position.y)
        {
            transform.position = new Vector3(transform.position.x, top.position.y, transform.position.z);
        }
        if(transform.position.y < bottom.position.y)
        {
            transform.position = new Vector3(transform.position.x, bottom.position.y, transform.position.z);
        }


        if(movimentX < 0)
        {
            direction = -1;
        } 
        else if(movimentX > 0)
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        playerAnimator.SetInteger("direction", direction);


       


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "RedShoot":
                getDammage(1);
                break;
            case "PowerUp":
                PowerUp();
                Destroy(col.gameObject);
                break;

            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "EnemyShip":
                getDammage(5);
                break;


        }
    }

    

    void getDammage(int dammage)
    {

        HP -= dammage;
        percLife = HP / HPMax;
        Vector3 theScale = HPBar.localScale;
        theScale.x = percLife;
        HPBar.localScale = theScale;

        if (HP <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject tempPrefab = Instantiate(explosionPrefab) as GameObject;
        tempPrefab.transform.position = transform.position;
        _GC.Died();
        Destroy(this.gameObject);
    }

    void PowerUp()
    {
        extraGuns.SetActive(true);
        _GC.pontos += 250;
    }

    

}
