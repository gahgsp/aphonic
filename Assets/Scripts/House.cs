using UnityEngine;

public class House : MonoBehaviour
{
    
    public GameObject letterSign;

    // Every house starts receiving a letter
    public bool IsReceivingLetter { get; set; } = true;
    
    // Update is called once per frame
    void Update()
    {
        UpdateLetterSignStatus();   
    }

    /// <summary>
    /// Checks if the letter sign must be shown.
    /// </summary>
    private void UpdateLetterSignStatus()
    {
        if (IsReceivingLetter)
        {
            letterSign.SetActive(true);
        }
        else
        {
            letterSign.SetActive(false);
        }
    }
    
    /// <summary>
    /// Represents the deliver action.
    /// Once a letter is delivered, the house is not receiving a letter anymore.
    /// </summary>
    public void DeliverLetter()
    {
        IsReceivingLetter = false;
    }
}
