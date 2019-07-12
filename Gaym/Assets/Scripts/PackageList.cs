using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageList : Singleton<PackageList>
{
    public GameObject textObject;
    GenerateDeliveries list = new GenerateDeliveries();
    private string yes1 = "";

    void Start()
    {
        Text package_list = textObject.GetComponent<Text>();
        int numOfPackages = 1; //Just 1 for testing

        for (int i = 0; i < numOfPackages; i++)
        {
            list.Start();
        }
        /*
        foreach (Package package in list.packages)
        {
            package_list.GetComponent<Text>().text += package.get_type() + ' ' + package.get_condition() + "\n";
        }
        */
        foreach (Package package in list.packages)
        {
            Debug.Log(package.get_type() + ' ' + package.get_condition() + "\n");
            yes1 += package.get_type() + ' ' + package.get_condition() + "\n";
        }
        package_list.GetComponent<Text>().text = yes1;
    }
}