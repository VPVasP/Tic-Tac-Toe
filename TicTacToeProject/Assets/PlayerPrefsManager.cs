using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{

    public static PlayerPrefsManager instance;
    private string PlayerScoreKey = "PlayerScore";
    private string AIScoreKey = "AIScore";
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt(PlayerScoreKey, GameManager.instance.playerScore);
        PlayerPrefs.SetInt(AIScoreKey, GameManager.instance.AIScore);
        PlayerPrefs.Save();
    }
 
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(PlayerScoreKey))
        {
            GameManager.instance.playerScore = PlayerPrefs.GetInt(PlayerScoreKey);
        }

        if (PlayerPrefs.HasKey(AIScoreKey))
        {
            GameManager.instance.AIScore = PlayerPrefs.GetInt(AIScoreKey);
        }
    }
    public void EraseData()
    {
        PlayerPrefs.DeleteAll();
    }
}
