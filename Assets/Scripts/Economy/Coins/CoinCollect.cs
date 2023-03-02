using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    private Coins _coins;
    public ParticleSystem VFXIdle, VFXCollected;
    public AudioSource SFCollect;

    void Start()
    {
        _coins = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<Coins>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_coins != null)
            {
                _coins.coins ++;
                SFCollect.Play ();
                VFXIdle.gameObject.SetActive (false);
                VFXCollected.Play ();
                Invoke ("Off", 1.1f);
            }
            else {
                Start ();
            }
        }    
    }

    void Off ()
    {
        gameObject.SetActive (false);
    }
}
