using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript3 : MonoBehaviour
{
    Main3 main;
    Transform tr;
    TimerScript3 timerScript;

  AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("generator3").GetComponent<Main3>();
        timerScript = GameObject.Find("timer3").GetComponent<TimerScript3>();
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
        if (collision.gameObject.name == "basket3") // Changed to match StarScript3
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
