/**
 * Script containing logic for pathing of player game object (referred to as truck) 
 * 
 * 6-20-2019 : 
 *  -Added logic for retrieving the positions of a LineRenderer object that was generated a scene prior
 *  -Relies on the LineRenderer object being not destroyed over scene transition
 *  -Relies on there existing only one active LineRenderer object at any given time
 * 
 * 
 * 7-6-2019 : 
 *  -Added variables that are meant to be accessed by arrow buttons only.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathFollow : MonoBehaviour
{
    private static bool up, down, left, right;
    public static bool visible_Up, visible_Down, visible_Left, visible_Right;
   
    private bool movement_flag;
    private int current_index;


    public Clock clock;
    private Vector3 target;
    private int line_points;
    private LineRenderer Line;


    private GenerateLine map;
    private List<GameObject> last_selected_list;
    private string[] list_as_string;
    private GameObject[] Nodes, Path;

    //Might need to find some way to calculate this later on
    public float speed;


    //Counter that increments each node/position truck traverses
    //private int current=0; Deprecated 7/9/2019
    public static int count = 1;






    public static void getDirection(string direction)
    {
        if (count <= 1)
        {
            if (direction == "up") up = true;
            if (direction == "down") { down = true; Debug.Log("made it to down"); }
            if (direction == "left") left = true;
            if (direction == "right") right = true;
        }
        count++;

    } 



    //De-caches LineRenderer generated positions by creating an array of positions for truck to follow
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);

        //Local reference to LineRenderer object that was not deleted from scene transition
        Line = Object.FindObjectOfType<LineRenderer>();

        Nodes = GameObject.FindGameObjectsWithTag("MapLocationalNode");
        

        /* Nodes are listed in order from 00, 10, 20, 01, 11, 21, etc
         * 
         * to travel up/down, add/subtract index by 3
         * to travel left/right, add/subtract index by 1
    
        foreach (GameObject x in Nodes)
        {
            Debug.Log("Number " + count + ": " + x.name);
            count++;
        }
        */
        


        //6.25 string and node
        /*
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
        */



        //# of points since GetPositions requires an array parameter with a specific size.
        //line_points = Line.positionCount;



        //Local array for truck to follow
        //target = new Vector3[line_points];



        /*
         * Old pathing script (pre-7/6/2019)
        //target = new Vector3[sizeOfList];
        //Method for retrieving positions of generated line
        //Line.GetPositions(target);
        for (int t = 0; t < target.Length; t++)
        {
            target[t] = Path[t].transform.position;
        }
        */

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



        //Test
        //down = true;

    }
    
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("k"))
        //clock.hour == 10)
        {
            enabled = false;
            SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Additive);
        }
        //Converts vector3 positions to vector2. Vector3 positions don't work for some reason.
        else
        {
            Vector2 this_pos = new Vector2(transform.position.x, transform.position.y);

            Vector2 target_pos = findDirection();

            Vector2 pos = Vector2.MoveTowards(this_pos, target_pos, 10 * speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
            if(this_pos!=target_pos) movement_flag = true;
            //Vector2 target_pos = new Vector2(target[current].x, target[current].y);
            if (this_pos == target_pos)
            {
                speed = 0;

                if (movement_flag)
                {
                    //Resets directional 
                    if (up) { up = false; current_index += 3; }
                    if (down) { down = false; current_index -= 3; Debug.Log("am I here????"); }
                    if (left) { left = false; current_index -= 1; }
                    if (right){ right = false; current_index += 1;}
                

                    clock.Ticker();
                    movement_flag = false;
                    count = 1;
                }
            }
        }
    
    }

    private Vector2 findDirection()
    {
        Vector2 toReturn = new Vector2(transform.position.x, transform.position.y);


        if (up) toReturn = new Vector2(Nodes[current_index + 3].transform.position.x, Nodes[current_index + 3].transform.position.y);
        else if (down) { toReturn = new Vector2(Nodes[current_index - 3].transform.position.x, Nodes[current_index - 3].transform.position.y); Debug.Log(toReturn); }
        else if (right) toReturn = new Vector2(Nodes[current_index + 1].transform.position.x, Nodes[current_index + 1].transform.position.y);
        else if (left) toReturn = new Vector2(Nodes[current_index - 1].transform.position.x, Nodes[current_index - 1].transform.position.y);

        return toReturn;
    }
}
