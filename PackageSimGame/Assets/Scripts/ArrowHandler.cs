using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowHandler : MonoBehaviour
{

    private GameObject truck, testHouse;
    private Clock clock;
    private Rigidbody2D truckBod;
    private GameObject[] Nodes, houses;
    private Vector2 current, target;
    private int currentIndex, previousIndex, extraTime;
    private bool directionChosen,clockFlag, currentScene;

    

    public void setScene(bool setting)
    {
        currentScene = setting;
    }
    // Start is called before the first frame update
    void Start()
    {
        extraTime = 0;
        truck = GameObject.FindGameObjectWithTag("Truck");
        Nodes = GameObject.FindGameObjectsWithTag("MapLocationalNode");
        directionChosen = false;
        currentScene = true;

        clock = Object.FindObjectOfType<Clock>();


        houses = GameObject.FindGameObjectsWithTag("House");

        foreach (GameObject house in houses)
        {
            if (house.name == "00-10")
            {
                testHouse = house;
                Debug.Log("This is the house pos: "+testHouse.transform.position);
            }
        }


        if (truck == null) { Debug.Log("It's not here"); }
        else if (Nodes == null) { Debug.Log("The nodes aren't here"); }
        else
        {

            truckBod = truck.GetComponent<Rigidbody2D>();

            Debug.Log(Nodes.Length+ " \n");
            
            
            assessUpdatedPos();
        }
    }
    
    public void OnClickUp()
    {
        if ((!directionChosen) && currentScene)
        {
            previousIndex = currentIndex;
            Debug.Log("Clicked OnClickUp");
            Debug.Log((currentIndex + 3) + " and ");
            Debug.Log(Nodes.Length + "\n");
            if (currentIndex + 3 < Nodes.Length)
            {
                target = Nodes[currentIndex + 3].transform.position;
                directionChosen = true;
            }
        }
    }
    public void OnClickDown()
    {
        if ((!directionChosen) && currentScene)
        {
            previousIndex = currentIndex;
            Debug.Log("Clicked OnClickDown");
            Debug.Log((currentIndex - 3) + " and ");
            Debug.Log(Nodes.Length + "\n");
            if (currentIndex - 3 >= 0)
            {
                target = Nodes[currentIndex - 3].transform.position;
                directionChosen = true;
            }
        }
        
    }
    public void OnClickRight()
    {
        if ((!directionChosen) && currentScene)
        {
            previousIndex = currentIndex;
            Debug.Log("Clicked OnClickRight");
            Debug.Log(currentIndex % 3 + "\n");
            if (currentIndex % 3 != 2)
            {
                target = Nodes[currentIndex + 1].transform.position;
                directionChosen = true;
            }
        }
    }
    public void OnClickLeft()
    {
        if ((!directionChosen)&&currentScene)
        {
            previousIndex = currentIndex;
            Debug.Log("Clicked OnClickLeft");
            Debug.Log((currentIndex % 3) + "\n");
            if (currentIndex % 3 != 0)
            {
                target = Nodes[currentIndex - 1].transform.position;
                directionChosen = true;
            }
        }
    }

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
                    Debug.Log("The current index is " + currentIndex + "\n");
                    break;
                }
            }
        }

    }

   void Update()
    {
        if (clock.hour%12 == 6)
        {
            enabled = false;
            SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Single);
        }
        
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
        

        if (directionChosen)
        {
            Vector2 moving = Vector2.MoveTowards(current,target,5);
            if (
                (!((int)truck.transform.position.x == (int)target.x &&
                (int)truck.transform.position.y == (int)target.y)))
            {
                truckBod.MovePosition(moving);
                /*
                if (Mathf.Floor(truckBod.transform.position.x) == Mathf.Floor(testHouse.transform.position.x) &&
                    Mathf.Floor(truckBod.transform.position.y) == Mathf.Floor(testHouse.transform.position.y))
                {
                    Debug.Log("Successfully delivered to house along '00-10' street");
                }
                */


            }
            else
            {


                clockFlag = true;
                
                Debug.Log("I'm inside check");
                directionChosen = false;
               
            }
            assessUpdatedPos();
            if (clockFlag)
            {
                //clock.Ticker(30+extraTime);
                //checkDelivery();
                clockFlag = false;
            }
        }

    }
    /* Defunct check delivery method
     * 
    private void checkDelivery()
    {   
        //Implement logic for delivery within each inner condition body prefaced with Path identifier
        if (previousIndex == 0)
        {
            if (currentIndex == 1)
            {
                //Path is : 00-10
                Debug.Log("Successfully delivered to house along '00-10' street");
                /*Testing money
                 *Money.Instance.money += 1;
                 *Debug.Log(Money.Instance.money);
                
            }
            else if (currentIndex == 3)
            {
                //Path is : 00-01
                Debug.Log("Successfully delivered to house along '00-01' street");
            }
        }

        else if (previousIndex == 1)
        {
            if (currentIndex == 0)
            {
                //Path is : 10-00
                Debug.Log("Successfully delivered to house along '00-10' street");
            }
            else if (currentIndex == 4)
            {
                //Path is : 10-11
                Debug.Log("Successfully delivered to house along '10-11' street");
            }
            else if (currentIndex == 2)
            {
                //Path is : 10-20
                Debug.Log("Successfully delivered to house along '10-20' street");
            }
        }

        else if (previousIndex == 2)
        {
            if (currentIndex == 5)
            {
                //Path is : 20-21
                Debug.Log("Successfully delivered to house along '20-21' street");
            }
            else if (currentIndex == 1)
            {
                //Path is : 20-10
                Debug.Log("Successfully delivered to house along '10-20' street");
            }
        }

        else if (previousIndex == 3)
        {
            if (currentIndex == 0)
            {
                //Path is : 01-00
                Debug.Log("Successfully delivered to house along '00-01' street");
            }
            else if (currentIndex == 4)
            {
                //Path is : 01-11
                Debug.Log("Successfully delivered to house along '01-11' street");
            }
            else if (currentIndex == 6)
            {
                //Path is : 01-02
                Debug.Log("Successfully delivered to house along '01-02' street");
            }
        }

        else if (previousIndex == 4)
        {
            if (currentIndex == 1)
            {
                //Path is : 11-10
                Debug.Log("Successfully delivered to house along '10-11' street");
            }
            else if (currentIndex == 3)
            {
                //Path is : 11-01
                Debug.Log("Successfully delivered to house along '01-11' street");
            }
            else if (currentIndex == 5)
            {
                //Path is : 11-21
                Debug.Log("Successfully delivered to house along '11-21' street");
            }
            else if (currentIndex == 7)
            {
                //Path is : 11-12
                Debug.Log("Successfully delivered to house along '11-12' street");
            }
        }

        else if (previousIndex == 5)
        {
            if (currentIndex == 2)
            {
                //Path is : 21-20
                Debug.Log("Successfully delivered to house along '20-21' street");
            }
            else if (currentIndex == 4)
            {
                //Path is : 21-11
                Debug.Log("Successfully delivered to house along '11-21' street");
            }
            else if (currentIndex == 8)
            {
                //Path is : 21-22
                Debug.Log("Successfully delivered to house along '21-22' street");
            }
        }

        else if (previousIndex == 6)
        {
            if (currentIndex == 9)
            {
                //Path is : 02-03
                Debug.Log("Successfully delivered to house along '02-03' street");
            }
            else if (currentIndex == 7)
            {
                //Path is : 02-12
                Debug.Log("Successfully delivered to house along '02-12' street");
            }
            else if (currentIndex == 3)
            {
                //Path is : 02-01
                Debug.Log("Successfully delivered to house along '01-02' street");
            }
        }

        else if (previousIndex == 7)
        {
            if (currentIndex == 10)
            {
                //Path is : 12-13
                Debug.Log("Successfully delivered to house along '12-13' street");
            }
            else if (currentIndex == 4)
            {
                //Path is : 12-11
                Debug.Log("Successfully delivered to house along '11-12' street");
            }
            else if (currentIndex == 6)
            {
                //Path is : 12-02
                Debug.Log("Successfully delivered to house along '12-02' street");
            }
            else if (currentIndex == 8)
            {
                //Path is : 12-22
                Debug.Log("Successfully delivered to house along '12-22' street");
            }
        }

        else if (previousIndex == 8)
        {
            if (currentIndex == 11)
            {
                //Path is : 22-23
                Debug.Log("Successfully delivered to house along '22-23' street");
            }
            else if (currentIndex == 7)
            {
                //Path is : 22-12
                Debug.Log("Successfully delivered to house along '12-22' street");
            }
            else if (currentIndex == 5)
            {
                //Path is : 22-21
                Debug.Log("Successfully delivered to house along '21-22' street");
            }
        }

        else if (previousIndex == 9)
        {
            if (currentIndex == 10)
            {
                //Path is : 03-13
                Debug.Log("Successfully delivered to house along '03-13' street");
            }
            else if (currentIndex == 6)
            {
                //Path is : 03-02
                Debug.Log("Successfully delivered to house along '02-03' street");
            }
        }

        else if (previousIndex == 10)
        {
            if (currentIndex == 11)
            {
                //Path is : 13-23
                Debug.Log("Successfully delivered to house along '13-23' street");
            }
            else if (currentIndex == 9)
            {
                //Path is : 13-03
                Debug.Log("Successfully delivered to house along '03-13' street");
            }
            else if (currentIndex == 7)
            {
                //Path is : 13-12
                Debug.Log("Successfully delivered to house along '12-13' street");
            }
        }

        else if (previousIndex == 11)
        {
            if (currentIndex == 10)
            {
                //Path is : 23-13
                Debug.Log("Successfully delivered to house along '13-23' street");
            }
            else if (currentIndex == 8)
            {
                //Path is : 23-22
                Debug.Log("Successfully delivered to house along '22-23' street");
            }
        }
    

    }
    */
    public void setExtraTime(int time)
    {
        extraTime = time; 
    }
}

