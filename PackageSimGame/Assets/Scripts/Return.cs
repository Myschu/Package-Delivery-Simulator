using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public GameObject button;
   
    public void OnClick(string SceneName)
    {
        SceneManager.UnloadSceneAsync(SceneName);
        //ArrowHandler point = GameObject.FindGameObjectWithTag("ArrowHandler").GetComponent<ArrowHandler>();
        SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);
        //point.setScene(true); 
        //button = GameObject.FindGameObjectWithTag("To_Map_Button");
        //button.transform.position = new Vector2(-500, 0);


    }

    public void endEarly()
    {
        Clock clock = Object.FindObjectOfType<Clock>();

        int time = (int) clock.hour;

        int extraHours = 22 - time;
        Money.Instance.money += (int) (extraHours * .5);


        SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Single);
    }

    public void loadScene(string SceneName)
    {
        //ArrowHandler point = GameObject.FindGameObjectWithTag("ArrowHandler").GetComponent<ArrowHandler>();
        //Debug.Log("Clicked on : " + SceneName);
        //GameObject button = GameObject.FindGameObjectWithTag("To_Map_Button");
        //button.SetActive(false);
        //button.transform.position = new Vector2(500, 0);
        SceneManager.UnloadSceneAsync("Choose_Direction");
        //point.setScene(false);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);

    }
}
