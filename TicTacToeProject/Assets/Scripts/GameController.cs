using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private Button xButton, oButton;
    public bool isXbutton;
    public bool is0Button;
    public Sprite xIcon;
    public Sprite oIcon;
    public List<GameObject> buttons = new List<GameObject>();
    public List<int> ids = new List<int>();
    public List<int> aiIds = new List<int>();
    public bool isPlayerWinning;
    public bool isAIWinning;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private TextMeshProUGUI endText;
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
        endText.gameObject.SetActive(false);
        xButton.onClick.AddListener(XButton);
        oButton.onClick.AddListener(OButton);
        foreach (var button in buttons)
        {
            button.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }

    public void XButton()
    {
        isXbutton = true;
        is0Button = false;
        xButton.interactable = false;
        oButton.interactable = false;
        xButton.gameObject.SetActive(false);
        oButton.gameObject.SetActive(false);
    }

    public void OButton()
    {
        is0Button = true;
        isXbutton = false;
        xButton.interactable = false;
        oButton.interactable = false;
        xButton.gameObject.SetActive(false);
        oButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckWinningConditionsPlayer();
        CheckWinningConditionsAI();

        if (buttons.Count == 0)
        {
            if(!isAIWinning && !isPlayerWinning)
            {
                Debug.Log("Draw");
                gamePanel.SetActive(false);
                endText.gameObject.SetActive(true);
                endText.text = "PLAYER WON";
            }
        }
    }


    public void AITurn()
    {
        if (buttons.Count > 0)
        {
            int randomIndex = Random.Range(0, buttons.Count);
            GameObject randomButton = buttons[randomIndex];
            ButtonController buttonController = randomButton.GetComponent<ButtonController>();
            Debug.Log("AI Played");
            randomButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            aiIds.Add(randomButton.GetComponent<ButtonController>().id);
            if (buttonController != null && buttonController.isFree)
            {
                if (isXbutton) 
                {
                    buttonController.AIMove(oIcon);
                    isXbutton = true;
                    is0Button = false;
                }
                else if (is0Button) 
                {
                    buttonController.AIMove(xIcon);
                    is0Button = true;
                    isXbutton = false;
                }
            }
        }
    }

    public void CheckWinningConditionsPlayer()
    {
        List<int[]> winningSequencesPlayer = new List<int[]>
    {
        new int[] { 0, 1, 2 },
        new int[] { 0, 3, 6 },
        new int[] { 0, 4, 8 },
        new int[] { 2, 5, 8 },
        new int[] { 8, 4, 0 }
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

           
            if (isPlayerWinning)
            {
                Debug.Log("Player Won");
                gamePanel.SetActive(false);
                endText.gameObject.SetActive(true);
                endText.text = "PLAYER WON";
                return;
            }
        }
    }
  
public void CheckWinningConditionsAI()
{
    List<int[]> winningSequencesAI = new List<int[]>
    {
        new int[] { 0, 1, 2 },
        new int[] { 0, 3, 6 },
        new int[] { 0, 4, 8 },
        new int[] { 2, 5, 8 },
        new int[] { 8, 4, 0 }
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


        if (isAIWinning)
        {
            Debug.Log("AI Won");
                gamePanel.SetActive(false);
                endText.gameObject.SetActive(true);
                endText.text = "AI WON";
            return;
        }
    }
}
  }