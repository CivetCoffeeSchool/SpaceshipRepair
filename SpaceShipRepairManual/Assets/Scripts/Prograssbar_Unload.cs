using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prograssbar_Unload : MonoBehaviour
{
    public int maximun;
    public int curent;
    [SerializeField]public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GerCurrentFill()
    {
        float fillAmount = (float)curent / (float)maximun;
    }
}
