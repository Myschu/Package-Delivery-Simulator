using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageAssigner : MonoBehaviour
{
    public Text text;
    private string textToDisplay;
    GameObject[] houses;
    int packageNumber;
    private List<string> textboxStuff = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
        houses = GameObject.FindGameObjectsWithTag("House");

        //packageNumber = Random.Range(6, 8);
        packageNumber = PackageList.numOfPackages;

        //int index = packageNumber;
        /* Debugging
        int i = 0;
        foreach (GameObject haus in houses) {
            Debug.Log(++i +") "+ haus.name);
        }
        */
        int index = 0;
        foreach (Package p in PackageList.packages)
        //while (index > 0)
        {
            string textToDisplay = "";
            //Package package = new Package();
            //package.Generate();
            House_Trigger node = houses[Random.Range(0, 16)].GetComponent<House_Trigger>();

            node.pushPackage(p);
            node.pushIndex(index);
            //node.PackageList.packages.IndexOf(p));

            textToDisplay += "There is "+node.howManyPackages()+" package(s) to be delivered at: " + node.name + ".\n";
            textboxStuff.Add(textToDisplay);

            index++;
            //index--;
        }


        UpdateText(textboxStuff);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveText(int index)
    {
        textboxStuff.RemoveAt(index);
        UpdateText(textboxStuff);
    }

    public void UpdateText(List<string> text)
    {
        this.text.text = "";
        foreach (string t in text) {
            this.text.text += t;
                }
        
    }

}
