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
    private void Awake()
    {
        if(instance == null)
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
}