/*ChangeScene3
 * 
 * Handler for intially loading persistent components and transitioning to parameter scene
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene3 : MonoBehaviour
{

    //Initial load of reset button and move counter + logic preventing duplicate loads
    void Start()
    {
        bool resetExists = false;
        bool movesExists = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "Reset_Button")
            {
                resetExists = true;
            }
            if (SceneManager.GetSceneAt(i).name == "Moves")
            {
                movesExists = false;
            }
        }
        //Debug.Log(resetExists);
        if (!resetExists)
        {
            SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);
        }
        if (!movesExists)
        {
            SceneManager.LoadScene("Moves", LoadSceneMode.Additive);
        }
    }

    //Loads parameter and auxillary scenes 
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        SceneManager.LoadScene("Houses_Pathing", LoadSceneMode.Additive); 
    }
}
