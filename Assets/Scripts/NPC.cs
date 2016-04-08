/*
Documentation
*/

using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour, InteractInterface
{
    Dialog dialog;
    char interactKey = 'E';
    string longText = "Good day fellow capsule, what brings you to this fine piece of unfinished structure? That's okay good sir, I can see you do not have a mouth so there's no need to answer that. I also do not have a mouth so I am infact talking to myself...in my head.";
    int textOffset = 20;

    bool triggered = false;
    bool talking = false;

    void Start()
    {
        dialog = new Dialog();
    }

    public void Interact()
    {
        //position of the character
        Vector3 charPos = transform.position;
        //convert to screen space
        charPos = Camera.main.WorldToScreenPoint(charPos);

        dialog.Say(longText, charPos, textOffset);
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
        dialog.active = false;
    }

    void OnGUI()
    {
        if (triggered)
        {
            //position of the character
            Vector3 charPos = transform.position;
            //convert to screen space
            charPos = Camera.main.WorldToScreenPoint(charPos);

            if (!dialog.active)
            {
                dialog.Say("Press " + interactKey + " to Talk", charPos);

                if (Input.GetKeyDown(KeyCode.E))
                    dialog.active = true;
            }
            else if (dialog.active)
                dialog.Say(longText, charPos, textOffset);
        }
    }

}
