using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Dialogue dialogue;
    void OnMouseDown()
    {
        Debug.Log("Object Clicked!");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        // Perform button action here
    }
}
