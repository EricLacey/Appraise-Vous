using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum menuStates { Title, Credits, Context, Explanation, Character, Setup};
    public menuStates currentState;

    public GameObject TitleScreen;
    public GameObject CreditsScreen;
    public GameObject ContextScreen;
    public GameObject ExplinationScreen;
    public GameObject CharacterSelectScreen;
    public GameObject SetupScreen;

    private void Awake()
    {
        currentState = menuStates.Title;
    }

    private void Update()
    {
        switch (currentState)
        {
            case menuStates.Title:
                TitleScreen.SetActive(true);
                CreditsScreen.SetActive(false);
                ContextScreen.SetActive(false);
                ExplinationScreen.SetActive(false);
                CharacterSelectScreen.SetActive(false);
                SetupScreen.SetActive(false);
                break;
            case menuStates.Credits:
                TitleScreen.SetActive(false);
                CreditsScreen.SetActive(true);
                ContextScreen.SetActive(false);
                ExplinationScreen.SetActive(false);
                CharacterSelectScreen.SetActive(false);
                SetupScreen.SetActive(false);
                break;
            case menuStates.Context:
                TitleScreen.SetActive(false);
                CreditsScreen.SetActive(false);
                ContextScreen.SetActive(true);
                ExplinationScreen.SetActive(false);
                CharacterSelectScreen.SetActive(false);
                SetupScreen.SetActive(false);
                break;
            case menuStates.Explanation:
                TitleScreen.SetActive(false);
                CreditsScreen.SetActive(false);
                ContextScreen.SetActive(false);
                ExplinationScreen.SetActive(true);
                CharacterSelectScreen.SetActive(false);
                SetupScreen.SetActive(false);
                break;
            case menuStates.Character:
                TitleScreen.SetActive(false);
                CreditsScreen.SetActive(false);
                ContextScreen.SetActive(false);
                ExplinationScreen.SetActive(false);
                CharacterSelectScreen.SetActive(true);
                SetupScreen.SetActive(false);
                break;
            case menuStates.Setup:
                TitleScreen.SetActive(false);
                CreditsScreen.SetActive(false);
                ContextScreen.SetActive(false);
                ExplinationScreen.SetActive(false);
                CharacterSelectScreen.SetActive(false);
                SetupScreen.SetActive(true);
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
    public void GoToTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void GoToCredits()
    {
        currentState = menuStates.Credits;
    }
    public void GoToContext()
    {
        currentState = menuStates.Context;
    }
    public void GoToExplination()
    {
        currentState = menuStates.Explanation;
    }
    public void goToCharacter()
    {
        currentState = menuStates.Character;
    }
    public void GoToSetup()
    {
        currentState = menuStates.Setup;
    }
}
