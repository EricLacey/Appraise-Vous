using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionGrid : MonoBehaviour
{
    int timeGridInt = 1;
    int numGridInt = 1;

    string[] timeVals = { "2 minutes", "3 minutes", "5 minutes" };
    string[] numVals = { "1", "3", "5" };

    /*
    public List<Sprite> timeSprites;
    public List<Sprite> numSprites;
    Texture2D[] timeTextures = new Texture2D[3];
    Texture2D[] numTextures = new Texture2D[3];

    GUIStyle btnStyle = new GUIStyle(GUIStyle.none);

    void OnEnable()
    {
        for (int i = 0; i < timeSprites.Count; i++)
        {
            timeTextures[i] = textureFromSprite(timeSprites[i]);
        }

        for (int i = 0; i < numSprites.Count; i++)
        {
            numTextures[i] = textureFromSprite(numSprites[i]);
        }
    }
    */


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width/2 - 150, Screen.height/2 - 18, 900, 60));
        numGridInt = GUILayout.SelectionGrid(numGridInt, numVals, 3, GUILayout.Width(300), GUILayout.Height(50));
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 80, 900, 60));
        timeGridInt = GUILayout.SelectionGrid(timeGridInt, timeVals, 3, GUILayout.Width(300), GUILayout.Height(50));
        GUILayout.EndArea();
    }

    public void SetPlayerPrefs()
    {
        switch (timeGridInt)
        {
            case 0:
                PlayerPrefs.SetInt("TimePerPiece", 2);
                break;
            case 1:
                PlayerPrefs.SetInt("TimePerPiece", 3);
                break;
            case 2:
                PlayerPrefs.SetInt("TimePerPiece", 5);
                break;
            default:
                break;
        }

        switch (numGridInt)
        {
            case 0:
                PlayerPrefs.SetInt("NumPieces", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("NumPieces", 3);
                break;
            case 2:
                PlayerPrefs.SetInt("NumPieces", 5);
                break;
            default:
                break;
        }
    }


    //from https://answers.unity.com/questions/651984/convert-sprite-image-to-texture.html
    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }
}

