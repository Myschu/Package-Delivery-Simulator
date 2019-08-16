/*ArrowHandler 
 * 
 * Main game logic used to during driving phase
 * Handler for Arrow buttons, truck movement, and end-day trigger
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ArrowHandler : MonoBehaviour
{
    //Local variables
        
        private GameObject truck;
    
        //Used to check for day end
        private Clock clock;

        private Rigidbody2D truckBod;

        //Street corner locations
        private GameObject[] Nodes;

        //Delivery trigger area
        private GameObject[] houses;

        private Vector2 current, target;

        //For keeping track of where truck is
        private int currentIndex, previousIndex;

        //Unused
        private int extraTime;

        //Flags
        private bool directionChosen, clockFlag, currentScene;

    
    //Initializing variables by finding in Scene using tags
    void Start()
    {

        truck = GameObject.FindGameObjectWithTag("Truck");
     
        GameObject[] temp = GameObject.FindGameObjectsWithTag("MapLocationalNode");
        Nodes = new GameObject[temp.Length];


        //Collection of street corner objects according to assigned order
        int iterate = 0;
        while (iterate < Nodes.Length)
        {
            foreach (GameObject node in temp)
            {
                if (node.GetComponent<LocationalNodeOrder>().order == iterate)
                {
                    Nodes[iterate] = node;
                }
            }
            iterate++;
        }


        directionChosen = false;
        currentScene = true;
        
        clock = Object.FindObjectOfType<Clock>();


        houses = GameObject.FindGameObjectsWithTag("House");


        /*Debugging use only
         *
         * foreach (GameObject house in houses)
        {
            if (house.name == houseName)
            {
                //testHouse = house;
                //Debug.Log("This is the house pos: "+testHouse.transform.position);
            }
        }
        */

        //Checks for assignment 
        if (truck == null) { Debug.Log("It's not here"); }
        else if (Nodes == null) { Debug.Log("The nodes aren't here"); }
        else
        {
            truckBod = truck.GetComponent<Rigidbody2D>();
            //Debug.Log(Nodes.Length+ " \n");
            assessUpdatedPos();
        }
    }
    
    /*Movement Logic
     * 
     * -Updates previousIndex
     * -Sets target position
     * -Flags directionChosen
     */
        //Logic for movement up
        public void OnClickUp()
        {
            if ((!directionChosen) && currentScene)
            {
                previousIndex = currentIndex;
                //Debug.Log("Clicked OnClickUp");
                //Debug.Log((currentIndex + 3) + " and ");
                //Debug.Log(Nodes.Length + "\n");
                if (currentIndex + 3 < Nodes.Length)
                {
                    target = Nodes[currentIndex + 3].transform.position;
                    directionChosen = true;
                    Moves.Instance.moves++; //Tracks total number of moves made over course of game
                }
            }
        }

        //Logic for movement down
        public void OnClickDown()
        {
            if ((!directionChosen) && currentScene)
            {
                previousIndex = currentIndex;
                //Debug.Log("Clicked OnClickDown");
                //Debug.Log((currentIndex - 3) + " and ");
                //Debug.Log(Nodes.Length + "\n");
                if (currentIndex - 3 >= 0)
                {
                    target = Nodes[currentIndex - 3].transform.position;
                    directionChosen = true;
                    Moves.Instance.moves++;
                }
            }
        
        }

        //Logic for movement right
        public void OnClickRight()
        {
            if ((!directionChosen) && currentScene)
            {
                previousIndex = currentIndex;
                //Debug.Log("Clicked OnClickRight");
                //Debug.Log(currentIndex % 3 + "\n");
                if (currentIndex % 3 != 2)
                {
                    target = Nodes[currentIndex + 1].transform.position;
                    directionChosen = true;
                    Moves.Instance.moves++;
                }
            }
        }

        //Logic for movement left
        public void OnClickLeft()
        {
            if ((!directionChosen)&&currentScene)
            {
                previousIndex = currentIndex;
                //Debug.Log("Clicked OnClickLeft");
                //Debug.Log((currentIndex % 3) + "\n");
                if (currentIndex % 3 != 0)
                {
                    target = Nodes[currentIndex - 1].transform.position;
                    directionChosen = true;

                    Moves.Instance.moves++;
                }
            }
        }

    //Updates current position and the currentIndex
    private void assessUpdatedPos()
    {
        current = truckBod.transform.position;

        if (!directionChosen)
        {
            for (currentIndex = 0; currentIndex < Nodes.Length; currentIndex++)
            {
                Debug.Log("current.x = " + (int)current.x + " and "); Debug.Log("nodes x = " + (int)Nodes[currentIndex].transform.position.x + "\n");
                Debug.Log("current.y = " + (int)current.y + " and "); Debug.Log("nodes y = " + (int)Nodes[currentIndex].transform.position.y + "\n");
                if ((int)current.x == (int)Nodes[currentIndex].transform.position.x &&
                    (int)current.y == (int)Nodes[currentIndex].transform.position.y)
                {
                    //Debug.Log("The current index is " + currentIndex + "\n");
                    break;
                }
            }
        }

    }
    

    /*On every frame, checks:
     * 
     * -If time is 6pm or later (day ends if true)
     * -Keyboard input from player
     * -If a direction for movement has been chosen
     * 
     */
   void Update()
    {
        //Time
        if (clock.hour%12 == 6)
        {
            enabled = false;
            SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Single);
        }
        
        //Keyboard Input
            if ((Input.GetKeyDown("down") || Input.GetKeyDown("s")))
            {
                OnClickDown();
            }
            if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            {
                OnClickUp();
            }

            if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
            {
                OnClickLeft();
            }
            if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
            {
                OnClickRight();
            }
        
        //Direction has been chosen
        if (directionChosen)
        {

            Vector2 moving = Vector2.MoveTowards(current,target,5);

            if ((!((int)truck.transform.position.x == (int)target.x &&
                (int)truck.transform.position.y == (int)target.y)))
                { truckBod.MovePosition(moving); }
            else
                {
                    clockFlag = true;
                    //Debug.Log("not moving");
                    directionChosen = false;
                }

            assessUpdatedPos();

            if (clockFlag) clockFlag = false;
            
        }

    }
    
    //Unused setter method for extraTime
    public void setExtraTime(int time)
    {
        extraTime = time; 
    }
}

