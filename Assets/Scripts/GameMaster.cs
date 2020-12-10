using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    int objNum = -1;
    public int roundNum = 0;
    int maxRounds;

    float roundResults = 0;
    bool strike = false;
    bool hasFailed = false;
    bool hasSucceded = false;
    public GameObject goodEnd;
    public GameObject medEnd;
    public GameObject badEnd;
    public Text scoreText;

    CountdownTimer countdownTimer;

    public GameObject currArt;

    public Text paperArtist;
    public Text paperArtDate;
    public Text paperArtName;
    public Text currArtNameFrag;

    public GameObject gameOverScreen;
    public GameObject magnifyingGlass;

    AudioSource audioSource;
    public AudioClip wrongBuzzer;
    public AudioClip rightDing;

    public GameObject welcomeScreen;
    public GameObject tutorialScreen;

    private void Awake()
    {
        countdownTimer = GetComponent<CountdownTimer>();
        audioSource = GetComponent<AudioSource>();
        maxRounds = PlayerPrefs.GetInt("NumPieces");
    }

    // Start is called before the first frame update
    void Start()
    {
        welcomeScreen.SetActive(true);
    }

    public void NextLevel()
    {
        strike = false;
        roundNum++;

        if (currArt != null)
        {
            paperArtist.GetComponentInParent<InputField>().text = "";
            paperArtName.GetComponentInParent<InputField>().text = "";
            paperArtDate.GetComponentInParent<InputField>().text = "";
        }
        
  
        if (roundNum > maxRounds) 
        {
            EndGame();
        }
        else
        {
            Camera.main.GetComponent<CameraMover>().StartMove();
            countdownTimer.enabled = false;

            if (objNum >= 0) { gameObject.GetComponent<ArtSpawner>().DeleteOldArt(objNum); }
            

            if (objNum < 3) { objNum++; }
            else { objNum = 0; };

            gameObject.GetComponent<ArtSpawner>().SpawnArt(objNum);
        };

    }
    public void StartRound()
    {
        countdownTimer.enabled = true;

    }

    public void CheckResults()
    {
        if (
        paperArtist.GetComponentInParent<InputField>().text.ToUpper() == currArt.GetComponent<ObjValues>().artist.ToString().ToUpper() &&
        paperArtName.GetComponentInParent<InputField>().text.ToUpper() == currArt.GetComponent<ObjValues>().artName.ToString().ToUpper() &&
        paperArtDate.GetComponentInParent<InputField>().text.ToUpper() == currArt.GetComponent<ObjValues>().artDate.ToString().ToUpper()
        )
        {
            switch (PlayerPrefs.GetInt("TimePerPiece"))
            {
                case 2:
                    roundResults += (countdownTimer.currentTime / (PlayerPrefs.GetInt("TimePerPiece") * 60)) * 2 * 100;
                    break;
                case 3:
                    roundResults += (countdownTimer.currentTime / (PlayerPrefs.GetInt("TimePerPiece") * 60)) * 100;
                    break;
                case 5:
                    roundResults += (countdownTimer.currentTime / (PlayerPrefs.GetInt("TimePerPiece") * 60)) * 0.5f * 100;
                    break;
                default:
                    break;
            }
            audioSource.PlayOneShot(rightDing, 0.2F);
            hasSucceded = true;
            NextLevel();
        } else if (!strike)
        {
            audioSource.PlayOneShot(wrongBuzzer, 0.05F);
            strike = true;
        }
        else
        {
            audioSource.PlayOneShot(wrongBuzzer, 0.05F);
            hasFailed = true;
            NextLevel();
        }

        

    }
    void EndGame()
    {
        countdownTimer.currentTime = 3;
        countdownTimer.onPause();

        gameOverScreen.SetActive(true);

        if (hasFailed && hasSucceded)
        {
            medEnd.SetActive(true);
        } else if (hasFailed)
        {
            badEnd.SetActive(true);
        }
        else
        {
            goodEnd.SetActive(true);
        }

        scoreText.text = roundResults.ToString("0");
    }

    public void spawnMagnifier()
    {
        GameObject newMag = Instantiate(magnifyingGlass);
        newMag.transform.parent = gameObject.transform;
    }

    public void toTutorial()
    {
        welcomeScreen.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void closeTutorial()
    {
        tutorialScreen.SetActive(false);
        NextLevel();
    }
}
