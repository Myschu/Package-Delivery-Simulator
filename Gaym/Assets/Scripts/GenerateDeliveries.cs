using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDeliveries : MonoBehaviour
{
    //public List<Package> packages = new List<Package>();

    public void Start()
    {


        PackageList.Start();
        /*
        THIS CODE MOVED TO PackageList.CS
    
        Package package = new Package();
        package.Generate();
        if (!packages.Contains(package))
        {
            packages.Add(package);
            
            Debug.Log(package.get_condition()+ " and "+ package.get_type() );

        }
        */
    }
}