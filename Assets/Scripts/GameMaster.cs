using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    int objNum = -1;
    public int roundNum = 0;
    static int MAX_ROUNDS = 2;

    List<string> roundResults = new List<string>();

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

    private void Awake()
    {
        countdownTimer = GetComponent<CountdownTimer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextLevel()
    {
        roundNum++;

        if (currArt != null)
        {
            paperArtist.GetComponentInParent<InputField>().text = "";
            paperArtName.GetComponentInParent<InputField>().text = "";
            paperArtDate.GetComponentInParent<InputField>().text = "";
        }
        
  
        if (roundNum > MAX_ROUNDS) 
        {
            EndGame();
        }
        else
        {
            Camera.main.GetComponent<CameraMover>().StartMove();
            countdownTimer.enabled = false;

            if (objNum < 3) { objNum++; }
            else { objNum = 0; };

            gameObject.GetComponent<ArtSpawner>().SpawnArt(objNum);
            currArtNameFrag.text ="Name Fragment: " + currArt.GetComponent<ObjValues>().artistPartialName.ToString();
        }

        ;

    }
    public void StartRound()
    {
        countdownTimer.enabled = true;

    }

    public void CheckResults()
    {
        if (
        paperArtist.GetComponentInParent<InputField>().text == currArt.GetComponent<ObjValues>().artist.ToString() &&
        paperArtName.GetComponentInParent<InputField>().text == currArt.GetComponent<ObjValues>().artName.ToString() &&
        paperArtDate.GetComponentInParent<InputField>().text == currArt.GetComponent<ObjValues>().artDate.ToString()
        ){
            roundResults.Add(countdownTimer.currentTime + " points");
            audioSource.PlayOneShot(rightDing, 0.2F);
        } else
        {
            roundResults.Add("Incorrect/out of time");
            audioSource.PlayOneShot(wrongBuzzer, 0.05F);
        }

        NextLevel();

    }
    void EndGame()
    {
        gameOverScreen.SetActive(true);
        gameOverScreen.transform.Find("Art 1 Result").GetComponent<Text>().text += roundResults[0];
        gameOverScreen.transform.Find("Art 2 Result").GetComponent<Text>().text += roundResults[1];
    }

    public void spawnMagnifier()
    {
        GameObject newMag = Instantiate(magnifyingGlass);
        newMag.transform.parent = gameObject.transform;
    }
}
