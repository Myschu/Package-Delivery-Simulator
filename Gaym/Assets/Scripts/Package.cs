using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package
{

    static string[] types = { "mail", "package", "heavy" };
    static string[] conditions = { "none", "signature", "fragile" };

    private string type;
    private string condition;
    private GameObject destination;
    public void Start()
    {
        type = types[Random.Range(0, 3)];
        condition = conditions[Random.Range(0, 3)];
        //destination = 
    }

    public string get_type()
    {
        return type;
    }
    public string get_condition()
    {
        return condition;
    }
}
