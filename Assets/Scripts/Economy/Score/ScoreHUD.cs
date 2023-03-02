using UnityEngine.UI;
using UnityEngine;

public class ScoreHUD : MonoBehaviour
{
    [field: SerializeField] public TMPro.TMP_Text Text {get; set;}
    [field: SerializeField] public Score score;

    void Start()
    {
    }

    void Update()
    {
        Text.text = score.Score_.ToString();
    }
}
