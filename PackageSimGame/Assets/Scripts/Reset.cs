using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void ResetGame()
    {

        DayCount.Instance.Day = 1;
        Money.Instance.money = 100;
            SceneManager.LoadScene("Today");
        
    }
}
