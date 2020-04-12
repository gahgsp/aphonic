using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject conversationSign;
    
    // Every NPC starts with an available conversation...
    public bool HasConversation { get; set; } = true;
    
    // Update is called once per frame
    void Update()
    {
        UpdateConversationSignStatus();   
    }

    /// <summary>
    /// Checks if the NPC still has a conversation available.
    /// </summary>
    private void UpdateConversationSignStatus()
    {
        if (HasConversation)
        {
            conversationSign.SetActive(true);
        }
        else
        {
            conversationSign.SetActive(false);
        }
    }

    public void FinishConversation()
    {
        HasConversation = false;
    }
}
