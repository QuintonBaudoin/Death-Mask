/*
[Documentation]
*/

using UnityEngine;
using System.Collections;

public class Dialog
{
    public Vector3 textPosition;
    public bool active = false;

    public void Say( string text, Vector3 position, int yOffset = 0)
    {
        //size of textbox
        Vector2 labelSize;

        GUIContent content = new GUIContent(text);
        
        labelSize = GUIStyle.none.CalcSize(content);
        labelSize.y += GUIStyle.none.CalcHeight(content, labelSize.x);
        if (labelSize.x > 200)
        {
            labelSize.x /= 3;
            labelSize.y *= 3;
        }

        GUI.Label(new Rect(position.x - labelSize.x / 2, position.y - (labelSize.y + yOffset), labelSize.x, labelSize.y), text);
    }

    void DoDialog(Vector3 position)
    {

    }

    void ReadFile()
    {

    }
}
