using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript4 : MonoBehaviour
{
    Main4 main;
    Transform tr;
    TimerScript4 timerScript;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("generator4").GetComponent<Main4>();
        timerScript = GameObject.Find("timer4").GetComponent<TimerScript4>();
    }

    void FixedUpdate()
    {
        if (main.IsGameOver()) return;

        // Move downwards
        tr.position -= new Vector3(0f, 0.12f, 0f);
        if (tr.position.y < -7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "basket4") // Changed to match StarScript3
        {
             audioManager.PlaySFX(audioManager.bomb);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            main.GameOver = true;

            if (timerScript != null)
            {
                timerScript.OnPlayerDeath();
            }
        }
    }
}
