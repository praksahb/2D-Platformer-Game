using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public GameWonController gameWonController;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
 
    private bool isCrouched = false;
    private bool isGrounded = true;
    private float horizontal, vertical;
    private float normalSpeed;

    public float playerSpeed;
    public float jumpAmount;
    public float crouchedSpeed;
    public int playerHealth;
    private int levelScore;

    //requies UnityEngine.UI
    public Image[] healthImageArray;

    private void Awake()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        normalSpeed = playerSpeed;
        playerHealth = 3;
        crouchedSpeed = normalSpeed / 2;
    }

    private void Update()
    {
        // input mapping to player movements
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isCrouched = Input.GetKey(KeyCode.LeftControl);

        //player movement and animation
        PlayCrouchAnimation(isCrouched);
        MoveCharacter();
        PlayMovementAnimation();
        
    }
    void OnApplicationQuit()
    {
        string cLevel = "currentLevelBeforeExiting";
        LevelManager.Instance.SetResumeGameLevel(cLevel);
    }

    // Player animations control

    private void PlayCrouchAnimation(bool isKeyDownCrouch)
    {
        if (isKeyDownCrouch)
        {
            isCrouched = true;
            playerAnimator.SetBool("isCrouchPressed", true);
        }
        else
        {
            isCrouched = false;
            playerAnimator.SetBool("isCrouchPressed", false);
        }
    }
    private void PlayMovementAnimation()
    {
        //move animation Horizontally
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        SwitchHorizontalDirection();

        //move animation Vertically
        VerticalJumpAnimation();
    }
    private void VerticalJumpAnimation()
    {
        if (playerRigidBody.velocity.y == 0 || isGrounded)
        {
            playerAnimator.SetBool("isJumpPressed", false);
            playerAnimator.SetBool("isFalling", false);
        }
        if (vertical > 0)
        {
            playerAnimator.SetBool("isJumpPressed", true);
        }

        if (playerRigidBody.velocity.y < 0 && !isGrounded)
        {
            playerAnimator.SetBool("isJumpPressed", false);
            playerAnimator.SetBool("isFalling", true);
        }
    }

    //Player movement and animation control

    private void SwitchHorizontalDirection()
    {
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
            //changes direction player is facing on x-axis
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    // Player movement control

    private void MoveCharacter()
    {

        //speed Modifier
        _ = isCrouched ? playerSpeed = crouchedSpeed : playerSpeed = normalSpeed;

        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;

        //move character vertically 
        if (vertical > 0 && isGrounded && !isCrouched)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpAmount);
        }
    }

    //Player Movement related Sounds
    // Called in animation event functions

    private void PlaySoundEffectsPlayerMove()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerMove);
    }

    private void PlaySoundEffectsPlayerJump()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerJump);
    }
    private void PlaySoundEffectsPlayerJumpLanding()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerLand);
    }

    private void KillPlayingSoundsWhilePlayerIdle()
    {
        if(SoundManager.Instance.IsSoundEffectPlaying())
        {
            SoundManager.Instance.StopPlayEffect();
        }
        if(SoundManager.Instance.IsMusicPlaying())
        {
            SoundManager.Instance.StopPlayMusic();
        }
    }

    // Physics Collision based controller functions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //SoundManager.Instance.PlayEffect(Sounds.PlayerLand);
        }
        if (collision.gameObject.CompareTag("InstantDeath"))
            KillPlayer();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelComplete"))
        {
            levelScore = scoreController.GetScore();
            LevelCompleted();
        }
    }

    // game logic

    private void LevelCompleted()
    {
        gameWonController.LoadGameWonUI(levelScore);
        LevelManager.Instance.MarkCurrentLevelComplete();
        enabled = false;
    }

    public void DamagePlayer()
    {
        //play hurt animation
        //playerAnimator.SetBool("Change value to play hurt animation", true);

        playerHealth--;
        UpdateHealthUI();

        if (playerHealth <= 0)
            KillPlayer();
    }
    public void KillPlayer()
    {
        SoundManager.Instance.PlayEffect(Sounds.PlayerDeath);
        playerAnimator.SetBool("isPlayerDead", true);
        Invoke("InvokeGameOverMethod", playerAnimator.GetCurrentAnimatorStateInfo(0).length);
        enabled = false;
    }

    // UI related methods

    private void InvokeGameOverMethod()
    {
        gameOverController.LoadGameOverUI();
    }

    public void PickUpKey()
    {
        scoreController.IncrementScore(10);
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthImageArray.Length; i++)
        {
            if (i < playerHealth)
                healthImageArray[i].color = Color.red;
            else
                healthImageArray[i].color = Color.clear;
        }
    }
}