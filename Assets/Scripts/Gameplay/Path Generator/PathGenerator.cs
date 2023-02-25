using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{   
    public List<GameObject> _offPath;
    private Transform _player;
    [field: SerializeField] public bool RandomSize;
    [field: SerializeField] public int Size {get; set;}
    [field: SerializeField] public int CurrentSize {get; set;}
    [field: SerializeField] public int SaveRange {get; set;}
    [SerializeField] public GameObject? LastSpawn;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if (RandomSize)
        {
            Size = Random.Range (1, 10);
        }
    }

    private void Update()
    {
        if (!RandomSize)
        {
            LastSpawn = (transform.childCount > 0) ? transform.GetChild(CurrentSize).gameObject : null;
            LastSpawn.gameObject.SetActive (true);

            if (CurrentSize >= Size && Vector2.Distance(LastSpawn.transform.position, _player.position) <= 2)
            {
                // Put paths on the list
                for (int i=0; i < (transform.childCount); i ++)
                {
                    _offPath.Add(transform.GetChild(i).gameObject);
                }

                // Delete old path and allow to create new ones
                if (Vector2.Distance(LastSpawn.transform.position, _player.position) <= 1)
                {
                    for (int i=0; i < (transform.childCount-SaveRange); i ++)
                    {
                        Destroy (transform.GetChild(i).gameObject);
                    }

                    CurrentSize = 0;
                    _offPath.Clear();

                    if (LastSpawn != null)
                    {
                        LastSpawn.transform.GetChild(0).GetComponent<PathSpawn>().InstatiatePath ();
                    }
                }
            }
        }
    }
}
