using UnityEngine;

public class MainManager : MonoBehaviour
{
    #region Singleton
    public static MainManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion 


    public LevelHolder levelHolder;

    
    public void IncreaseLevel()
    {
        if (PlayerPrefs.GetInt("LevelNumber") < levelHolder.levels.Length-1)
            PlayerPrefs.SetInt("LevelNumber", (PlayerPrefs.GetInt("LevelNumber") + 1));
        else
            PlayerPrefs.SetInt("LevelNumber", 0);
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("LevelNumber");
    }
}
