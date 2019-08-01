using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Shared_Values : MonoBehaviour
{
    public static House_Shared_Values Instance { get; set; }
    private int numOfPackages=0;
    private int packageIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
     for (int i = 0; i < PackageList.packages.Capacity; i++)
        {
            if (PackageList.packages[i] != null) numOfPackages++; 
        }

    }
    
    public int subtractPackage()
    {
        decIndex();
        if (numOfPackages>0) { return --numOfPackages; }
        else return -1;
    }
    public int incIndex()
    {
        return packageIndex++;
    }
    public int decIndex()
    {
        //This should not occur
        if (packageIndex < 1 ) { return -1; }
            
        return packageIndex--;
    }
}
