/**
 * Script containing logic for pathing of player game object (referred to as truck) 
 * 
 * 6-20-2019 : 
 *  -Added logic for retrieving the positions of a LineRenderer object that was generated a scene prior
 *  -Relies on the LineRenderer object being not destroyed over scene transition
 *  -Relies on there existing only one active LineRenderer object at any given time
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathFollow : MonoBehaviour
{

    public Clock clock;
    private Vector3[] target;
    private int line_points;
    private LineRenderer Line;


    private GenerateLine map;
    private List<GameObject> last_selected_list;
    private string[] list_as_string;
    private GameObject[] Nodes, Path;

    //Might need to find some way to calculate this later on
    public float speed;


    //Counter that increments each node/position truck traverses
    private int current=0;

    
    //De-caches LineRenderer generated positions by creating an array of positions for truck to follow
    void Start()
    {
        //Local reference to LineRenderer object that was not deleted from scene transition
        Line = Object.FindObjectOfType<LineRenderer>();

        Nodes = GameObject.FindGameObjectsWithTag("MapLocationalNode");

        //6.25 string and node
        map = FindObjectOfType<GenerateLine>();
        int sizeOfList = map.list_as_string.Length;

        foreach (string x in map.list_as_string)
        {
            if (x == null)
            {
                Debug.Log("decrement once due to null");
                sizeOfList--;
            }
        }


        Path = new GameObject[sizeOfList];
        int nodeIterate = 0;
        foreach (string s in map.list_as_string)
        {
            if (s != null)
            {

                foreach (GameObject node in Nodes)
                {
                    if (s.Equals(node.name))
                    {
                        Path[nodeIterate++] = node;
                    }
                }

            }
        }




        //# of points since GetPositions requires an array parameter with a specific size.
        //line_points = Line.positionCount;



        //Local array for truck to follow
        //target = new Vector3[line_points];
        target = new Vector3[sizeOfList];


        //Method for retrieving positions of generated line
        //Line.GetPositions(target);
        for (int t = 0; t < target.Length; t++)
        {
            target[t] = Path[t].transform.position;
        }

        /*

        movement_flag = false;

        //Set current index position of truck
        foreach (GameObject x in Nodes)
        {
            if (x.transform.position == transform.position)
            {
                break;
            }
            current_index++;
        }
        Debug.Log(current_index); // Should be 0 to start

        /*
        Static_Button_Info.Up = false;
        Static_Button_Info.Down = false;
        Static_Button_Info.Left = false;
        Static_Button_Info.Right = false;
        
        UI_Directions = GameObject.FindGameObjectsWithTag("UI_Directions");


        foreach (GameObject e in UI_Directions)
        {

            if (e.name == "Right Arrow")
            {
                UI_Image_RIGHT = e;
                Debug.Log("Success for " + e.name);
                //e.SetActive(false);
            }
            if (e.name == "Left Arrow")
            {
                UI_Image_LEFT = e;
                Debug.Log("Success for " + e.name);
                //e.SetActive(false);
            }
            if (e.name == "Up Arrow")
            {
                UI_Image_UP = e;
                Debug.Log("Success for " + e.name);
                //e.SetActive(false);
            }
            if (e.name == "Down Arrow")
            {
                UI_Image_DOWN = e;
                Debug.Log("Success for " + e.name + " " + e.transform.position);
            }

        }

        up = Static_Button_Info.Up;
        down = Static_Button_Info.Down;
        left = Static_Button_Info.Left;
        right = Static_Button_Info.Right;

        //Test
        //down = true;
        */

    }
    
    // Update is called once per frame
    void Update()
    {
        if (clock.hour == 10)
        {
            enabled = false;
            SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Additive);
        }
        //When truck reaches end of path
        if (current == target.Length) {
            speed = 0;
            //Any additional logic that needs to occur after truck reaches destination node goes here
        }
        //Converts vector3 positions to vector2. Vector3 positions don't work for some reason.
        else
        {
            /*
            Vector2 this_pos = new Vector2(transform.position.x, transform.position.y);
            Vector2 target_pos = new Vector2(target[current].x, target[current].y);
            if (this_pos != target_pos)
            {
                Vector2 pos = Vector2.MoveTowards(this_pos, target_pos, 10 * speed * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(pos);
            }
            else
            {
                current = (current + 1);
                clock.Ticker();
            }
            */
        }
    
    }
}
