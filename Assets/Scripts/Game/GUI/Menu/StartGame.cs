using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public PlayerFrog player;
    public GameObject P_Menu, P_Gameplay;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartTheGame ()
    {
        player.Playing = true;
        P_Menu.SetActive (false);
        P_Gameplay.SetActive (true);
    }

    public void ReloadGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
