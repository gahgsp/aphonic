using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [Header("Map Information")]
    [SerializeField] private GameObject mapController;

    [Header("Player Attributes")]
    [SerializeField] private float movementCooldown = 0.25f;
    [SerializeField] private float movementSpeed = 0.1f;

    [Header("Text Box")]
    [SerializeField] private GameObject letterTextBox;
    
    // Cached references
    private Map _map;
    private UIManager _uiManager;
    private LetterBoxController _letterBoxController;

    private bool _isMoving;

    private House _currTouchedHouse;
    private NPC _currTouchedNPC;

    // Start is called before the first frame update
    void Start()
    {
        _map = mapController.GetComponent<Map>();
        _uiManager = FindObjectOfType<UIManager>();
        _letterBoxController = letterTextBox.GetComponent<LetterBoxController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Once all the letters are delivered and the last text is not being shown anymore
        // we can finish the game.
        if (_letterBoxController.HasDeliveredAllLetters() && !_letterBoxController.IsShowingText)
        {
            _uiManager.LoadNextScene();
        }

        // We check if we are currently showing a text from a letter delivery.
        if (_letterBoxController.IsShowingText && Input.GetKeyDown(KeyCode.Space))
        {
            _letterBoxController.HideText();
        }

        // We can only move the player again once it reached the destination
        // or there is no text being shown.
        if (_isMoving || _letterBoxController.IsShowingText)
        {
            return;
        }

        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        var verticalMovement = Input.GetAxisRaw("Vertical");

        // The player can't walk in both directions.
        if (horizontalMovement != 0f)
        {
            verticalMovement = 0f;
        }

        if (horizontalMovement != 0f || verticalMovement != 0f)
        {
            StartCoroutine(TryToMove(new Vector2(horizontalMovement, verticalMovement)));
        }

        // If the player is currently touching a house and it has a letter to send,
        // we collect the letter.
        if (Input.GetKeyDown(KeyCode.Space) && _currTouchedHouse != null)
        {
            // We can't deliver a letter to a house that already received one...
            if (_currTouchedHouse.IsReceivingLetter)
            {
                _currTouchedHouse.DeliverLetter();
                _letterBoxController.ShowLetterText();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && _currTouchedNPC != null)
        {
            if (_currTouchedNPC.HasConversation)
            {
                _currTouchedNPC.FinishConversation();
                _letterBoxController.ShowNPCText();   
            }
        }
    }

    /// <summary>
    /// Checks if the player can move to the target position.
    /// </summary>
    private bool CanMove(Vector3 targetPosition)
    {
        return !_map.IsEnvironmentTile(targetPosition);
    }

    /// <summary>
    /// Based on the player movement, try to reach the target tile.
    /// </summary>
    private IEnumerator TryToMove(Vector2 direction)
    {
        Vector2 startingPosition = transform.position;
        Vector2 targetPosition = startingPosition + direction.normalized;

        if (!CanMove(targetPosition))
        {
            yield return MoveTo(startingPosition, startingPosition);
        }
        else
        {
            yield return MoveTo(startingPosition, targetPosition);
        }
    }

    /// <summary>
    /// Moves the player to the target position on the map.
    /// </summary>
    private IEnumerator MoveTo(Vector2 startingPosition, Vector2 targetPosition)
    {
        float timer = 0;
        _isMoving = true;

        while (timer < movementCooldown)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, timer / movementSpeed);
            yield return null;
        }

        _isMoving = false;
        yield return 0;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // We are touching a house...
        if (other.gameObject.GetComponent<House>() != null)
        {
            _currTouchedHouse = other.gameObject.GetComponent<House>();
        }
        else
        {
            // We are touching a NPC...
            _currTouchedNPC = other.gameObject.GetComponent<NPC>();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currTouchedHouse = null;
        _currTouchedNPC = null;
    }
}