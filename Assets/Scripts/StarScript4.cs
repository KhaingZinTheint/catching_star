using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript4 : MonoBehaviour
{
    Main4 main;
    Transform tr;

  AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("generator4").GetComponent<Main4>();
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
        if (collision.gameObject.name == "basket4")
        {
            audioManager.PlaySFX(audioManager.star);
            Destroy(this.gameObject);
            main.ScoreAdd();
        }
    }
}
