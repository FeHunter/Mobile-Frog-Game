using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CointsHUD : MonoBehaviour
{
    [field: SerializeField] public TMPro.TMP_Text Txt {get; set;}
    [field: SerializeField] public Coins coins {get; set;} 

    void Start()
    {
        
    }

    void Update()
    {
        Txt.text = coins.coins.ToString();
    }
}
