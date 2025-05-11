using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Movimentação")]
    public float moveSpeed = 6f;

    [Header("Pulo e Gravidade")]
    public float gravity = -50f;
    public float jumpHeight = 3f;




    void Start()
    {
        controller = GetComponent<CharacterController>();


    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Verifica se está no chão
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Garante que o personagem "cole" no chão
        }

        // Captura a entrada de movimento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Direção de movimento no espaço do mundo
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Gira o personagem na direção do movimento
        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        // Aplica velocidade de movimento
        Vector3 move = moveDirection * moveSpeed;

        // Pulo
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplica gravidade
        velocity.y += gravity * Time.deltaTime;

        // Combina movimento horizontal com vertical
        Vector3 finalMove = move;
        finalMove.y = velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }
}
