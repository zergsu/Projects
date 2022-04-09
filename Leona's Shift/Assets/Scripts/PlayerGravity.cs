using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{

    public GameObject world;
    public PlayerMovement player;

    public bool canPress;
    public int rotateAmount = 0;


    public KeyCode interactKey;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && canPress)
        {
            world.transform.Rotate(0, 0, -90);
            canPress = false;
            transform.Rotate(0, 0, 90);
            rotateAmount++;
            if(rotateAmount == 4)
            {
                rotateAmount = 0;
            }
        }

        if(player.died)
		{
			for (int i = 0; i < 4 - rotateAmount; i++)
			{
                world.transform.Rotate(0, 0, -90);
                transform.Rotate(0, 0, 90);
            }
            rotateAmount = 0;
            player.Respawn();
            player.died = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //if the player near the button he can press "F" to interact and rotate the map
    {
        if (other.gameObject.tag.Contains("GRAV_LEVER"))
        {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // if the player left a button that he already pressed he can press again
    {
        canPress = false;
    }
}
