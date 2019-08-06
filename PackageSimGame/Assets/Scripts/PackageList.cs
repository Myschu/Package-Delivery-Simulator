using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PackageList
{
    //public GameObject textObject;
    static Text package_list;
    static string yes1, textToDisplay;
    public static bool hasList = false;
    public static int numOfPackages;
    //static int count = 0;
    public static List<Package> packages = new List<Package>();

    private static  List<House_Trigger> nodes; 

    public static void Start()
    {
        nodes = Object.FindObjectOfType<PackageAssigner>().getHouses();
        packages.RemoveAll(item => item == null);
        textToDisplay = "";
        
        //yes1 = "";
        GameObject textObject = GameObject.FindGameObjectWithTag("Texty");

        package_list = textObject.GetComponent<Text>();
            //Debug.Log("I have the old text box?");
           // Debug.Log(Object.FindObjectOfType<Text>().text);
            //Debug.Log(package_list.text);
        if (package_list==null)
        {
            package_list = textObject.GetComponent<Text>();
            Debug.Log("Override");
        }

       
        //DontDestroyOnLoad(textObject);
        numOfPackages = 3; //Just 1 for testing

        //numOfPackages = Random.Range(6, 8);

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
        int index = 0;
        
        
        //yes1 += "Package" + count++ +"\n";

        package_list.text += textToDisplay;
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