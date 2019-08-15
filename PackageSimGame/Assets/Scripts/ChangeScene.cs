/*ChangeScene
 * 
 * Handler for loading persistent components and transitioning to parameter scene
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Load Scenes that contain reset button and total moves counter
    void Start()
    {
            SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);
            SceneManager.LoadScene("Moves", LoadSceneMode.Additive);
    }
    
    //Marks delivery location objects to not be destroyed on scene transition, and transitions to parameter scene 
    public void ChangeToScene (string SceneToChangeTo)
    {
        GameObject housePathing = GameObject.FindGameObjectWithTag("House_Pathing_Object");
        DontDestroyOnLoad(housePathing);
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single); 

    }
}
