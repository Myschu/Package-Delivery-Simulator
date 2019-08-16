/*LoadArrows
 * 
 * Used to load arrow buttons and initialize delivery areas, as well as some persistent scenes (reset)
 * Changes position of text box containing package list to fit particular scene
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArrows : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //Load reset and arrow buttons
        SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);
        SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);

        //Initialize delivery logic
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("House");
        foreach (GameObject houses in triggers)
        {
            houses.GetComponent<House_Trigger>().Awake();
        }

        //Text box position change
        GameObject text = GameObject.FindGameObjectWithTag("House_Pathing_Text");
        text.transform.position = new Vector2(980,280);
    }

}
