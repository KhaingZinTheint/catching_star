using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript3 : MonoBehaviour
{
    Main3 main;
    Transform tr;

  AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("generator3").GetComponent<Main3>();
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
        if (collision.gameObject.name == "basket3")
        {
            audioManager.PlaySFX(audioManager.star);
            Destroy(this.gameObject);
            main.ScoreAdd();
        }
    }
}
