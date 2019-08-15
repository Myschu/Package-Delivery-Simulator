/*PackageList
 * 
 * Static object that holds collection of packages that persists through multiple in-game days,
 * to ensure that players are still responsible for previously undelivered packages
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PackageList
{
    //Member variables
        //Text object and text for displaying info to player
        static Text package_list;

        //Collection of Package objects and size
        public static int numOfPackages;
        public static List<Package> packages = new List<Package>();
    
    //Initialization and collection of all package objects 
    public static void Start()
    {
       
        packages.RemoveAll(item => item == null);
        
        
        GameObject textObject = GameObject.FindGameObjectWithTag("Texty");
        
            
        /*Debugging
         * 
        //Debug.Log("I have the old text box?");
        //Debug.Log(Object.FindObjectOfType<Text>().text);
        //Debug.Log(package_list.text);
        if (package_list==null)
        {
            package_list = textObject.GetComponent<Text>();
            Debug.Log("Override");
        }
        */
       
       numOfPackages = 5; //Hardcoded to 5 for testing
     //numOfPackages = Random.Range(6, 8);

        for (int i = 0; i < numOfPackages; i++)
        {
            PackageGenerate();
        }
       
    }

   

    //Initializes new package object and its values, and adds to static collection
    private static void PackageGenerate()
    {
        Package package = new Package();
        package.Generate();
        if (!packages.Contains(package))
        {
            packages.Add(package);
            //Debug.Log(package.getCondition() + " and " + package.getType());
        }
    }


}