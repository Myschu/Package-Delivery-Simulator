/*Reset
 * 
 * Logic for resetting game to intial state, as convenience for testing without having to restart entire project
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    //Reset to intial singleton values, clear package list, and destroy all persistent instances of text
    public void ResetGame()
    {

        DayCount.Instance.Day = 1;
        Money.Instance.money = 100;
        Moves.Instance.moves = 0;

        PackageList.packages.Clear();

        Object.Destroy(GameObject.FindGameObjectWithTag("House_Pathing_Object"));
        
        SceneManager.LoadScene("Today");
        
    }
}

