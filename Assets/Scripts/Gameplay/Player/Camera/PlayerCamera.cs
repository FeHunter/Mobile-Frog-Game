using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [field: SerializeField] public float Speed {get; set;}
    [field: SerializeField] public Transform Player {get; set;}

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, Player.position.y+2, transform.position.z), Speed * Time.deltaTime);
    }
}
