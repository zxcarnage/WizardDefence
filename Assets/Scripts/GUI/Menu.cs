using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        if(_player)
            _player.IsPaused = true;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        if(_player)
            _player.IsPaused = false;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
