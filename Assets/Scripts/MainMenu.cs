using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
