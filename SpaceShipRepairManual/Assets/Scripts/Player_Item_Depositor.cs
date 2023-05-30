using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Item_Depositor : MonoBehaviour
{
    public Player_Item_Collector collector;
    [SerializeField] private GameObject DepositText;
    private GameObject temp;
    [SerializeField]private GameObject Craft;
    private bool DepositAllowed;

    public Sprite[] CraftSprites = new Sprite[4];

    private void Start()
    {
        collector.holdsItem = collector.holdsItem;
        DepositText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (DepositAllowed && Input.GetKeyDown(KeyCode.F) && collector.holdsItem)
        {
            collector.holdsItem = false;
            Deposit();
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Craft"))
        {
            if(collector.holdsItem)
                DepositText.gameObject.SetActive(true);
            DepositAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Craft"))
        {
            DepositText.gameObject.SetActive(false);
            DepositAllowed = false;
        }
    }
    private void Deposit()
    {
        Craft.GetComponent<SpriteRenderer>().sprite = CraftSprites[collector.ItemCounter]; //Updates Sprite of Craft
        collector.ItemSlots[collector.ItemCounter].GetComponent<Image>().color = Color.green;
        collector.ItemCounter++;
        collector.move.jumpforce = 8;
        collector.move.movespeed = 6;
    }


}
