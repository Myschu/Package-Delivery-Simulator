/*Return
 * 
 * Poorly named script used as logic to: 
 * 1) switch between looking at map and driving. 
 * 2) end the day early, if player is finished with deliveries before 6pm in game time
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    //Assigned manually in Unity project
    public GameObject button;
   
    //Unloads current scene and reloads driving components
    public void OnClick(string SceneName)
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);
    }
    
    //Unloads driving components (to prevent player from moving while looking at map) and loads map
    public void loadScene(string SceneName)
    {
        SceneManager.UnloadSceneAsync("Choose_Direction");
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }

    //Ends in game day early. Additionally, awards extra money to player based on every half hour earlier than 6pm, rounded down. 
    public void endEarly()
    {
        Clock clock = Object.FindObjectOfType<Clock>();

        int time = (int)clock.hour;

        int extraHours = 22 - time;
        Money.Instance.money += (int)(extraHours * .5);


        SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Single);
    }

}
