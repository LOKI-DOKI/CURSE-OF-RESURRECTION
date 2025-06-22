using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        [TextArea(3, 5)]
        public string dialogue;
    }

    public GameObject dialogueUI;          // Reference to the dialogue UI panel
    public TextMeshProUGUI dialogueText;   // TextMeshPro for dialogue display
    public Button nextButton;              // Next button to progress dialogue

    private int currentLineIndex = 0;
    private DialogueLine[] dialogueLines;
    private bool isDialogueActive = false;

    void Start()
    {
        dialogueUI.SetActive(false);
        nextButton.onClick.AddListener(NextDialogue);  // Add listener to button
    }

    public void StartDialogue(DialogueLine[] lines)
    {
        dialogueLines = lines;
        currentLineIndex = 0;
        isDialogueActive = true;
        dialogueUI.SetActive(true);
        ShowDialogue();
    }

    void ShowDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = $"<b>{dialogueLines[currentLineIndex].characterName}:</b> {dialogueLines[currentLineIndex].dialogue}";
        }
        else
        {
            EndDialogue();
        }
    }

    public void NextDialogue()
    {
        currentLineIndex++;
        ShowDialogue();
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        isDialogueActive = false;
    }
}
