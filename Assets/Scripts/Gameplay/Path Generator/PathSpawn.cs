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

    public void InstatiatePath ()
    {
        if (!VariantPath)
        {
            int _spawnP = Random.Range(0, _path.Length);
            if (_pathGenerator.CurrentSize < _pathGenerator.Size)
            {
                Instantiate (Plant.gameObject, _path[_spawnP].position, Quaternion.identity, _pathGenerator.transform);
                _pathGenerator.CurrentSize ++;
                Destroy (transform.GetChild(_spawnP).gameObject);
                GetSpawnPoints ();
            }
        }
        else 
        {
            int spawn = 0;
            for (int i=0; i < _pathGenerator.Size; i ++)
            {
                int _spawnP = Random.Range(0, _path.Length);
                spawn = Random.Range(0, 2);
                if (spawn == 1)
                {
                    Instantiate (Plant.gameObject, _path[Random.Range(0, _path.Length)].position, Quaternion.identity, _pathGenerator.transform);
                }
            }
        }
    }
}
