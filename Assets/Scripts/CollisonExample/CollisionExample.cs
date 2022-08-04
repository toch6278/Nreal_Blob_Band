using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
    if(collision.gameObject.tag!= "floor"){

ObjB b = collision.gameObject.GetComponent<ObjB>();

b.Call(9,0);
         collision.gameObject.SetActive(false);




    }



    }
}
