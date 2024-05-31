using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject gameView, eraseDataButton;
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

    // update the start game ui function
    public void ShowStartUI()
    {
        chooseLetterText.gameObject.SetActive(true);
        gameView.SetActive(false);
        endText.gameObject.SetActive(false);
        playerScoreText.gameObject.SetActive(false);
        aiScoreText.gameObject.SetActive(false);
    }
    // enable the game ui function
    public void EnableGameView()
    {
        eraseDataButton.gameObject.SetActive(false);
        chooseLetterText.gameObject.SetActive(false);
        gameView.SetActive(true);
    }
    // enable the end game ui function
    public void EndGameView()
    {
        endText.gameObject.SetActive(true);
        gameView.SetActive(false);
        playerScoreText.gameObject.SetActive(true);
        aiScoreText.gameObject.SetActive(true);
    }

    //update the score ui texts
    public void UpdatePlayerScoreUI()
    {
        playerScoreText.text ="Player Score "+ GameManager.instance.playerScore.ToString();
    }
    //update the AI score ui texts
    public void UpdateAIScoreUI()
    {
        aiScoreText.text = "A.I Score " + GameManager.instance.AIScore.ToString();
    }
}
