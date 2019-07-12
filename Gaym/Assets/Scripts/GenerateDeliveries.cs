using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDeliveries : MonoBehaviour
{
    public List<Package> packages = new List<Package>();

    public void Start()
    {
        Package package = new Package();
        package.Start();
        if (!packages.Contains(package))
        {
            packages.Add(package);
        }
    }
}