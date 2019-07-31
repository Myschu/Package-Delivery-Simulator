using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Shared_Values : MonoBehaviour
{
    public static House_Shared_Values Instance { get; set; }
    private int numOfPackages=0;

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
        if (numOfPackages>0) { return --numOfPackages; }
        else return -1;
    }
}
