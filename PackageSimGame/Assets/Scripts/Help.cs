/*Help
 * 
 * Handler for the transitions to and from help screen
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    public void HelpMe()
    {
        SceneManager.LoadScene("Help", LoadSceneMode.Single);
    }
    public void NoHelp()
    {
        SceneManager.LoadScene("Today", LoadSceneMode.Single);
    }
}
