using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    private void OnEnable()
    {
        _playButton.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
