using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ArtSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> PrefabList = new List<GameObject>();
    [SerializeField] List<GameObject> PedistalList = new List<GameObject>();

    List<int> spawnedArt = new List<int>();

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnArt(int pedistalNum)
    {
        int randNum = Random.Range(0, PrefabList.Count - 1);

        if (spawnedArt.Contains(randNum))
        {
            SpawnArt(pedistalNum);
        }
        else
        {
            GameObject Art = Instantiate(PrefabList[randNum], PedistalList[pedistalNum].transform.Find("ObjectSpawnPoint").transform);
            gameObject.GetComponent<GameMaster>().currArt = Art;
            Text text = PedistalList[pedistalNum].transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>();
            text.text = Art.GetComponent<ObjValues>().artistPartialName;
            spawnedArt.Add(randNum);

        }
    }

    public void DeleteOldArt(int pedistalNum)
    {
        Destroy(PedistalList[pedistalNum].transform.GetChild(0).GetChild(0).gameObject);        
    }
}
