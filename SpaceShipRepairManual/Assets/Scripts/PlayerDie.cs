using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    //Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        //deathSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();
        //anim.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        SceneLoader.Load(SceneLoader.Scene.DeathScene);
    }
}
