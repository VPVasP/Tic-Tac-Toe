using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{

    public static PlayerPrefsManager instance;

    //playerPrefs keys
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

    //load the data at the beggining of the game
    private void Start()
    {
        LoadData();
    }

    //save the player score and the Ai Score Keys 
    public void SaveData()
    {
        PlayerPrefs.SetInt(PlayerScoreKey, GameManager.instance.playerScore);
        PlayerPrefs.SetInt(AIScoreKey, GameManager.instance.AIScore);
        PlayerPrefs.Save();
    }
 

    //if the saved data exists then load the data
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
    //delete all the playerprefs data
    public void EraseData()
    {
        PlayerPrefs.DeleteAll();
    }
}
