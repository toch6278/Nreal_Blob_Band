using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjA : MonoBehaviour
{
    public ObjB b;
    public GameObject bb;
    // Start is called before the first frame update
    void Start()
    {
        b.Call(9,7);
        bb.BroadcastMessage("call2",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
