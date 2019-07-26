using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package
{

    static string[] types = { "mail", "package", "heavy" };
    static string[] conditions = { "none", "signature", "fragile", "signature and fragile" };

    private string type;
    private string condition;
    private int cost = 0;
    private GameObject destination;
    public void Generate()
    {
        int typeRoll = roll_type();
        int conditionRoll = roll_condition(typeRoll);

        type = types[typeRoll];
        condition = conditions[conditionRoll];

        //destination = 
        if (type == "mail")
        {
            cost += 1;
        }
        else if (type == "package")
        {
            cost += 3;
        }
        else if (type == "heavy")
        {
            cost += 5;
        }
        if (condition == "signature")
        {
            cost += 3;
        }
        else if (condition == "fragile")
        {
            cost += 5;  
        }
    }


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

    public string get_type()
    {
        return type;
    }
    public string get_condition()
    {
        return condition;
    }
    public string get_cost()
    {
        return cost.ToString();
    }
}
