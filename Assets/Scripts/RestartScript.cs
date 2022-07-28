using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    private void Awake()
    {
        HunterScript.ONDie += RestartGame;
        Shooting.runOutOfAmmo += RestartGame;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        HunterScript.ONDie -= RestartGame;
    }
}
