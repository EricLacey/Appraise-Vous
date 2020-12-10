using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionGrid : MonoBehaviour
{
    int selGridInt = 0;
    string[] selStrings = { "radio1", "radio2", "radio3" };

    void OnGUI()
    {
        GUILayout.BeginHorizontal("Box");
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 3);
        if (GUILayout.Button("Start"))
        {
            Debug.Log("You chose " + selStrings[selGridInt]);
        }
        GUILayout.EndVertical();
    }
}

