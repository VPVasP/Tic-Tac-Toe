using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private Button xButton, oButton;
    public bool isXbutton;
    public bool is0Button;
    public Sprite xIcon;
    public Sprite oIcon;
    //list of the buttons
    public List<GameObject> buttons = new List<GameObject>();
    //list of the player ids
    public List<int> ids = new List<int>();
    //list of the A.I ids
    public List<int> aiIds = new List<int>();
    //flags to check if the player or AI is winning
    public bool isPlayerWinning;
    public bool isAIWinning;
    //flag that checks if its the players turn
    public bool isPlayerTurn = false;
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

    private void Start()
    {
        UIManager.instance.ShowStartUI();
        xButton.onClick.AddListener(XButton);
        oButton.onClick.AddListener(OButton);
        isPlayerTurn = true;
        //set the color A of the buttons to be 0
        foreach (var button in buttons)
        {
            button.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }

    //x button Choice Function
    public void XButton()
    {
        isXbutton = true;
        is0Button = false;
        xButton.interactable = false;
        oButton.interactable = false;
        xButton.gameObject.SetActive(false);
        oButton.gameObject.SetActive(false);
        UIManager.instance.EnableGameView();
    }

    //o button Choice Function
    public void OButton()
    {
        is0Button = true;
        isXbutton = false;
        xButton.interactable = false;
        oButton.interactable = false;
        xButton.gameObject.SetActive(false);
        oButton.gameObject.SetActive(false);
        UIManager.instance.EnableGameView();
    }
    private void Update()
    {

        CheckWinningConditionsPlayer();
        CheckWinningConditionsAI();

        //if no buttons are left
        if (buttons.Count == 0)
        {
            //if the ai or the player is winning then it is a draw
            if(!isAIWinning && !isPlayerWinning)
            {
                //Update the UI,increase score and save the data
                Debug.Log("Draw");
                UIManager.instance.EndGameView();
                UIManager.instance.endText.text = "DRAW";
                GameManager.instance.IncreasePlayerScore(0);
                GameManager.instance.IncreaseAIScore(0);
                UIManager.instance.UpdatePlayerScoreUI();
                UIManager.instance.UpdateAIScoreUI();
                PlayerPrefsManager.instance.SaveData();

                //reload the scene after 5 seconds
                Invoke("ReloadScene", 5f);
            }
        }
    }


    public void AITurn()
    {
        isPlayerTurn = false;

        if (buttons.Count > 0)
        {
            //pick any random buttons from the buttons list 
            int randomIndex = Random.Range(0, buttons.Count);
            GameObject randomButton = buttons[randomIndex];
            ButtonController buttonController = randomButton.GetComponent<ButtonController>();
            Debug.Log("AI Played");
            randomButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //add it to the A.I Lists ID
            aiIds.Add(randomButton.GetComponent<ButtonController>().id);


            if (buttonController != null && buttonController.isFree)
            {
                //if the player choice is x button then make the AI play the O Icon
                if (isXbutton) 
                {
                    buttonController.AIMove(oIcon);
                    isXbutton = true;
                    is0Button = false;
                }
                //if the player choice is O button then make the AI play the X Icon
                else if (is0Button) 
                {
                    buttonController.AIMove(xIcon);
                    is0Button = true;
                    isXbutton = false;
                }
            }
            isPlayerTurn = true;
        }
    }


    //function that checks the winning conditions for the player
    public void CheckWinningConditionsPlayer()
    {
        //list of the possible winning combinations for the player
        List<int[]> winningSequencesPlayer = new List<int[]>
    {
        new int[] { 0, 1, 2 },
        new int[] { 1, 4, 7 },
        new int[] { 7, 4, 1 },
        new int[] { 0, 3, 6 },
        new int[] { 0, 4, 8 },
        new int[] { 2, 5, 8 },
        new int[] { 6, 4, 2},
        new int[] { 8, 4, 0 },
        new int[] {3, 4, 5},
        new int[] {8, 7, 6},
        new int[] {5, 4, 3},
        new int[] {6, 7, 8}
    };

      
        foreach (int[] sequence in winningSequencesPlayer)
        {

            isPlayerWinning = true;
            

            foreach (int id in sequence)
            {
                if (!ids.Contains(id))
                {
                    isPlayerWinning = false;
                    break;
                }
            }

            //if player has won update the UI, Scores and Save the Data
            if (isPlayerWinning)
            {
                Debug.Log("Player Won");
                UIManager.instance.EndGameView();
                UIManager.instance.endText.text = "PLAYER WON";
                GameManager.instance.IncreasePlayerScore(5);
                UIManager.instance.UpdatePlayerScoreUI();
                UIManager.instance.UpdateAIScoreUI();
                GameManager.instance.IncreaseAIScore(0);
                PlayerPrefsManager.instance.SaveData();
                Invoke("ReloadScene", 5f);
                return;
            }
        }
    }

    //function that checks the winning conditions for the player
    public void CheckWinningConditionsAI()
{
        //list of the possible winning combinations for the player
        List<int[]> winningSequencesAI = new List<int[]>
    {
        new int[] { 0, 1, 2 },
        new int[] { 1, 4, 7 },
        new int[] { 7, 4, 1 },
        new int[] { 0, 3, 6 },
        new int[] { 0, 4, 8 },
        new int[] { 2, 5, 8 },
        new int[] { 6, 4, 2},
        new int[] { 8, 4, 0 },
        new int[] {3, 4, 5},
        new int[] {8, 7, 6},
        new int[] {5, 4, 3},
        new int[] {6, 7, 8}
    };


    foreach (int[] sequence in winningSequencesAI)
    {

        isAIWinning = true;

        foreach (int id in sequence)
        {
         
            if (!aiIds.Contains(id))
            {
                isAIWinning = false;
                break;
            }
        }

        //if ai has won update the UI, Scores and Save the Data
        if (isAIWinning)
        {
                Debug.Log("AI Won");
                UIManager.instance.EndGameView();
                UIManager.instance.endText.text = "A.I WON";
                GameManager.instance.IncreasePlayerScore(0);
                UIManager.instance.UpdateAIScoreUI();
                UIManager.instance.UpdatePlayerScoreUI();
                GameManager.instance.IncreaseAIScore(5);
                isAIWinning = false;
                PlayerPrefsManager.instance.SaveData();
                Invoke("ReloadScene", 5f);
                return;
        }
      }
   }
    //Reload the Game Scene
    public void ReloadScene()
    {
        SceneManager.LoadScene("TicTacToe");
    }
}