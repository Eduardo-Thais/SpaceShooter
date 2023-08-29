using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private _GC _GC;


    private Rigidbody2D enemyRb;
    private Animator    enemyAnimator;


    public float velocity;
    private int direction;

    public Transform gun;
    public GameObject prefabBullet;
    public float bulletVelocity;

    private int movimentX;
    private int movimentY;

    public float timeCurve;
    public int changeChance;
    private float tempTime;
    private int rand;

    public int shootChance;
    public float shootDellay;
    private float tempTimeShoot;

    public int hp;

    public GameObject explosionPrefab;

    public int points;

    public GameObject drops;
    public float dropChance;


    // Start is called before the first frame update
    void Start()
    {
        _GC = FindObjectOfType(typeof(_GC)) as _GC;

        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        movimentY = - 1;
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        tempTimeShoot += Time.deltaTime;
        if(tempTime >= timeCurve) 
        {
            tempTime = 0;
            rand = Random.Range(0, 100);
            if(rand <= changeChance)
            {
                rand = Random.Range(0, 100);
                if (rand < 50)
                {
                    movimentX = -1;
                    direction = 1;
                }
                else
                {
                    movimentX = 1;
                    direction = -1;
                }
            }
            else
            {
                movimentX = 0;
                direction = 0;
            }
        }

        if (tempTimeShoot >= shootDellay)
        {
            tempTimeShoot = 0;
            rand = Random.Range(0, 100);
            if (rand <= shootChance) 
            {
                shoot();
            }
        }
       

        enemyAnimator.SetInteger("direction", direction);
        enemyRb.velocity = new Vector2(movimentX * velocity, movimentY * velocity);

    }

    void shoot()
    {
        GameObject tempPrefab = Instantiate(prefabBullet) as GameObject;
        tempPrefab.transform.position = gun.position;
        tempPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletVelocity));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "BlueShoot":
                getDammage(1);
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Player":
                Explode();
                break;
        }
    }

    void getDammage(int dammage)
    {
        hp -= dammage;
        if(hp <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject tempPrefab = Instantiate(explosionPrefab) as GameObject;
        tempPrefab.transform.position = transform.position;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity * -1);
        _GC.pontos += points;

        rand = Random.Range(0, 100);
        if(rand <= dropChance)
        {
            GameObject tempdrop = Instantiate(drops) as GameObject;
            tempdrop.transform.position = transform.position;
        }


        Destroy(this.gameObject);
    }
}
