using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]
    private GameObject particle; 
    private Vector2 mousePos;
    Vector3 blobSize; 

    public AudioClip mySound; 

    public float pitchValue = 1.0f; 
    private float myVolume = 0.25f; 
    private AudioSource audioSource; 
    private float low = 0.75f; 
    private float high = 1.25f; 
    public float tempo;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = mySound; 
        audioSource.loop = true; 
    }

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
        // if(Input.touches[0].position.y >= startPos.y +pixelDist)
        {
            blobSize = transform.localScale; 
            blobSize.x += 0.01f; 
            blobSize.y += 0.01f; 
            blobSize.z += 0.01f;
            transform.localScale = blobSize; 
            myVolume += 0.05f;
            audioSource.volume = myVolume;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            blobSize = transform.localScale; 
            blobSize.x -= 0.01f; 
            blobSize.y -= 0.01f; 
            blobSize.z -= 0.01f;
            transform.localScale = blobSize; 
            myVolume -= 0.05f;
            audioSource.volume = myVolume;
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
            blobSize.x += 0.01f; 
            blobSize.y += 0.01f; 
            blobSize.z += 0.01f;
            transform.localScale = blobSize; 
            myVolume += 0.05f;
            audioSource.volume = myVolume;
        }

    }

    void OnCollisionExit(Collision collision){

        if(collision.gameObject.tag == "Tip")
        {
            particle.SetActive(false);


        }
    }
}
