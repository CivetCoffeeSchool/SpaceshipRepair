using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Handler : MonoBehaviour
{
    public Item_Collector collector;
    public bool holdsItem;


    [SerializeField] private Text DepositText;
    private GameObject Item;
    private bool DepositAllowed;


    private void Start()
    {
        holdsItem = collector.holdsItem;
        DepositText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (DepositAllowed && Input.GetKeyDown(KeyCode.F) && holdsItem)
        {
            Deposit();
            holdsItem = true;
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Craft"))
        {
            Item = collision.gameObject;
            DepositText.gameObject.SetActive(true);
            DepositAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Craft"))
        {
            Item = null;
            DepositText.gameObject.SetActive(false);
            DepositAllowed = false;
        }
    }
    private void Deposit()
    {
        holdsItem = false;
    }
}
