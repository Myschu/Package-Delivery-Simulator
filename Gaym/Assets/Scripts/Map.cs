using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject button1, button2, path;
    //public Transform target;

    void Update()
    {
        bool onoff1 = button1.GetComponent<Toggle>().isOn;
        bool onoff2 = button2.GetComponent<Toggle>().isOn;
        if (onoff1 == true && onoff2 == true)
        {
            //Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, target.position);
            path.GetComponent<Image>().color = Color.red;
        }
        else path.GetComponent<Image>().color = Color.gray;
    }
}
