using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public GameObject particle; 
    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); 
        rb.AddForce(Vector3.up, ForceMode.Impulse); 

        if(Input.GetMouseButtonDown(0))
        {
            particle.SetActive(true); 
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            particle.SetActive(false);
        }
    }
}
