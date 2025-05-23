using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "Level_Tutorial"; 

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
