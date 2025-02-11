using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript2 : MonoBehaviour
{
    Main2 main;
    Transform tr;

  AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("generator2").GetComponent<Main2>();
    }

    void FixedUpdate()
    {
        if (main.IsGameOver()) return;  // Stop falling if the game is over
        
        tr.position -= new Vector3(0f, 0.12f, 0f);
        if (tr.position.y < -7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "basket2")
        { audioManager.PlaySFX(audioManager.star);
            Destroy(this.gameObject);
            main.ScoreAdd();
        }
    }
}