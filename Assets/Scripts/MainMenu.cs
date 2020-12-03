using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum menuStates { Title, Context, Character};
    public menuStates currentState;

    public GameObject titlePanel;
    public GameObject contextPanel;
    public GameObject CharacterMenu;

    private void Awake()
    {
        currentState = menuStates.Title;
    }

    private void Update()
    {
        switch (currentState)
        {
            case menuStates.Title:
                titlePanel.SetActive(true);
                contextPanel.SetActive(false);
                CharacterMenu.SetActive(false);
                break;
            case menuStates.Context:
                titlePanel.SetActive(false);
                contextPanel.SetActive(true);
                CharacterMenu.SetActive(false);
                break;
            case menuStates.Character:
                titlePanel.SetActive(false);
                contextPanel.SetActive(false);
                CharacterMenu.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void GoToBook()
    {
        SceneManager.LoadScene("BookScene");
    }

    public void GoToAuction()
    {
        SceneManager.LoadScene("AuctionScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnTitleBtn()
    {
        currentState = menuStates.Context;
    }
    public void OnContextBtn()
    {
        currentState = menuStates.Character;
    }
}
