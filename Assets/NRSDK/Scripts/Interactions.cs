using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]
    private GameObject particle; 
    private Vector2 mousePos;
    Vector3 blobSize; 
    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //particle explosion on blob 
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            particle.SetActive(true); 
            particle.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            particle.SetActive(false);
        }

        //scale the blob 
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            blobSize = transform.localScale; 
            blobSize.x += 0.01f; 
            blobSize.y += 0.01f; 
            blobSize.z += 0.01f;
            transform.localScale = blobSize; 
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            blobSize = transform.localScale; 
            blobSize.x -= 0.01f; 
            blobSize.y -= 0.01f; 
            blobSize.z -= 0.01f;
            transform.localScale = blobSize; 
        }
    }

    public void OnMouseDown()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); 
        rb.AddForce(Vector3.up, ForceMode.Impulse); 

    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Blob touched"); 
        GameObject hand = Instantiate(particle) as GameObject; 
        hand.transform.position = transform.position;
        if(collision.gameObject.tag == "Tip")
        {
            particle.SetActive(true);
        }
        if (collision.gameObject.tag == "Fingers")
        {
            blobSize = transform.localScale; 
            blobSize.x += Time.deltaTime; 
            blobSize.y += Time.deltaTime; 
            blobSize.z += Time.deltaTime;
            transform.localScale = blobSize;
        }

    }

    void OnCollisionExit(Collision collision){

        if(collision.gameObject.tag == "Tip")
        {
            particle.SetActive(false);


        }
    }
}
