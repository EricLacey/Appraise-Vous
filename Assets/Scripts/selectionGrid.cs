using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionGrid : MonoBehaviour
{
    int timeGridInt = 1;
    int numGridInt = 1;
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


    void OnGUI()
    {
        timeGridInt = GUILayout.SelectionGrid(timeGridInt, timeTextures, 3, GUIStyle.none, GUILayout.Width(100), GUILayout.Height(50));
        numGridInt = GUILayout.SelectionGrid(numGridInt, numTextures, 3, GUIStyle.none, GUILayout.Width(100), GUILayout.Height(50));
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

