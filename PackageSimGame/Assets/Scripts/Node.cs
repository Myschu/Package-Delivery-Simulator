using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Node
 * 
 * Logic/Inner workings of each house node/button in "Planning" Scene
 * Creates estimated time based on number of nodes clicked (into PathTime)
 * Looping routes recolors already selected nodes
 * 
 */

public class Node : MonoBehaviour
{
    public string TagName = "Map";
    public bool NodeOn = false;
    public bool Interactable = false;
    public bool isOn;
    Color[] Colors = { Color.white, Color.red, Color.cyan, Color.green };
    public Color color;
    public GameObject Button;
    public GameObject Map;
    public int order;
    private int color_index = 0;
    private int clicked_on = 0;
    private int tog;
    void Start()
    {
        GameObject textbox = GameObject.FindGameObjectWithTag("House_Pathing_Text");
        textbox.transform.position = new Vector2(350, 250);
        tog = 0;
        Map = GameObject.FindGameObjectWithTag(TagName);
    }
    
    void FixedUpdate()
    {
        Button.GetComponent<Button>().interactable = Interactable;
        Invoke("activate", 1.0f);


    }

    //Function called when a button/node is pressed. "tog" is a variable used to fix an issue where clicks would register more than once
    void activate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (tog == 0)
            {
                tog++;
                Button.GetComponent<Button>().onClick.AddListener(delegate
                {
                    TaskOnClick();
                });
            }
        }
    }

    //Action listener that adds the current button to a list of selected buttons used to calculate estimated time travelled, color change, and interactability of nodes
    void TaskOnClick()
    {
        Debug.Log("clicked");
        Map map = Map.GetComponent<Map>();
        int index = System.Array.IndexOf(map.Buttons, Button);
        int size = map.LastSelected.Count;
        if (size == 0)
        {
            map.LastSelected.Add(index);
            color_index += 1;
        }
        else if (index != map.LastSelected[size-1])
        {
            map.LastSelected.Add(index);
            color_index += 1;

        }
        else 
        {
            map.LastSelected.RemoveAt(map.LastSelected.Count - 1);
            color_index -= 1;
        }

        tog = 0;
        Button.GetComponent<Image>().color = Colors[color_index % 4];
    }
}