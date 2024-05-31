using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerScore = 0;
    public int AIScore = 0;
    [SerializeField] private bool playerScoreUpdated, AiScoreUpdated;
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
    //function that increases the player's score
    public void IncreasePlayerScore(int scoreAmount)
    {
        if (!playerScoreUpdated)
        {
            playerScore += scoreAmount;
            playerScoreUpdated = true;
        }
    }
    //function that increases the AI.'s score
    public void IncreaseAIScore(int scoreAmount) {

        if (!AiScoreUpdated)
        {
            AIScore += scoreAmount;
            AiScoreUpdated = true;
        }
    }
}
