using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private Button xButton, oButton;
    public bool isXbutton;
    public bool is0Button;
    public Sprite xIcon;
    public Sprite oIcon;
    public List<GameObject> buttons = new List<GameObject>();

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
        xButton.onClick.AddListener(XButton);
        oButton.onClick.AddListener(OButton);
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

    public void AITurn()
    {
        if (buttons.Count > 0)
        {
            int randomIndex = Random.Range(0, buttons.Count);
            GameObject randomButton = buttons[randomIndex];
            ButtonController buttonController = randomButton.GetComponent<ButtonController>();
            Debug.Log("AI Played");
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
}