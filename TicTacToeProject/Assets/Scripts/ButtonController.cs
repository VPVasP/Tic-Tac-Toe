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
        button.onClick.AddListener(ClickedkOnXButton);
        isFree = true;
    }
    public void ClickedkOnXButton()
    {
        if (GameController.instance.isXbutton &&isFree)
        {
            Debug.Log(id);
            button.interactable = false;
            button.image.sprite = GameController.instance.xIcon;
            isFree = false;
        }
    }
    public void ClickedkOnOButton()
    {
        if (GameController.instance.is0Button&&isFree)
        {
            Debug.Log(id);
            button.interactable = false;
            button.image.sprite = GameController.instance.oIcon;
            isFree = false;
        }
    }
}
 
