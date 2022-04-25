using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : Fighter
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction, whether you're going right or left
        if(moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Make sure we can move in y direction, by casting a box there first
        // If the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, 
            new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), 
            LayerMask.GetMask("Actor", "Blocking"));

        if(hit.collider == null)
        {
            // Move the player
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Make sure we can move in x direction, by casting a box there first
        // If the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, 
            new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), 
            LayerMask.GetMask("Actor", "Blocking"));

        if(hit.collider == null)
        {
            // Move the player
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
}
