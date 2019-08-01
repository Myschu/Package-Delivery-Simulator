using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Trigger : MonoBehaviour
{

    private int extraTime, packages;
    private Clock clock;
    private bool clockFlag, hasPackages;
    public House_Shared_Values houseHandler;
    private Stack<Package> thisNodePackages;

    void Awake()
    {
        extraTime = Random.Range(0, 3);

        packages = rollPackageNum();

        clock = Object.FindObjectOfType<Clock>();
        clockFlag = true;
        thisNodePackages = new Stack<Package>();
        while (packages != 0)
        {
            thisNodePackages.Push(PackageList.packages[houseHandler.incIndex()]);
            packages--;
        }
        if (thisNodePackages != null)
        {        
        assessPackage();
        }

        //houseHandler = GameObject.FindGameObjectWithTag("HouseHandler").Get;

    }
    void assessPackage()
    {
        if (thisNodePackages.Count > 0)
        {
            hasPackages = true;
        }
        else hasPackages = false;
    }
    int rollPackageNum()
    {
        int roll = Random.Range(0, 100);

        if (roll < 71)
        {
            return 0;
        }
        else if (roll < 91)
        {
            return 1;
        }
        else
        {
            return 2;
        }

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

        if (hasPackages)
        {
            thisNodePackages.Pop();
            Debug.Log("Delivery of package successful.\n");
            Debug.Log("There are " + houseHandler.subtractPackage() + " left");

            assessPackage();

        }

    }

    void OnTriggerExit2D(Collider2D Truck)
    {
        clockFlag = true;
    }
}
