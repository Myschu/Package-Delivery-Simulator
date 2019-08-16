using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script for the help/tutorial button 

public class Help : MonoBehaviour
{
    public void HelpMe() //Moves to tutorial scene
    {
        SceneManager.LoadScene("Help", LoadSceneMode.Single);
    }
    public void NoHelp() //Moves back to original scene
    {
        SceneManager.LoadScene("Today", LoadSceneMode.Single);
    }
}
