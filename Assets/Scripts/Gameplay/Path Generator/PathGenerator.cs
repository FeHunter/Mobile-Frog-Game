using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{   
    [field: SerializeField] public bool RandomSize;
    [field: SerializeField] public int Size {get; set;}
    [field: SerializeField] public int CurrentSize {get; set;}

    private void Start()
    {
        if (RandomSize)
        {
            Size = Random.Range (1, 10);
        }
    }
}
