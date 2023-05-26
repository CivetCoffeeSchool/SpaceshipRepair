using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Item_Collector : MonoBehaviour
{
    [SerializeField] private GameObject pickUpText;
    public GameObject Item;
    private GameObject temp;
    private bool pickUpAllowed;
    public bool holdsItem { get; set; }
    //Pickup

    public int ItemCounter = 0;
    private Sprite ItemSprite;
    [SerializeField]public GameObject[] ItemSlots = new GameObject[4];
    //Store

    [SerializeField] public Player_Movement move;
    //Slow

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        Item = new GameObject();
        ItemSprite = GetComponent<Sprite>();
        ItemSlots[0].GetComponent<Image>().color = Color.black;
        ItemSlots[1].GetComponent<Image>().color = Color.black;
        ItemSlots[2].GetComponent<Image>().color = Color.black;
        ItemSlots[3].GetComponent<Image>().color = Color.black;
    }
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E) && !holdsItem)
        {
            Item = temp;
            ItemSprite = Item.GetComponent<SpriteRenderer>().sprite;
            PickUp();
            holdsItem = true;
            move.jumpforce = 7;
            move.movespeed = 5;
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Item"))
        {
            temp = collision.gameObject;
            if(!holdsItem)
                pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Item"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        if (ItemCounter < 5)
        {
            ItemSlots[ItemCounter].GetComponent<Image>().sprite = ItemSprite;
            ItemSlots[ItemCounter].GetComponent<Image>().color = Color.white;
        }
        Destroy(Item);
        Item = null;
        pickUpText.gameObject.SetActive(false);
    }
}
