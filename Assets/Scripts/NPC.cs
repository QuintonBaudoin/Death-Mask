using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour, InteractInterface
{
    char interactKey = 'E';
    string text = "Howdy";
    string longText = "Good day fellow capsule, what brings you to this fine piece of unfinished structure? That's okay good sir, I can see you do not have a mouth so there's no need to answer that. I also do not have a mouth so I am infact talking to myself...in my head.";
    int textOffset = 20;

    bool triggered = false;
    bool talking = false;

    public void Interact()
    {
        //position of the character
        Vector3 charPos = transform.position;
        //apply offset for text position
        charPos.y += textOffset;        
        //convert to screen space
        charPos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Label(new Rect(charPos.x, charPos.y, 60, 30), text);
    }

    void OnTriggerEnter(Collider c)
    {
        triggered = true;

        if (c.gameObject.name == "Player")
        {
            
        }
        
    }

    void OnTriggerExit(Collider c)
    {
        triggered = false;
        talking = false;
    }

    void OnGUI()
    {
        if (triggered)
        {
            //size of textbox
            Vector2 labelSize;
            //position of the character
            Vector3 charPos = transform.position;
            //apply offset for text position
            //charPos.y += transform.localScale.y / 2 /*+ textOffset*/;
            //convert to screen space
            charPos = Camera.main.WorldToScreenPoint(charPos);

            if (!talking)
            {
                //calculate the size of text box for the given text
                labelSize = GUIStyle.none.CalcSize(new GUIContent("Press " + interactKey + " to Interact"));
                labelSize.y += GUIStyle.none.CalcHeight(new GUIContent("Press " + interactKey + " to Interact"), labelSize.x);

                GUI.Label(new Rect(charPos.x - labelSize.x / 2, charPos.y, labelSize.x, labelSize.y), "Press " + interactKey + " to Interact");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    talking = true;
                }
            }
            else if (talking)
            {
                labelSize = GUIStyle.none.CalcSize(new GUIContent(longText));
                labelSize.y += GUIStyle.none.CalcHeight(new GUIContent(longText), labelSize.x);
                if (labelSize.x > 200)
                {
                    labelSize.x /= 3;
                    labelSize.y *= 3;
                }

                GUI.Label(new Rect(charPos.x - labelSize.x / 2, charPos.y - (labelSize.y + textOffset), labelSize.x, labelSize.y), longText);
            }
        }
    }

}
