using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float movementCooldown = 0.25f;
    [SerializeField] private float movementSpeed = 0.1f;
    
    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private IEnumerator Move(Vector2 direction)
    {
        Vector2 startingPosition = transform.position;
        Vector2 targetPosition = startingPosition + direction.normalized;
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
}
