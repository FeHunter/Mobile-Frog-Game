using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private LevelController Level;
    private PathGenerator pathGenerator;

    void Start ()
    {
        Level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        pathGenerator = GameObject.FindGameObjectWithTag("Path").GetComponent<PathGenerator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Level.CurrentLevel ++;
            PlayerPrefs.SetInt ("CurrentLevel", Level.CurrentLevel);
            pathGenerator.EndGame = true;

            // Visual
            GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).GetComponent<ParticleSystem>().Play ();
        }    
    }
}
