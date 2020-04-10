using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject mapController;
    
    [SerializeField] private float movementCooldown = 0.25f;
    [SerializeField] private float movementSpeed = 0.1f;
    
    private bool _isMoving;
    private Map _map;

    private House _currTouchedHouse;
    private Letter _currLetter;

    // Start is called before the first frame update
    void Start()
    {
        _map = mapController.GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {

        // We can only move the player again once it reached the destination.
        if (_isMoving)
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
            StartCoroutine(Move(new Vector2(horizontalMovement, verticalMovement)));
        }

        // If the player is currently touching a house and it has a letter to send,
        // we collect the letter.
        if (Input.GetKeyDown(KeyCode.Space) && _currTouchedHouse != null)
        {
            // We can't collect a letter if a house isn't holding one...
            if (_currTouchedHouse.CurrSendingLetter != null)
            {
                _currTouchedHouse.CollectLetter();
            }
        }
        
    }

    private bool CanMove(Vector3 targetPosition)
    {
        return !_map.IsEnvironmentTile(targetPosition);
    }

    private IEnumerator Move(Vector2 direction)
    {
        Vector2 startingPosition = transform.position;
        Vector2 targetPosition = startingPosition + direction.normalized;

        if (!CanMove(targetPosition))
        {
            yield return BlockMovement(startingPosition, startingPosition);
        }
        else
        {
            yield return MoveTo(startingPosition, targetPosition);
        }
    }

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

    private IEnumerator BlockMovement(Vector2 startingPosition, Vector2 targetPosition)
    {
        yield return MoveTo(startingPosition, targetPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _currTouchedHouse = other.gameObject.GetComponent<House>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currTouchedHouse = null;
    }
}
