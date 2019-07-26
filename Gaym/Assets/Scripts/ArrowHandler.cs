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
    private int currentIndex;
    private bool directionChosen;
    


    // Start is called before the first frame update
    void Start()
    {
        truck = GameObject.FindGameObjectWithTag("Truck");
        Nodes = GameObject.FindGameObjectsWithTag("MapLocationalNode");
        directionChosen = false;

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
        if (!directionChosen)
        {
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
        if (!directionChosen)
        {
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
        if (!directionChosen)
        {
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
        if (!directionChosen)
        {
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

        if ((Input.GetKeyDown("down")|| Input.GetKeyDown("s")))
        {
            OnClickDown();
        }
        if (Input.GetKeyDown("up")|| Input.GetKeyDown("w"))
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
            Vector2 moving = Vector2.MoveTowards(current,target,1.0f);
            if (
                (!((int)truck.transform.position.x == (int)target.x &&
                (int)truck.transform.position.y == (int)target.y)))
            {
                truckBod.MovePosition(moving);
                
                if (Mathf.Floor(truckBod.transform.position.x) == Mathf.Floor(testHouse.transform.position.x) &&
                    Mathf.Floor(truckBod.transform.position.y) == Mathf.Floor(testHouse.transform.position.y))
                {
                    Debug.Log("Successfully delivered to house along '00-10' street");
                }



            }
            else
            {

                clock.Ticker(30);
                Debug.Log("I'm inside check");
                directionChosen = false;
               
            }
            assessUpdatedPos();
        }

    }
}
