using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PackageList
{
    //public GameObject textObject;
    static Text package_list;
    static string yes1;
    //static int count = 0;
    static List<Package> packages = new List<Package>();

    public static void Start()
    {


        yes1 = "";
        GameObject textObject = GameObject.FindGameObjectWithTag("Texty");

        package_list = textObject.GetComponent<Text>();
            Debug.Log("I have the old text box?");
            Debug.Log(Object.FindObjectOfType<Text>().text);
            Debug.Log(package_list.text);
        if (package_list==null)
        {
            package_list = textObject.GetComponent<Text>();
            Debug.Log("Override");
        }

        
        //DontDestroyOnLoad(textObject);
        int numOfPackages = 1; //Just 1 for testing

        for (int i = 0; i < numOfPackages; i++)
        {
            PackageGenerate();
        }
        /*
        foreach (Package package in list.packages)
        {
            package_list.GetComponent<Text>().text += package.get_type() + ' ' + package.get_condition() + "\n";
        }
        */
        foreach (Package package in packages)
        {
            Debug.Log(package.get_type() + ' ' + package.get_condition() + "\n");
            yes1 += package.get_type() + ' ' + package.get_condition() + "\n";
        }
        
        //yes1 += "Package" + count++ +"\n";

        package_list.text += yes1;
    }


    private static void PackageGenerate() {





    Package package = new Package();
        package.Generate();
        if (!packages.Contains(package))
        {
            packages.Add(package);

            Debug.Log(package.get_condition() + " and " + package.get_type());

        }
    }


}