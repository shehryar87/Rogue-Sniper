using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #region Event Subscribe
    private void OnEnable()
    {
        EventManager.Instance.OnLevelCompleteEvent += LevelComplete;
        EventManager.Instance.OnLevelFailedEvent += LevelFailed;
    }


    private void OnDisable()
    {
        EventManager.Instance.OnLevelCompleteEvent -= LevelComplete;
        EventManager.Instance.OnLevelFailedEvent -= LevelFailed;
    }
    #endregion

    public GameObject player;
    private void Start()
    {
        StartLevel();
    }
    private void StartLevel()
    {
        Level level = MainManager.Instance.levelHolder.levels[MainManager.Instance.GetLevel()];
        Instantiate(level, level.spwanPosition, Quaternion.identity);
        AudioManager.instance.Stop("Main");
        AudioManager.instance.Play("Forest");
    }

    private void LevelComplete()
    {
        var guns = player.GetComponent<GunHanddle>().Guns;
        foreach (var gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void LevelFailed()
    {

    }
    public void NextLevel()
    {
        MainManager.Instance.IncreaseLevel();
        SceneLoader.instance.LoadNextScene(Scenes.Gameplay);
    }
    public void RestartLevel()
    {
        SceneLoader.instance.LoadNextScene(Scenes.Gameplay);

    }

}
