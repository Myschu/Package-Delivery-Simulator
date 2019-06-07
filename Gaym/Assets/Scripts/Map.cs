using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject button1, button2, path;

    void Update()
    {
        bool onoff1 = button1.GetComponent<Toggle>().isOn;
        bool onoff2 = button2.GetComponent<Toggle>().isOn;
        if (onoff1 == true && onoff2 == true)
        {
            path.GetComponent<Image>().color = Color.red;
        }
        else path.GetComponent<Image>().color = Color.gray;
    }
}
