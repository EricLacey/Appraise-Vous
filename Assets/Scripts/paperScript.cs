using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperScript : MonoBehaviour
{
    bool mouseOver = true;

    Vector3 startPos;
    Vector3 endPos;

    float moveDuration = 2;
    float timeElapsed = 0;

    private void OnMouseOver()
    {
        mouseOver = false;
        timeElapsed = 0;
    }
    private void OnMouseExit()
    {
        mouseOver = true;
        timeElapsed = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.localPosition;

        endPos = startPos + new Vector3(0,0.3f,0.05f);

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver)
        {
            gameObject.transform.localPosition = Vector3.Lerp(startPos, endPos, timeElapsed / moveDuration);
        }
        else
        {
            gameObject.transform.localPosition = Vector3.Lerp(endPos, startPos, timeElapsed / moveDuration);
        }
    }
}
