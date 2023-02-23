using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    private int _variantPath;
    [field: SerializeField] public GameObject SmallGroup {get; set;}
    [field: SerializeField] public GameObject BigGroup {get; set;}

    void Start()
    {
        _variantPath = Random.Range(0, 3);
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
        
    }
}
