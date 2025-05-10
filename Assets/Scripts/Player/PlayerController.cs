using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Movimenta��o")]
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
        // Verifica se est� no ch�o
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Garante que o personagem "cole" no ch�o
        }

        // Captura a entrada de movimento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Movimento em 8 dire��es relativo � rota��o do jogador
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move = move.normalized * moveSpeed;

        // Pulo
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplica gravidade
        velocity.y += gravity * Time.deltaTime;

        // Combina movimento horizontal com vertical (gravidade/pulo)
        Vector3 finalMove = move;
        finalMove.y = velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }
}
