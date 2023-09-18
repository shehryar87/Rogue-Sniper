using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    #region Singleton
    public static MainMenuUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    private void Start()
    {
        AdmobManager.instance.HideBanner(BannerAD.SmallBanner);
        AudioManager.instance.Play("Main");
        
    }
    public GameObject mainMenu, levelSelection, gunSelection, settings;
    public void CampaignMode()
    {
        OpenPanel(Panel.LevelSelection);

    }

    public void EndlessMode()
    {
        OpenPanel(Panel.MainMenu);
    }

    public void Settings()
    {
        OpenPanel(Panel.Settings);
    }

    public void SelectLevel(int level)
    {
        PlayerPrefs.SetInt("LevelNumber", level);
        OpenPanel(Panel.GunSelection);
        AdmobManager.instance.ShowInterstitialAd();
    }

    public void SelecteGun(int gun)
    {
        //OpenPanel(Panel.MainMenu);
        SceneLoader.instance.LoadNextScene(Scenes.Gameplay);
    }
    public void Back(int panel)
    {
        switch (panel)
        {
            case 0:
                OpenPanel(Panel.MainMenu);
                break;
            case 1:
                OpenPanel(Panel.LevelSelection);
                break;
            default:
                OpenPanel(Panel.MainMenu);
                break;
        }
    }

    public void OpenPanel(Panel panel)
    {
        AudioManager.instance.Play("Click");
        switch (panel)
        {
            case Panel.MainMenu:
                mainMenu.SetActive(true);
                levelSelection.SetActive(false);
                gunSelection.SetActive(false);
                settings.SetActive(false);
                AdmobManager.instance.HideBanner(BannerAD.SmallBanner);
                break;
            case Panel.LevelSelection:
                mainMenu.SetActive(false);
                levelSelection.SetActive(true);
                gunSelection.SetActive(false);
                settings.SetActive(false);
                AdmobManager.instance.ShowBanner(BannerAD.SmallBanner);
                break;
            case Panel.GunSelection:
                mainMenu.SetActive(false);
                levelSelection.SetActive(false);
                gunSelection.SetActive(true);
                settings.SetActive(false);
                AdmobManager.instance.ShowBanner(BannerAD.SmallBanner);
                break;
            case Panel.Settings:
                mainMenu.SetActive(false);
                levelSelection.SetActive(false);
                gunSelection.SetActive(false);
                settings.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
public enum Panel
{
    MainMenu,
    LevelSelection,
    GunSelection,
    Settings
}