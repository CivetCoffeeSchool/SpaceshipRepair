using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeachbubbleApeard : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject SpeachBubbleTrigger;
    [SerializeField] private GameObject SpeachBubbleText;
    private float spaceXDifference, spaceYDifference;
    // Start is called before the first frame update
    void Start()
    {
        SpeachBubbleText.gameObject.SetActive(false);
    }


    void Update()
    {
        spaceXDifference = Mathf.Abs(Player.transform.position.x -SpeachBubbleTrigger.transform.position.x);
        spaceYDifference = Mathf.Abs(Player.transform.position.y -SpeachBubbleTrigger.transform.position.y);
        if(Mathf.Abs(spaceXDifference + spaceYDifference) < 7)
        {
            SpeachBubbleText.gameObject.SetActive(true);
        }
        else
        {
            SpeachBubbleText.gameObject.SetActive(false);
        }
    }
}
