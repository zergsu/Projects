using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool canMenu;
    public GameObject Menu, Dark, Light;
    public Dialog player;


    void Start()
    {
        canMenu = true;
    }
    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && canMenu)
        {
                Menu.SetActive(true);
                canMenu = false;
                player.inDialog = true; // freeze player on menu
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !canMenu)
        {
            Menu.SetActive(false);
            canMenu = true;
            player.inDialog = false;
        }
       if(Input.GetKeyDown(KeyCode.LeftShift))
		{
            if(Light.activeSelf)
			{
                Dark.SetActive(true);
                Light.SetActive(false);
            }
			else
			{
                Dark.SetActive(false);
                Light.SetActive(true);
            }
		}
    }


    public void MoveToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMenu()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(0);
    }
}
