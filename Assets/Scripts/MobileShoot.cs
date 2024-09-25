using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum acoes {
    SHOOT
}

public class MobileShoot : MonoBehaviour
{
    public GameObject shoot;
    public acoes btn;

    public void OnPointerDown(){
        shoot.SendMessage(btn.ToString(), SendMessageOptions.DontRequireReceiver);
    }

    
}
