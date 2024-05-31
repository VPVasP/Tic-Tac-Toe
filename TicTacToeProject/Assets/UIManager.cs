using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject gameView;
    [SerializeField] private TextMeshProUGUI chooseLetterText,playerScoreText,aiScoreText;
    public TextMeshProUGUI endText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowStartUI()
    {
        chooseLetterText.gameObject.SetActive(true);
        gameView.SetActive(false);
        endText.gameObject.SetActive(false);
    }
    public void EnableGameView()
    {
        chooseLetterText.gameObject.SetActive(false);
        gameView.SetActive(true);
    }
    public void EndGameView()
    {
        endText.gameObject.SetActive(true);
        gameView.SetActive(false);
    }
    public void UpdatePlayerScoreUI()
    {
        playerScoreText.text = GameManager.instance.playerScore.ToString();
    }
    public void UpdateAIScoreUI()
    {
        aiScoreText.text = GameManager.instance.AIScore.ToString();
    }
}
