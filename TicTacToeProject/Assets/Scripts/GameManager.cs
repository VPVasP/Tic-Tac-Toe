using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerScore;
    public int AIScore;
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
    public void IncreasePlayerScore(int scoreAmount)
    {
        playerScore += scoreAmount;
    }
    public void IncreaseAIScore(int scoreAmount)
    {
        AIScore += scoreAmount;
    }
}
