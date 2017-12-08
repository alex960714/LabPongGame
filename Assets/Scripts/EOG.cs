using UnityEngine;
using UnityEngine.SceneManagement;

public class EOG : MonoBehaviour {

	public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
