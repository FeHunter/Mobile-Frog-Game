using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFly : MonoBehaviour{

    private int _spawn;
    public PathGenerator Path;
    public GameObject Frog, Fly;

    void Start(){
        
    }

    void Update()
    {
        if (Vector2.Distance(Frog.transform.position, Path.LastSpawn.transform.position) < 10)
        {
            if (_spawn == 0)
            {
                Instantiate (Fly, Path.LastSpawn.transform.position, Quaternion.identity, transform);
                _spawn = 1;
            }
        }else
        {
            _spawn = 0;
        }
    }
}
