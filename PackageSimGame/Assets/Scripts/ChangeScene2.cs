using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*ChangeScene2 
 * 
 * Manages changing scenes from the "End_Day_Scene" to the next "Today" Scene
 * and updates/stores information about any transaction made
 * 
 */

public class ChangeScene2 : MonoBehaviour
{
    void Start() //Additively stack UI onto next scene along with the scene itself
    {
        GameObject text = GameObject.FindGameObjectWithTag("House_Pathing_Object");

        Object.Destroy(text);
        SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);

        SceneManager.LoadScene("Moves", LoadSceneMode.Additive);
    }
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        DayCount.Instance.Day += 1;
        Money.Instance.money -= 8;
        Rent.Instance.rent += 3;
        Daily.Instance.daily_expenses += 20;
        // Update Singletons daily to indicate money transactions on Ending Stats

        if (DayCount.Instance.Day % 7 == 0) // Switch to Game Over scene once set time limit has been reached (7 days)
        {
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
        }

        if (Money.Instance.money <= 0) // Switch to Game Over scene once you run out of money
        {
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
        }
        if (Money.Instance.money >= 150) // Switch to Winning scene once you complete the goal of earning set money (
        {
            SceneManager.LoadScene("Winning", LoadSceneMode.Single);
        }
        Debug.Log(DayCount.Instance.Day);
    }
}