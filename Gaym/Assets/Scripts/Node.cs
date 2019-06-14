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
    void Start()
    {
        Map = GameObject.FindGameObjectWithTag(TagName);
    }

    // Update is called once per frame
    void Update()
    {
        Button.GetComponent<Toggle>().isOn = NodeOn;
        Button.GetComponent<Toggle>().interactable = Interactable;
        Button.GetComponent<Toggle>().onValueChanged.AddListener(delegate { TaskOnClick(); });
    }

    void TaskOnClick()
    {
        NodeOn = !NodeOn;
        Map map = Map.GetComponent<Map>();
        if (NodeOn)
        {
            map.LastSelected.Add(Button);
        }
        else
        {
            map.LastSelected.Remove(Button);
        }
    }
}
