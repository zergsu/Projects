using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    [SerializeField] Sprite DoorOpen;
    [SerializeField] Sprite DoorClose;
    [SerializeField] GameObject exitBond;
    public bool canBeOpened;
    public bool finishedLevel;
    public bool canPress;

    public GameManager gameManager;

    SpriteRenderer sprite;

    public KeyCode interactKey;

    void Start()
    {
        canBeOpened = true;
        canPress = false;
        finishedLevel = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (canBeOpened && canPress)
        {
            if (Input.GetKeyDown(interactKey))
            {
                sprite.sprite = DoorOpen;
                exitBond.SetActive(false);
                finishedLevel = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            canBeOpened = true;
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(finishedLevel)
		{
            canPress = false;
            canBeOpened = false;
            gameManager.MoveToNextScene();
        }
    }

}
