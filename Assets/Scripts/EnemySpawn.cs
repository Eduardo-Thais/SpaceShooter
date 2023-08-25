using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float timeSpawn;
    public Transform leftLimit;
    public Transform rightLimit;

    private float minX;
    private float maxX;

    private float tempTime;

    // Start is called before the first frame update
    void Start()
    {
        minX = leftLimit.position.x;
        maxX = rightLimit.position.x;



    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime >= timeSpawn) 
        {
            tempTime = 0;
            Spawn();
        }


    }

    void Spawn()
    {
        GameObject tempPrefab = Instantiate(enemyPrefab) as GameObject;
        float posX = Random.Range(minX, maxX);
        tempPrefab.transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

}
