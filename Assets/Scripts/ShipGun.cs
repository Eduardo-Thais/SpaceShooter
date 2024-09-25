using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
    
    public GameObject prefabBullet;
    public float bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject tempPrefab = Instantiate(prefabBullet) as GameObject;
        tempPrefab.transform.position = transform.position;
        tempPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletVelocity));
    }

}
