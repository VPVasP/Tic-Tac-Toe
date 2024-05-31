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
        //if it is the players turn to play and the button is free 
        if (GameController.instance.isPlayerTurn && isFree)
        {
            
            //if the player chose the XButton
            if (GameController.instance.isXbutton)
            {
                //add the button id to the ids list 
                GameController.instance.ids.Add(id);
                //set the image color back to full color in the A
                button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                //place the X icon
                PlayerMove(GameController.instance.xIcon);
                GameController.instance.isXbutton = true; 
                GameController.instance.is0Button = false;
                GameController.instance.isPlayerTurn = false;
                //begin AI Coroutine
                StartCoroutine(AIMoveAfterDelay());
            
            }
            //if the player chose the OButton
            else if (GameController.instance.is0Button)
            {
                //add the button id to the ids list
                GameController.instance.ids.Add(id);
                //set the image color back to full color in the A
                button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                //place the O icon
                PlayerMove(GameController.instance.oIcon);
                GameController.instance.is0Button = true;  
                GameController.instance.isXbutton = false;
                GameController.instance.isPlayerTurn = false;
                //begin AI Coroutine
                StartCoroutine(AIMoveAfterDelay());
            }
        }
    }
    private IEnumerator AIMoveAfterDelay()
    {
        //wait 1 second and then call the AI Turn function
        yield return new WaitForSeconds(1f);
        GameController.instance.AITurn();
    }
    public void PlayerMove(Sprite icon)
    {
        //play the sound effect
        AudioManager.instance.PlayPlayerSoundEffect();
        Debug.Log(id);
        //set the button image to set the sprite icon
        button.image.sprite = icon;
        isFree = false;
        //remove the button from the list
        GameController.instance.buttons.Remove(this.gameObject);
    }
    
    public void AIMove(Sprite icon)
    {
      
        if (isFree)
        {
            //set the button image to set the sprite icon
            button.image.sprite = icon;
            isFree = false;
            //remove the button from the list
            GameController.instance.buttons.Remove(this.gameObject);
            AudioManager.instance.PlayAISoundEffect();
        }

    }
}
