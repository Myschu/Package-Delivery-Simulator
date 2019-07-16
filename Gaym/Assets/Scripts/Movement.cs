using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject arrow;
    public GameObject[] Buttons;
    public Rigidbody2D rb;
    private int index;
    int size_of_buttons;
    private bool moving = false;
    private bool load_arrows = false;
    //public Transform truck = GameObject.FindGameObjectWithTag("Truck").GetComponent<Transform>();
    void Start()
    {
        index = 0;
        //SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);
        //Map = GameObject.FindGameObjectWithTag("Map");
        //Map map = Map.GetComponent<Map>();
        Buttons = GameObject.FindGameObjectsWithTag("MapLocationalNode");
        size_of_buttons = Buttons.Length;
        rb = GameObject.FindGameObjectWithTag("Truck").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("l"))
        {
            rb.velocity = Vector2.zero;
        }
        else if (rb.position != new Vector2(Buttons[index].transform.position.x, Buttons[index].transform.position.y))
        {
            rb.velocity = new Vector2((Buttons[index].transform.position.x - rb.position.x) * 1, (Buttons[index].transform.position.y - rb.position.y) * 1);
            Debug.Log("RigidBodyx " + rb.position.x + " RigidBodyy " + rb.position.y + " Destinationx " + Buttons[index].transform.position.x + " Destinationy " + Buttons[index].transform.position.y);
        }
        if (Input.GetKeyDown("k"))
        //clock.hour == 10)

        {
            enabled = false;
            SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Additive);
        }
        //rb.position = Vector2.MoveTowards(new Vector2(rb.position.x, rb.position.y), new Vector2(Buttons[index].transform.position.x, Buttons[index].transform.position.y), 20 * Time.deltaTime);
    }

    public void Move_the_Truck()
    {
        //Map map = Map.GetComponent<Map>();
        if (arrow.name == "Down Arrow")
        {
            if (index >= 3 && index < size_of_buttons)
            {
                index -= 3;
            }
            SceneManager.UnloadSceneAsync("Choose_Direction");
        }
        else if (arrow.name == "Up Arrow")
        {
            if (index >= 0 && index < size_of_buttons - 3)
            {
                index += 3;
            }
            SceneManager.UnloadSceneAsync("Choose_Direction");
            Debug.Log(index);
            //rb.MovePosition(Vector2.MoveTowards(new Vector2(rb.position.x, rb.position.y), new Vector2(Buttons[index].transform.position.x, Buttons[index].transform.position.y), 200 * Time.deltaTime));
        }
        else if (arrow.name == "Left Arrow")
        {
            if (index >= 1 && index % 3 != 0)
            {
                index -= 1;
            }
            SceneManager.UnloadSceneAsync("Choose_Direction");
            //rb.MovePosition(Vector2.MoveTowards(new Vector2(rb.position.x, rb.position.y), new Vector2(Buttons[index].transform.position.x, Buttons[index].transform.position.y), 200 * Time.deltaTime));
        }
        else if (arrow.name == "Right Arrow")
        {
            if (index >= 0 && index % 3 != 2)
            {
                index += 1;
            }
            SceneManager.UnloadSceneAsync("Choose_Direction");
            //rb.MovePosition(Vector2.MoveTowards(new Vector2(rb.position.x, rb.position.y), new Vector2(Buttons[index].transform.position.x, Buttons[index].transform.position.y), 200 * Time.deltaTime));

        }
    }
}


/*
private void FixedUpdate()
{
    if (Input.GetMouseButtonDown(0) && !moving)
    {
        SceneManager.UnloadSceneAsync("Choose_Direction");
        Start();
    }
    if (Input.GetKeyDown("k"))
    //clock.hour == 10)

    {
        enabled = false;
        SceneManager.LoadScene("End_Day_Scene", LoadSceneMode.Additive);
    }
    rb.MovePosition(new Vector2(Buttons[index].transform.position.x, Buttons[index].transform.position.y));
}
*/
