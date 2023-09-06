using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnLevelComplete();
    public delegate void OnLevelFailed();
    public event OnLevelComplete OnLevelCompleteEvent;
    public event OnLevelFailed OnLevelFailedEvent;
    public bool isLevelComplete;
    public bool isLevelFailed;
    #region Singleton
    public static EventManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int totalEnemies;

    public void InitializeEnemy()
    {
        totalEnemies++;
    }
    public void EnemyDeath()
    {
        totalEnemies--;
        if (totalEnemies <= 0)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        isLevelComplete = true;
        Invoke(nameof(DelayLevelComplete), 2f);

    }

    private void DelayLevelComplete()
    {
        OnLevelCompleteEvent?.Invoke();
    }

    public void LevelFailed()
    {
        Invoke(nameof(DelayLevelFail), 2f);
    }
    private void DelayLevelFail()
    {

        if (isLevelComplete) return;
        if (!isLevelFailed)
        {
            isLevelFailed = true;
            OnLevelFailedEvent?.Invoke();

        }
    }
}
