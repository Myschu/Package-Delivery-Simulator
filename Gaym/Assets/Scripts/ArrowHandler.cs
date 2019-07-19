using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour
{

    private GameObject truck;
    private Rigidbody2D truckBod;
    private GameObject[] Nodes;
    private Vector2 current, target;
    private int currentIndex;
    private bool directionChosen;


    // Start is called before the first frame update
    void Start()
    {
        truck = GameObject.FindGameObjectWithTag("Truck");
        Nodes = GameObject.FindGameObjectsWithTag("MapLocationalNode");
        directionChosen = false;

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
        Debug.Log("Clicked OnClickUp");
        Debug.Log((currentIndex + 3) + " and ");
        Debug.Log(Nodes.Length+"\n");
        if (currentIndex + 3 < Nodes.Length)
        {
            target = Nodes[currentIndex + 3].transform.position;
            directionChosen = true; 
        }
    }
    public void OnClickDown()
    {
        Debug.Log("Clicked OnClickDown");
        Debug.Log((currentIndex - 3) + " and ");
        Debug.Log(Nodes.Length + "\n");
        if (currentIndex - 3 > 0)
        {
            target = Nodes[currentIndex - 3].transform.position;
            directionChosen = true;
        }
    }
    public void OnClickRight()
    {
        Debug.Log("Clicked OnClickRight");
        Debug.Log(currentIndex % 3 + "\n");
        if (currentIndex % 3 != 2)
        {
            target = Nodes[currentIndex + 1].transform.position;
            directionChosen = true;
        }
    }
    public void OnClickLeft()
    {
        Debug.Log("Clicked OnClickLeft");
        Debug.Log((currentIndex % 3) +  "\n");
        if (currentIndex % 3 != 0)
        {
            target = Nodes[currentIndex - 1].transform.position;
            directionChosen = true;
        }
    }

    private void assessUpdatedPos()
    {
        current = truckBod.transform.position;
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

   void Update()
    {
        if (directionChosen)
        {
            Vector2 moving = Vector2.Lerp(current, target, 1);
            truckBod.MovePosition(moving);
            if ((int)truck.transform.position.x == (int)target.x &&
                (int)truck.transform.position.y == (int)target.y)
            {
                Debug.Log("I'm inside check");
                directionChosen = false;
                assessUpdatedPos();
            }
        }

    }
}
