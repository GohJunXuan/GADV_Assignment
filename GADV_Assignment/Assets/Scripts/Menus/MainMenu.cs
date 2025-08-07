using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
