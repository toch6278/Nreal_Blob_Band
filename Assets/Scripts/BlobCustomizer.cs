using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using System; 
// using System.String; 

public class BlobCustomizer : MonoBehaviour
{
    // public ClothManager blob; 
    // private int aIndex, tIndex, pIndex, hIndex, sIndex; 
    public void Start()
    {
        // aIndex = PlayerPrefs.GetInt("BlobSelected");
        // tIndex = PlayerPrefs.GetInt("BlobSelected");
        // aIndex = PlayerPrefs.GetInt("BlobSelected");
        // aIndex = PlayerPrefs.GetInt("BlobSelected");
        // aIndex = PlayerPrefs.GetInt("BlobSelected"); 

        // if (blob.accessories[aIndex])
        // {
        //     blob.accessories[aIndex].SetActive(true); 
        // }
    }

    public void Update()
    {

    }
    
    public void LoadScene(string sceneName)
    {
    //     PlayerPrefs.SetInt("BlobSelected", aIndex);
    //     PlayerPrefs.SetInt("BlobSelected", tIndex);
    //     PlayerPrefs.SetInt("BlobSelected", pIndex); 
    //     PlayerPrefs.SetInt("BlobSelected", hIndex); 
    //     PlayerPrefs.SetInt("BlobSelected", sIndex); 
        SceneManager.LoadScene(sceneName); 
    }
}
