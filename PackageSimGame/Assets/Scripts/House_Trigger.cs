/*HouseTrigger
 * 
 * Delivery logic used during driving phase
 * Handler for package delivery and extra time
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Trigger : MonoBehaviour
{
    //Local variables
        private int extraTime, num_Packages;
        private Clock clock;
        private bool clockFlag;

        //Parallel Stacks used to handle delivery logic
        private Stack<Package> assigned_packages = new Stack<Package>();
        private Stack<int> packageIndex = new Stack<int>();
    
    // public variable (set in Unity) to set the order in which this object is loaded for movement
        public int order;

    //Set values before any object's Start function
   public void Awake()
    {
        extraTime = 0;
        clock = Object.FindObjectOfType<Clock>();
        clockFlag = true;
        num_Packages = 0;
    }

    //Packages are loaded by another script 
    public void pushPackage(Package package)
    {
        assigned_packages.Push(package);
        num_Packages++;
    }
    public void pushIndex(int index)
    {
        packageIndex.Push(index);
    }

    //Remove packages as delivery occurs
    private Package popPackage()
    {
        num_Packages--;
        return assigned_packages.Pop();
    }
    private int popIndex()
    {
        return packageIndex.Pop();
    }

    //Check if not empty
    private bool hasPackages()
    {
        return (assigned_packages.Count > 0);
    }

    //Getter method for package number
    public int howManyPackages()
    {
        return num_Packages;
    }

    //Delivery occurs as Truck enters this object's trigger area
  void OnTriggerEnter2D(Collider2D Truck)
    {
       //Counts each time package is popped and delivered
        int howManyLoops = 0;

        //For each package, adds extra time and the money gained 
        while (hasPackages())
        {
            Package pack = popPackage();

            extraTime = pack.getExtraTime();
            Money.Instance.money += pack.getCost();
            
            int index = popIndex();
            //Debug.Log("Index popped = " + index);
            //Debug.Log("\nPackage at index = " + PackageList.packages[index].getCondition() + " " +PackageList.packages[index].getType());

            PackageList.packages[index] = null;
            GameObject g = GameObject.FindGameObjectWithTag("PackageAssignmentHandler");
            g.GetComponent<PackageAssigner>().RemoveText(index);

            howManyLoops++;

        }
        
        //Ensures that no extra time is added if there are no deliveries in this area
        if (howManyLoops == 0)
        {
            extraTime = 0;
        }

        //Ensures clock only moves forward in time once
        if (clockFlag)
        {
            clock.Ticker(30 + extraTime);
            clockFlag = false;
        }
        //Debug.Log("Truck entered delivery space of : "+thisObj);
        //Debug.Log("There are "+houseHandler.subtractPackage()+" left");



    }

    //Resets clock flag to allow for clock to move next time truck enters this area
    void OnTriggerExit2D(Collider2D Truck)
    {
        clockFlag = true;
    }

    //Debugging use only
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
