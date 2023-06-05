using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrograssbarUnload : MonoBehaviour
{
    public float maximun;
    public float curent;
    [SerializeField]public Image mask;
    [SerializeField] public float speed = 1f;
    public bool refill = false;
    // Start is called before the first frame update
    void Start()
    {
        maximun = 100;
        curent = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (refill)
        {
            curent += Time.deltaTime * speed * 5;
        }
        else
        {
            curent -= Time.deltaTime * speed;
        }
        GetCurrentFill();
        if(curent < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //Player Dies
    }
    private void GetCurrentFill()
    {
        float fillAmount = (float)curent / (float)maximun;
        mask.fillAmount = fillAmount;
    }
    //Get Oxygen level


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Refill") ||collision.gameObject.tag.Equals("Craft"))
        {
            refill = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Refill") || collision.gameObject.tag.Equals("Craft"))
        {
            refill = false;
        }
    }
    //gain Oxygen
}
