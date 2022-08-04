using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; 

public class ColorPicker : MonoBehaviour
{
    //referenced WAR dd on Youtube
    public FlexibleColorPicker fcp; 
    public Material material; 

    public float red, green, blue; 
    public string SAVE_FOLDER ;
    void Start()
    {
        SAVE_FOLDER = Application.dataPath + "/Saves/"; 
        // if(PlayerPrefs.HasKey("color"))
        // {
        //     material.color = (Color)(new Color32((byte)PlayerPrefs.GetInt("red"),(byte)PlayerPrefs.GetInt("green"),(byte)PlayerPrefs.GetInt("blue"), 1));
        // }
        // else
        // {
        //     PlayerPrefs.SetString("color", "set");
        //     material.color = Color.white;
        // }
    }
    private void Update()
    {

        BlobPlayerPrefs();
        
    }

    public void BlobPlayerPrefs()
    {
        if(fcp!=null)
        {
            material.color = fcp.color;

            PlayerPrefs.SetInt("red", ((Color32)material.color).r);
            PlayerPrefs.SetInt("blue", ((Color32)material.color).b);
            PlayerPrefs.SetInt("green", ((Color32)material.color).g);


            if (material.color == null)
            {
                material.color = Color.white;
            }

            // Debug.Log((byte)((Color32)material.color).r);
        }
        red = (byte)((Color32)material.color).r; 
        green = (byte)((Color32)material.color).g; 
        blue = (byte)((Color32)material.color).b; 
    }
    public void Save()
    {
        SaveSkin saveSkin = new SaveSkin()
        {
            red = red, 
            green = green, 
            blue = blue, 
        };
        string json =JsonUtility.ToJson(saveSkin); 
        File.WriteAllText(Application.dataPath + "/save.txt", json);  
    }
    public class SaveSkin
    {
        public float red, green, blue; 
    }
}
