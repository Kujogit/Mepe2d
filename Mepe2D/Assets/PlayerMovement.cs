using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Animator animator; //antaa ty�skennell� animatorin kanssa editorin sis�ll�
    public Rigidbody2D rb; //yhteys pelaajahahmon rigid bodyyn



    void Update()
    {
        if (FindFirstObjectByType<PauseMenu>().GameIsPaused) return;

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) 
        {
            Debug.Log("Jump");
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) 
        {
        crouch = false;
        }

        UpdateVerticalAnimations(); // alempana on vertikaalinen animaatiotarkistus, hypp��tk� vai tiputko

    }

    public void OnLanding()
    {
        Debug.Log("OnLanding tapahtui");
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void UpdateVerticalAnimations()
    {
        //t�m� tarkastaa pelaajan rigidbodyn Y-akselin nopeuden ja selvitt�� onko se +/- eli hypp�� vai tippuu
        float verticalVelocity = rb.linearVelocity.y;
        //t�m� l�ytyi PlayerController-scriptin sis�lt�, tarkastaa sielt� onko pelaaja maassa (IsGrounded)
        bool isGrounded = controller.IsGrounded; 

        if (verticalVelocity > 0.1f && !isGrounded) //onko vertikaalinen (y-akseli) nopeus positiivinen eli hyppy ja pelaaja EI (!) ole maassa niin...
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        else if(verticalVelocity < -0.1f && !isGrounded) 
        {
            animator.SetBool("IsJumping", false) ;
            animator.SetBool("IsFalling", true) ;
        }
        else
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
