using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeverOpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject leverText;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private Sprite spriteLever;
    [SerializeField] private Sprite spriteDoor;

    private bool leverFlicked = false;
    private bool PlayerNear = false;


    private void Start()
    {
        leverText.gameObject.SetActive(false);
        leverFlicked = false;
    }
    private void Update()
    {
        if (PlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FlickLever();
                leverText.gameObject.SetActive(false);
                leverFlicked = true;
                PlayerNear = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!leverFlicked)
        {
            if (collision.gameObject.tag.Equals("Player")&&!leverFlicked)
            {
                PlayerNear = true;
                leverText.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            leverText.gameObject.SetActive(false);
            PlayerNear = false;
        }
    }
    private void FlickLever()
    {
        Lever.GetComponent<SpriteRenderer>().sprite = spriteLever;
        Door.GetComponent<SpriteRenderer>().sprite = spriteDoor;
        Door.GetComponent<BoxCollider2D>().enabled = false;
        Door.GetComponent<EdgeCollider2D>().enabled = true;

    }


}
