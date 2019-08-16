using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton used to keep track of amount of money lost due to daily expenses

public class Daily : Singleton<Daily>
{
    public int daily_expenses = 0;
}
