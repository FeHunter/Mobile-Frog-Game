using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{
    private PathGenerator _pathGenerator;
    private Transform[] _path {get; set;}
    [field: SerializeField] public bool VariantPath {get; set;}
    [field: SerializeField] public Transform Plant {get; set;}

    void Start()
    {
        GetPathGenerator ();
        GetSpawnPoints ();

        InstatiatePath ();
    }

    void GetPathGenerator ()
    {
        if (!VariantPath)
        {
            _pathGenerator = GameObject.FindGameObjectWithTag("Path").GetComponent<PathGenerator>();
        }
        else 
        {
            _pathGenerator = transform.parent.GetComponent<PathGenerator>();
        }
    }

    void GetSpawnPoints ()
    {
        // Get paths
        _path = new Transform[transform.childCount];
        for (int i=0; i < transform.childCount; i++)
        {
            _path[i] = transform.GetChild(i).transform;
        }
    }

    void InstatiatePath ()
    {
        if (!VariantPath)
        {
            if (_pathGenerator.CurrentSize < _pathGenerator.Size)
            {
                Instantiate (Plant.gameObject, _path[Random.Range(0, _path.Length)].position, Quaternion.identity, _pathGenerator.transform);
                _pathGenerator.CurrentSize ++;
            }
        }
        else 
        {
            for (int i=0; i < _pathGenerator.Size; i ++)
            {
                Instantiate (Plant.gameObject, _path[Random.Range(0, _path.Length)].position, Quaternion.identity, _pathGenerator.transform);
            }
        }
    }
}
