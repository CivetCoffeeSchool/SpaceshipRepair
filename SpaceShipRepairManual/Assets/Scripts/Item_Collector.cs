using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Collector : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    private GameObject Item;
    private bool pickUpAllowed;
    public bool holdsItem { get; set; }

    private void Start()
    {

        holdsItem = false;
        pickUpText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E) && !holdsItem)
        {
            PickUp();
            holdsItem = true;
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Item"))
        {
            Item = collision.gameObject;
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Item"))
        {
            Item = null;
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
    private void PickUp()
    {
        Destroy(Item);
    }
}
