using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudioManager : MonoBehaviour
{
    public GameObject blob1, blob2, blob3; 
    // public ClothManager gBlob, dBlob, pBlob; 
    public GameObject [] guitar; 
    public GameObject [] piano; 
    public GameObject [] drums;
    public GameObject [] instruments; 
    public int guitarIndex, pianoIndex, drumIndex; 
    bool visible; 
    Toggle gToggle, pToggle, dToggle; 
    // Start is called before the first frame update
    void Start()
    {
        findObj();
        // closeObjs(guitar);
        // closeObjs(piano);
        // closeObjs(drums); 
        openObjs(guitar);
        openObjs(piano);
        openObjs(drums);

        // gBlob.Load();
        // dBlob.Load();
        // pBlob.Load(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void findObj()
    {
        guitar = GameObject.FindGameObjectsWithTag("guitar"); 
        piano = GameObject.FindGameObjectsWithTag("piano");
        drums = GameObject.FindGameObjectsWithTag("drums"); 

        List<GameObject[]> instruments = new List<GameObject[]>();
        instruments.Add(guitar); 
        instruments.Add(piano); 
        instruments.Add(drums);
        
        for(int i = 0; i < instruments.Count; i++)
        {
            print(instruments[i]);
        }

    }
    void closeObjs(GameObject [] obs)
    {
        foreach(var o in obs)
        {
            o.SetActive(false); 
        }
    }
    public void openObjs(GameObject [] obs)
    {
        foreach (var o in obs)
        {
            o.SetActive(true); 
        }
    }
    public void clickedButton(int arr)
    {
        switch(arr)
        {
            case 0: 
                //if the blob is active and visible in the hierarchy
                if(blob1.activeInHierarchy == true)
                { 
                    blob1.SetActive(false); 
                    blob2.SetActive(false); 
                    blob3.SetActive(false); 
                }
                else
                {
                    blob1.SetActive(true);
                    blob2.SetActive(false);
                    blob3.SetActive(false); 
                }
            break; 
            
            case 1: 
                if(blob2.activeInHierarchy == true)
                {
                    blob1.SetActive(false); 
                    blob2.SetActive(false); 
                    blob3.SetActive(false);
                }
                else
                {
                    blob2.SetActive(true);
                    blob1.SetActive(false); 
                    gToggle.isOn = false; 
                    blob3.SetActive(false); 
                }
            break; 

            case 2: 
                if(blob3.activeInHierarchy == true)
                {
                    blob1.SetActive(false); 
                    blob2.SetActive(false); 
                    blob3.SetActive(false);
                }
                else
                {
                    blob3.SetActive(true);
                    blob1.SetActive(false); 
                    blob2.SetActive(false); 
                }
            break; 
        }
    }

    
}
