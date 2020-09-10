using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Move move;
    public GameObject textBox;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            move.isTalking = true; //continueButton.SetActive(true);
            textBox.SetActive(true);
            TriggerDialogue();
            Debug.Log("collision");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            Debug.Log("collisionleave");
        }

    }
}
