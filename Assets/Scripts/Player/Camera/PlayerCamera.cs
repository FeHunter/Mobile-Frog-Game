using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private PlayerFrog frog;
    private Vector3 velocity = Vector3.zero;
    [field: SerializeField] public float AnimationSpeed {get; set;}
    [field: SerializeField] public float Speed {get; set;}
    [field: SerializeField] public Transform Player {get; set;}

    void Start()
    {
        frog = Player.GetComponent<PlayerFrog>();
    }

    void Update()
    {
        if (frog.Playing)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, Player.position.y+2, transform.position.z), Speed * Time.deltaTime);
        }
        else 
        {
            Vector2 pos = new Vector2 ( Random.Range(-5, 5),  Random.Range(-5, 5) );
            transform.position = Vector3.SmoothDamp (transform.position, new Vector3(pos.x, pos.y, -10), ref velocity, AnimationSpeed*Time.deltaTime);
        }
    }
}
