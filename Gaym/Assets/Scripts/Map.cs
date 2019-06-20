using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
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
*/
public class Map : MonoBehaviour
{
    public Material line_material;
    public string TagName = "Node";
    public string TagName2 = "Path";
    public GameObject[] Buttons;
    //public GameObject[] Paths;
    public GameObject Origin;
    public List<GameObject> LastSelected = new List<GameObject>();
    void Start()
    {
        Buttons = GameObject.FindGameObjectsWithTag(TagName);
        Node button = Origin.GetComponent<Node>();
        button.NodeOn = true;
        LastSelected.Add(Origin);

    }
    private void Update()
    {   
        foreach (GameObject node in Buttons)
        {
            Node button = node.GetComponent<Node>();
            button.Interactable = false;
        }
        int number = LastSelected.Count;
        int size_of_buttons = Buttons.Length;
        GameObject Button = LastSelected[number - 1];
        int index = System.Array.IndexOf(Buttons, Button);
        Node curr_button = Buttons[index].GetComponent<Node>();
        curr_button.Interactable = true;
        if (index + 3 <= size_of_buttons - 1)
        {
            Node button = Buttons[index + 3].GetComponent<Node>();
            if (button.NodeOn == false)
            {
                button.Interactable = true;
            }
        }
        if (index - 3 >= 0)
        {
            Node button = Buttons[index - 3].GetComponent<Node>();
            if (button.NodeOn == false)
            {
                button.Interactable = true;
            }
        }
        if (index%3 != 2 && index + 1 <= size_of_buttons - 1)
        {
            Node button = Buttons[index + 1].GetComponent<Node>();
            if (button.NodeOn == false)
            {
                button.Interactable = true;
            }
        }
        if (index%3 != 0 && index - 1 >= 0)
        {
            Node button = Buttons[index - 1].GetComponent<Node>();
            if (button.NodeOn == false)
            {
                button.Interactable = true;
            }
        }
    }
}