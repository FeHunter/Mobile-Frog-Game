using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    private PathGenerator _pathGenerator;
    private int _variantPath;
    [field: SerializeField] public GameObject SmallGroup {get; set;}
    [field: SerializeField] public GameObject BigGroup {get; set;}

    void Start()
    {
        _pathGenerator = this.transform.parent.GetComponent<PathGenerator>();

        _variantPath = Random.Range(0, 2);
        if (_variantPath == 1)
        {
            SmallGroup.SetActive (true);
        }
        else
        {
            BigGroup.SetActive (true);
        }
    }

    void Update()
    {
        if (_pathGenerator.LastSpawn == this.transform.parent)
        {
            Debug.Log ("Is the last" + this.transform.parent.name);
            // InstatiatePath ();
        }    
    }
}
