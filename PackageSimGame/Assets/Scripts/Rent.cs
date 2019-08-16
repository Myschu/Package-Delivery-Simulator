using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton used to keep track of amount of money lost due to rent 

public class Rent : Singleton<Rent>
{
    public int rent = 0;
}
