 using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

   
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimator.SetBool("Attack", true);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    public void EndAttack()
    {
        playerAnimator.SetBool("Attack", false);
        Debug.Log("hola");
    }
}
