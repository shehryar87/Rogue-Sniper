using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject levelCompleteCanvas, levelFailCanvas, levelPauseCanvas;
    private void Start()
    {
        EventManager.Instance.OnLevelCompleteEvent += OnLevelComplete;
        EventManager.Instance.OnLevelFailedEvent += OnLevelFailed;
    }



    private void OnDisable()
    {
        EventManager.Instance.OnLevelCompleteEvent -= OnLevelComplete;
        EventManager.Instance.OnLevelFailedEvent -= OnLevelFailed;
    }

    private void OnLevelComplete()
    {
        levelCompleteCanvas.SetActive(true);
    }
    private void OnLevelFailed()
    {
        levelFailCanvas.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameManager.Instance.player.GetComponent<GunHanddle>().CurrentGun.SetActive(false);
        levelPauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.player.GetComponent<GunHanddle>().CurrentGun.SetActive(true);
        levelPauseCanvas.SetActive(false);

    }
    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
    public void Home()
    {
        SceneLoader.instance.LoadNextScene(Scenes.MainMenu);
    }
    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }
}
