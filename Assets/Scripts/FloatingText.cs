using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;
    public Vector3 offset;
    TMP_Text tmp;
    Cyclist cyclist;

    // Start is called before the first frame update
    void Start()
    {
        cyclist = transform.parent.gameObject.GetComponent<Cyclist>();

        tmp = GetComponent<TMP_Text>();
        

        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);// look at the camera
        transform.position = unit.position + offset;
    }

    void UpdateText()
    {
        if (cyclist != null)
        {
            tmp.text = "Skill Level: " + cyclist.SkillLevelText;
        }
        else
        {
            tmp.text = string.Empty;
        }
    }
}
