using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{

    public bool canDialog;
    public GameObject catQuestiomark;
    public bool firstTime;
    public Dialog dialog;
    public PlayerMovement player;

    private void Start()
    {
        canDialog = false;
        firstTime = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Cat"))// checks of the collision that triggered is tagged with "Cat"
        {
            if(firstTime)
			{
                dialog.ActiveDialog();
                firstTime = false;
			}
            else
			{
                canDialog = true;
                catQuestiomark.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Cat"))
        {
            canDialog = false;
            catQuestiomark.SetActive(false);
        }
    }

}
