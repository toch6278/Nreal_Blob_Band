using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour
{
    public List<Transform> highObjs; 
    [SerializeField] float t = 0.1f; 

    void Update()
    {
        scaleReact();
    }

    void scaleReact()
    {
        foreach (Transform obj in highObjs)
        {
            obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, SoundManager.inst.getFrequency(30,32,1000), 1), t);
        }
    }
}
