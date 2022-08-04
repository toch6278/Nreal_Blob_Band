using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{

    void Awake()
    {
        PlayerPrefs.DeleteKey("a_index");
        PlayerPrefs.DeleteKey("t_index");
        PlayerPrefs.DeleteKey("h_index");
        PlayerPrefs.DeleteKey("s_index");
        PlayerPrefs.DeleteKey("p_index");
        PlayerPrefs.DeleteKey("red");
        PlayerPrefs.DeleteKey("blue");
        PlayerPrefs.DeleteKey("green");

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
