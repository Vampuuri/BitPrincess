using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    public void LoadScene(string MainGameScene)
    {
        SceneManager.LoadScene(MainGameScene);
    }
}
