/*Package 
 * 
 * Each package will rolls properties upon initialization
 * 
 * As of 8.13.19, each object will have the following rates:
 *  Types:
 *      -70% chance to be an envelope (named as 'letter')
 *      -20% chance to be a package
 *      -10% chance to be a heavy package*
 *  
 *  Delivery Condition:
 *      -60% chance to have no special conditions
 *      -30% chance to require a signature
 *      -10% chance to be fragile.
 *      -*100% chance to require signature and be fragile if object is a heavy package 
 *  
 * The time a package takes to deliver and the $$$ awarded to player on 
 * successful delivery depends on the type and condition of the package
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package
{
    //Static variables
        static string[] types = { "letter", "package", "heavy package" };
        static string[] conditions = { "none", "requires signature", "is fragile", "requires signature and is fragile" };

    //Local variables
        private string type;
        private string condition;
        private int cost = 0; //$$ awarded to player 
        private int extraTime = 0; //additional time (in minutes) required to deliver 
        

    //Getter methods for this specific package's type, condition, $$ value, and extra time needed to deliver
    public string getType()
    {
        return type;
    }
    public string getCondition()
    {
        return condition;
    }
    public int getCost()
    {
        return cost;
    }
    public int getExtraTime()
    {
        return extraTime;
    }

    //Method is called by main package handler script PackageList to intialize each package
    public void Generate()
    {
        //roll values
        int typeRoll = roll_type();
        int conditionRoll = roll_condition(typeRoll);

        type = types[typeRoll];
        condition = conditions[conditionRoll];
        
        if (type == "letter")
        {
            cost += 1;

        }
        else if (type == "package")
        {
            cost += 4;
        }
        else if (type == "heavy package")
        {
            cost += 10;
            extraTime += 15;
        }
        if (condition == "requires signature")
        {
            cost += 3;
            extraTime += 5;
        }
        else if (condition == "is fragile")
        {
            cost += 3;
            extraTime += 10;
        }
    }

    //Methods to roll for type and condition
    private int roll_type()
    {
        int roll = Random.Range(1, 101);

        if (roll < 71)
        {
            return 0;
        }
        else if (roll < 91)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
    private int roll_condition(int type_roll)
    {
        int roll = Random.Range(1, 101);

        if (type_roll == 2)
        {
            return 3;
        }
        else if (roll < 61)
        {
            return 0;
        }
        else if (roll < 91)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
