using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public GameObject gameMasterObject;

    [SerializeField] List<GameObject> positions = new List<GameObject>();
    int currPosIndex = 0;

    
    Vector3 currPos;
    Vector3 nextPos;
    Vector3 homePos;

    bool movingHome = false;
    bool isRot = false;
    bool movingToNext = false;

    public bool test = false;

    float timeElapsed;
    float lerpDuration;
    float rotDuration;
    
    Quaternion toRot;


    // Start is called before the first frame update
    void Start()
    {
        homePos = new Vector3(0, 1.7f, 0);
        currPos = homePos;
        nextPos = positions[0].transform.position;

        timeElapsed = 0;
        lerpDuration = 2;
        rotDuration = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (test) { StartMove(); test = false; }

        if (movingHome)
        {
            gameObject.transform.position = Vector3.Lerp(currPos, homePos, timeElapsed / lerpDuration);

            if (Vector3.Distance(gameObject.transform.position, homePos) < 0.01)
            {
                timeElapsed = 0;
                movingHome = false;
                currPos = gameObject.transform.position;
                toRot = gameObject.transform.rotation * Quaternion.Euler(0, 90, 0);
                isRot = true;
            }
        } else if (isRot){
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, toRot, timeElapsed / rotDuration);

            if (Quaternion.Angle(gameObject.transform.rotation, toRot) < 0.1)
            {
                timeElapsed = 0;
                isRot = false;
                movingToNext = true;
            }
            
        } else if (movingToNext)
        {
            gameObject.transform.position = Vector3.Lerp(currPos, nextPos, timeElapsed / lerpDuration);

            if (Vector3.Distance(gameObject.transform.position, nextPos) < 0.01)
            {
                movingToNext = false;
                currPos = gameObject.transform.position;
                if (currPosIndex < positions.Count-1)
                {
                    currPosIndex++;
                    nextPos = positions[currPosIndex].transform.position;

                } else
                {
                    currPosIndex = 0;
                    nextPos = positions[currPosIndex].transform.position;
                }
                gameMasterObject.GetComponent<GameMaster>().StartRound();
            }
        }

        timeElapsed += Time.deltaTime;
    }

    public void StartMove()
    {
        movingHome = true;
        timeElapsed = 0;
    }
}
