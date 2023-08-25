using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour
{
    void onTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
