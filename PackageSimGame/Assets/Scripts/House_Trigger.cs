using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Trigger : MonoBehaviour
{

    private int extraTime;
    private Clock clock;
    private bool clockFlag;
    public House_Shared_Values houseHandler;
    //private Stack<Package>

   void Awake()
    {
        extraTime = Random.Range(0, 3);
        clock = Object.FindObjectOfType<Clock>();
        clockFlag = true;

        //houseHandler = GameObject.FindGameObjectWithTag("HouseHandler").Get;

    }

  void OnTriggerEnter2D(Collider2D Truck)
    {
        string thisObj = name;
        if (clockFlag)
        {
            clock.Ticker(30 + extraTime);
            clockFlag = false;
        }
        Debug.Log("Truck entered delivery space of : "+thisObj);
        Debug.Log("There are "+houseHandler.subtractPackage()+" left");



    }

    void OnTriggerExit2D(Collider2D Truck)
    {
        clockFlag = true;
    }
}
