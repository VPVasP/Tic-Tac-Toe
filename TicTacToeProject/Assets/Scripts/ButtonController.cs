using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int id;
    private Button button;
    public bool isFree;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayerClick);
        isFree = true;
    }

    private void PlayerClick()
    {
        if (isFree)
        {
            if (GameController.instance.isXbutton)
            {
                PlayerMove(GameController.instance.xIcon);
                GameController.instance.isXbutton = false; 
                GameController.instance.is0Button = true;
                GameController.instance.AITurn();
            }
            else if (GameController.instance.is0Button)
            {
                PlayerMove(GameController.instance.oIcon);
                GameController.instance.is0Button = false;  
                GameController.instance.isXbutton = true;
                GameController.instance.AITurn();
            }
        }
    }

    public void PlayerMove(Sprite icon)
    {
        Debug.Log(id);
        button.image.sprite = icon;
        button.interactable = false;
        isFree = false;
        GameController.instance.buttons.Remove(this.gameObject);
    }

    public void AIMove(Sprite icon)
    {
        if (isFree)
        {
            button.image.sprite = icon;
            button.interactable = false;
            isFree = false;
            GameController.instance.buttons.Remove(this.gameObject);
        }
    }
}