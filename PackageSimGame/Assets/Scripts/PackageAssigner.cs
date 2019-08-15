/*PackageAssigner
 * 
 * Main logic for handling the assignment of package objects to delivery locations and generating text for player
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageAssigner : MonoBehaviour
{
    //Text box assigned manually in Unity which will display info to player
        public Text text;

    //Local variables
        private string textToDisplay;
        private GameObject[] houses;
        private List<House_Trigger> nodes; //Dynamically sized collection containing each delivery area
        private int packageNumber;
        private List<string> textboxStuff = new List<string>();


    //Unused getter for list of delivery areas
    public List<House_Trigger> getHouses()
    {
        return nodes;
    } 

    /* Occurs upon load
     * 
     * Finds all houses and packages and assigns each package to a random house
     * Additionally, sends generated address info to Textbox to be displayed to player
     * 
     */
    void Start()
    {
        nodes = new List<House_Trigger>();
        houses = GameObject.FindGameObjectsWithTag("House");        
        packageNumber = PackageList.numOfPackages;
        

        //Every package is randomly assigned to a delivery area with equal weighting.
        //and an address is generated as delivery destination
        int index = 0;
        foreach (Package p in PackageList.packages)
        {
            string textToDisplay = "";
            House_Trigger node = houses[Random.Range(0, houses.Length)].GetComponent<House_Trigger>();
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
    
    //Helper method with temporarily hard-coded street names
    //House numbers are given a range according to pre-determined map in Unity assets folder
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

        //Intentional rhombic yellow sponge reference
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

    //Setter for text display used by House_Trigger to update list whenever delivery is successful (and therefore removes that package from the list)
    public void RemoveText(int index)
    {
       
            textboxStuff[index] = "";
            UpdateText(textboxStuff);
       
    }

    //Check for reset logic
    public bool hasText()
    {
        bool has = false;

        foreach ( string text in textboxStuff)
        {
            if (!(text == "")) 
            {
                has = true;
            }
        }
        return has;
    }


    //Ensures that new text is generated every time so that there is no unintended additive effect
    private void UpdateText(List<string> text)
    {
        this.text.text = "";
        foreach (string t in text) {
            this.text.text += t;
                }
        
    }

}
