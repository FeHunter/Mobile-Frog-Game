using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [field: SerializeField] public int CurrentLevel {get; set;}
    public PathGenerator Path;
    public GameObject WinPanel;

    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            CurrentLevel = PlayerPrefs.GetInt ("CurrentLevel");
        }else
        {
            CurrentLevel = 1;
        }

        Path.Size = GetLevelSize ();
    }

    void Update()
    {
        if (Path.EndGame)
        {
            WinPanel.SetActive (true);
            Invoke ("ReloadLevel", 3);
        }
    }

    int GetLevelSize ()
    {
        if (Path.Size < 30)
        {
            return CurrentLevel * 2;
        }
        else
        {
            return 30;
        }
    }

    void ReloadLevel ()
    {
        SceneManager.LoadSceneAsync (SceneManager.GetActiveScene().name);
    }
}
