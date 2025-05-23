using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "Level_Tutorial";
    public string creditsScene = "CreditsScene";

    public void StartGame()
    {
        Debug.Log("Boton Presinado");
        SceneManager.LoadScene(sceneToLoad);
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
