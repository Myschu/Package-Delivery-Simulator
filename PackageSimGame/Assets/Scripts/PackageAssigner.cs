using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageAssigner : MonoBehaviour
{
    public Text text;
    private string textToDisplay;
    GameObject[] houses;
    List<House_Trigger> nodes;
    int packageNumber;
    private List<string> textboxStuff = new List<string>();

    public List<House_Trigger> getHouses()
    {
        return nodes;
    } 

    /*Finds all houses and packages and assigns each package to a random house
    * Additionally, sends info to Textbox to be displayed to player
         */
    void Start()
    {
        nodes = new List<House_Trigger>();
        houses = GameObject.FindGameObjectsWithTag("House");        
        packageNumber = PackageList.numOfPackages;
        
        int index = 0;
        foreach (Package p in PackageList.packages)
        {
            string textToDisplay = "";
            House_Trigger node = houses[Random.Range(0, 16)].GetComponent<House_Trigger>();
            nodes.Add(node);
            node.pushPackage(p);
            node.pushIndex(index);
            if (p.getCondition() == "none")
            {
                textToDisplay += "There is a " + p.getType() + " to be delivered at: " + Address(node.name) + ".\n";
            }
            else
            {
                textToDisplay += "There is a " + p.getType() + " that " + p.getCondition() + " to be delivered at:\n" + Address(node.name) + ".\n\n";
            }
            textboxStuff.Add(textToDisplay);

            index++;
        }


        UpdateText(textboxStuff);

    }
    
    private string Address(string nodeName)
    {
        string returnString = "";
        int number;

        if (nodeName == "00-10")
        {
            number = Random.Range(1, 50);
            returnString += number + " Slumber Lumber Avenue";
        }
        if (nodeName == "10-20")
        {
            number = Random.Range(51, 100);
            returnString += number + " Slumber Lumber Avenue";
        }
        if (nodeName == "01-11")
        {
            number = Random.Range(1, 50);
            returnString += number + " Pocket Rocket Way";
        }
        if (nodeName == "11-21")
        {
            number = Random.Range(51, 100);
            returnString += number + " Pocket Rocket Way";
        }
        if (nodeName == "02-12")
        {
            number = Random.Range(1, 50);
            returnString += number + " Hardwood Grove";
        }
        if (nodeName == "12-22")
        {
            number = Random.Range(51, 100);
            returnString += number + " Hardwood Grove";
        }
        if (nodeName == "03-13")
        {
            number = Random.Range(1, 50);
            returnString += number + " Mourningwood Lane";
        }
        if (nodeName == "13-23")
        {
            number = Random.Range(51, 100);
            returnString += number + " Mourningwood Lane";
        }


        if (nodeName == "00-01")
        {
            number = Random.Range(1, 50);
            returnString += number + " Weast Main Street";
        }
        if (nodeName == "01-02")
        {
            number = Random.Range(51, 100);
            returnString += number + " Weast Main Street";
        }
        if (nodeName == "02-03")
        {
            number = Random.Range(101, 150);
            returnString += number + " Weast Main Street";
        }

        if (nodeName == "10-11")
        {
            number = Random.Range(1, 50);
            returnString += number + " Main Street";
        }
        if (nodeName == "11-12")
        {
            number = Random.Range(51, 100);
            returnString += number + " Main Street";
        }
        if (nodeName == "12-13")
        {
            number = Random.Range(101, 150);
            returnString += number + " Main Street";
        }

        if (nodeName == "20-21")
        {
            number = Random.Range(1, 50);
            returnString += number + " East Main Street";
        }
        if (nodeName == "21-22")
        {
            number = Random.Range(51, 100);
            returnString += number + " East Main Street";
        }
        if (nodeName == "22-23")
        {
            number = Random.Range(101, 150);
            returnString += number + " East Main Street";
        }



        return returnString;
    }

    public void RemoveText(int index)
    {
        textboxStuff[index] = "";
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
