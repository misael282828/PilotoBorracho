using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    
    //mmg
    void Start()
    {   float timeDestroy = 1f;
        Destroy(gameObject, timeDestroy);
     Debug.Log("AutoDestroy script is working");
    }

}
