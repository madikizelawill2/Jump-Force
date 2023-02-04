




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudioSource;
    public ParticleSystem particleExplosion;
    public ParticleSystem dirtParticle;
    public AudioClip collisionSound;
    public AudioClip jumpSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.tag == "Ground"){
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.tag == "Obstacle"){
            gameOver = true;    
            Debug.Log("Game Over");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType", 1);
            particleExplosion.Play();
            dirtParticle.Play();
            playerAudioSource.PlayOneShot(collisionSound, 1.0f);    
        }
    }
}
