using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private int _spawn;
    [field: SerializeField] public GameObject item {get; set;}
    [field: SerializeField] public int Range {get; set;}

    void Start()
    {
        _spawn = Random.Range(0, Range);

        if (_spawn == 1)
        {
            item.gameObject.SetActive (true);
        }
    }
}
