using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public float currentTime = 0f;
    float startingTime = 180f;
    bool active;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        countdownText.color = Color.white;
    }


    private void OnEnable()
    {
        active = true;
        currentTime = startingTime;
        countdownText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 10)
                countdownText.color = Color.Lerp(Color.white, Color.red, currentTime.Remap(10f, 0f, 0f, 1f));

            if (currentTime <= 0)
            {
                gameObject.GetComponent<GameMaster>().CheckResults();
            }
        }

    }

    public void onPause()
    {
        active = false;
    }

    public void onResume()
    {
        active = true;
    }
}
