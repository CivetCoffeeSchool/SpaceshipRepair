using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderClimb : MonoBehaviour
{
    private bool c = false;
    public bool climbUp = false;
    private void Start()
    {
        c = false;
        climbUp = false;
    }
    private void Update()
    {
        if(Input.GetButtonDown("Vertical") && c)
        {
            climbUp = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Ladder"))
        {
            c = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            c = false;
            climbUp = false;
        }
    }
}
