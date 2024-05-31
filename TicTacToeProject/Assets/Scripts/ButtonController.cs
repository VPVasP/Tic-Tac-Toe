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
                button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PlayerMove(GameController.instance.xIcon);
                GameController.instance.isXbutton = true; 
                GameController.instance.is0Button = false;
                StartCoroutine(AIMoveAfterDelay());
            
            }
            else if (GameController.instance.is0Button)
            {
                button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PlayerMove(GameController.instance.oIcon);
                GameController.instance.is0Button = true;  
                GameController.instance.isXbutton = false;
                StartCoroutine(AIMoveAfterDelay());
            }
        }
    }
    private IEnumerator AIMoveAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        GameController.instance.AITurn();
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
