using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArrows : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);
        SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Houses_Pathing", LoadSceneMode.Additive);
        GameObject text = GameObject.FindGameObjectWithTag("House_Pathing_Text");

        GameObject[] triggers = GameObject.FindGameObjectsWithTag("House");

        foreach (GameObject houses in triggers)
        {
            houses.GetComponent<House_Trigger>().Awake();
        }

        text.transform.position = new Vector2(980,280);
    }

}
