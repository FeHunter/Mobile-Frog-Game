using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public PlayerFrog player;

    private void Update()
    {
        transform.position = player.point;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plant")
        {
            player.GoTo = other.transform;
        }    
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Plant")
        {
            player.GoTo = null;
        }    
    }
}
