using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false); //bwd maybe allow this to come back on escape key
        }
    }
}
