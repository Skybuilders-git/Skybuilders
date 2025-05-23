using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public GameObject pauseMenu;
    private bool pauseGame;
    public GameObject gameManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private void Start()
    {
        pauseGame = false;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded() && gameManager.GetComponent<GameManager>().canInput == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f && gameManager.GetComponent<GameManager>().canInput == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();

        if (Input.GetButtonDown("Pause") && gameManager.GetComponent<GameManager>().canInput == true)
        {
            pauseGame = !pauseGame;
            PauseGame();
            Debug.Log("pause");
        }

        //debug
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
        

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);


    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f && gameManager.GetComponent<GameManager>().canInput == true && pauseGame == false || !isFacingRight && horizontal > 0f && gameManager.GetComponent<GameManager>().canInput == true && pauseGame == false)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void PauseGame()
    {
        if (pauseGame == true && Time.timeScale == 1f)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

        }

        if (pauseGame == false && Time.timeScale == 0f)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;

        }
    }
}