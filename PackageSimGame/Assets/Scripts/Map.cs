using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Map
 * 
 * Main code for the interactable map in the "Planning" scene
 * Collects all the information of house/button nodes
 * Logic used to prevent player from jumping to non-adjacent nodes
 * 
 */

public class Map : MonoBehaviour
{
    public Material line_material;
    public string TagName = "Node";
    public string TagName2 = "Path";
    public GameObject[] Paths;
    public GameObject[] Buttons;
    public GameObject Origin;
    private int currentIndex, previousIndex;
    public List<int> LastSelected = new List<int>(); //List of indexes of all buttons on the map
    void Start()
    {
        
        foreach (GameObject node in Buttons) //Initially sets all buttons to be interactable by the player
        {
            Node button = node.GetComponent<Node>();
            button.Interactable = true;
        }
    }
    
    private void Update()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag(TagName);
        Buttons = new GameObject[temp.Length];
        int iterate = 0;
        while (iterate < Buttons.Length) {
            foreach (GameObject node in temp)
            {
                if (node.GetComponent<Node>().order == iterate)
                {
                    Buttons[iterate] = node;
                }
            }
            iterate++;
        }


        if (LastSelected.Count == 0)
        {
            foreach (GameObject node in Buttons)
            {
                Node button = node.GetComponent<Node>();
                button.Interactable = true;
            }
        }
        else
        {
            foreach (GameObject node in Buttons)
            {
                Node buttontemp = node.GetComponent<Node>();
                buttontemp.Interactable = false;
            }
            int number = LastSelected.Count;
            int size_of_buttons = Buttons.Length;
            GameObject Button = Buttons[LastSelected[number - 1]];
            Origin = Buttons[LastSelected[0]];
            Node button = Origin.GetComponent<Node>();
            button.NodeOn = true;
            //Sets the first selected node as the origin and subsequent selections as extensions from origin
            int index = System.Array.IndexOf(Buttons, Button);
            Node curr_button = Buttons[index].GetComponent<Node>();
            curr_button.Interactable = true;
            if (index + 3 <= size_of_buttons - 1)
            {
                Node buttontemp2 = Buttons[index + 3].GetComponent<Node>();
                buttontemp2.Interactable = true;
            }
            if (index - 3 >= 0)
            {
                Node buttontemp2 = Buttons[index - 3].GetComponent<Node>();
                buttontemp2.Interactable = true;
            }
            if (index % 3 != 2 && index + 1 <= size_of_buttons - 1)
            {
                Node buttontemp2 = Buttons[index + 1].GetComponent<Node>();
                buttontemp2.Interactable = true;
            }
            if (index % 3 != 0 && index - 1 >= 0)
            {
                Node buttontemp2 = Buttons[index - 1].GetComponent<Node>();
                buttontemp2.Interactable = true;
            }//Logic used to make only the adjacent nodes (and itself) interactable 
        }
    }
}