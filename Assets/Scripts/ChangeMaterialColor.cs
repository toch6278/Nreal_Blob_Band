//delete
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField]

    private GameObject body; 
    private Renderer skr; 
    private Color newSkin; 
    private float rFloat, gFloat, bFloat; 

    // Start is called before the first frame update
    void Start()
    {
        
        //find render of the game object 
        skr = body.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeSkinColor);
    }

    //randomly change skin color of the body 
    private void ChangeSkinColor()
    {
        rFloat = Random.Range(0f,1f);
        gFloat = Random.Range(0f,1f);
        bFloat = Random.Range(0f,1f); 

        newSkin = new Color(rFloat, gFloat, bFloat, 1f); 
        skr.material.SetColor("_Color", newSkin); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    have a color wheel picture show up when you click on the button to change the skin color 
    find out code to get and set color to where the mouse hovers on the color wheel 
    */
}
