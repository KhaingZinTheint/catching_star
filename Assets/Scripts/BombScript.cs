using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Main main;
    Transform tr;
    TimerScript timerScript;
     
     AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("generator").GetComponent<Main>();
        timerScript = GameObject.Find("Timer").GetComponent<TimerScript>();
    }

    void FixedUpdate()
    {
        if (main.IsGameOver()) return;  // Stop falling if the game is over

        tr.position -= new Vector3(0f, 0.12f, 0f);
        if (tr.position.y < -7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "basket")
        {
             audioManager.PlaySFX(audioManager.bomb);
            Destroy(this.gameObject); // Destroy the bomb
            Destroy(collision.gameObject); // Destroy the player or basket
            main.GameOver = true;

            if (timerScript != null)
            {
                timerScript.OnPlayerDeath();
            }
        }
    }
}