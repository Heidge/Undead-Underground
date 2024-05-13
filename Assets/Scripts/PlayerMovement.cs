using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private Vector2 inputVector;
    private Vector3 moveDir;


    private void Update() {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }


    void FixedUpdate() {
        moveDir = new(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero) {
            // Change la direction du vecteur vers la o� regarde le player
            moveDir = transform.TransformDirection(moveDir);
            transform.position += moveSpeed * Time.deltaTime * moveDir;
        }
    }
}
