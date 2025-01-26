using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerInput input;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = input.actions["Move"].ReadValue<Vector2>();

        if (movementInput.magnitude > 0)
            anim.SetBool("moving", true);
        else
            anim.SetBool("moving", false);

        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);

        rb.MovePosition(transform.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        
    }
}
