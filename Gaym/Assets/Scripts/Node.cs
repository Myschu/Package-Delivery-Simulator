using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public string TagName = "Map";
    public bool NodeOn = false;
    public bool Interactable = false;
    public GameObject Button;
    public GameObject Map;
    private int tog;
    void Start()
    {
        tog = 0;
        Map = GameObject.FindGameObjectWithTag(TagName);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Button.GetComponent<Toggle>().isOn = NodeOn;
        Button.GetComponent<Toggle>().interactable = Interactable;
        /** if( Button.GetComponent<Toggle>().onValueChanged.Equals(true) && x == true) {
             x = false;
             TaskOnClick();
         }*/

        Invoke("activate", 1.0f);


    }
    void activate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (tog == 0)
            {
                tog++;
                Button.GetComponent<Toggle>().onValueChanged.AddListener(delegate
                {
                    TaskOnClick(NodeOn);

                });
            }
        }
    }

    void TaskOnClick(bool val)
    {
        Debug.Log("clicked");
        val = !val;
        Map map = Map.GetComponent<Map>();
        if (val)
        {
            map.LastSelected.Add(Button);

        }
        else
        {
            map.LastSelected.Remove(Button);
        }

        NodeOn = val;
        tog = 0;
    }
}