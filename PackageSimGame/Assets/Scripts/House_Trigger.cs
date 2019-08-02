using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Trigger : MonoBehaviour
{

    private int extraTime, num_Packages;
    private Clock clock;
    private bool clockFlag;
    public House_Shared_Values houseHandler;
    private Stack<Package> assigned_packages = new Stack<Package>();
    private Stack<int> packageIndex = new Stack<int>();

   void Awake()
    {
        extraTime = Random.Range(0, 3);
        clock = Object.FindObjectOfType<Clock>();
        clockFlag = true;
        num_Packages = 0;
        //houseHandler = GameObject.FindGameObjectWithTag("HouseHandler").Get;

    }

    public void pushPackage(Package package)
    {
        assigned_packages.Push(package);
        num_Packages++;
    }
    public void pushIndex(int index)
    {
        packageIndex.Push(index);
    }

    private Package popPackage()
    {
        num_Packages--;
        return assigned_packages.Pop();
    }
    private int popIndex()
    {
        return packageIndex.Pop();
    }

    private bool hasPackages()
    {
        return (assigned_packages.Count > 0);
    }

    public int howManyPackages()
    {
        return num_Packages;
    }

  void OnTriggerEnter2D(Collider2D Truck)
    {
        string thisObj = name;

        if (hasPackages())
        {
            popPackage();
            int index = popIndex();
            PackageList.packages.RemoveAt(index);
            GameObject g = GameObject.FindGameObjectWithTag("PackageAssignmentHandler");
            g.GetComponent<PackageAssigner>().RemoveText(index);
        }


        if (clockFlag)
        {
            clock.Ticker(30 + extraTime);
            clockFlag = false;
        }
        //Debug.Log("Truck entered delivery space of : "+thisObj);
        //Debug.Log("There are "+houseHandler.subtractPackage()+" left");



    }

    void OnTriggerExit2D(Collider2D Truck)
    {
        clockFlag = true;
    }

    //Debugging only
    void Update()
    {
        if (Input.GetKeyDown("p") 
            && hasPackages()
            )
        {
            //Debug.Log(assigned_packages.Peek());
            Debug.Log("The house node " + name + " has " + assigned_packages.Count + " packages.");
        }
    }
}
