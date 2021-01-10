using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CharacterController))]
public class MeatBoy : MonoBehaviour{
    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 mouvement;
    private CharacterController controller;
    private int jumpsCount = 0;
    public int jumpsMax;
    public GameObject gouttePrefab;
    public float delayGoutte;
    private float cptGoutte;
    private Vector3 defaultPosition;
    public float jetPackHeat = 0f;
    public float jetPackMaxHeat = 300;
    public float jetPackHeatCount = 0.5f;
    public float jetPackSpeed;
    //public Vector3 flyVelocity;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public JetPackBar heatBar;
    bool facingRight =  true;
    bool IsMoving = true;
    public Animator animator;
    public int reSpawnTime = 2;
    public GameObject bodyRotate;
    public Rigidbody rb;
    public bool playerIsDead = false;
    public int lives = 1;
    // public GameObject respawnPosition;
    private void Awake() {
        controller = GetComponent<CharacterController>();
        if (controller == null){
            Debug.LogError("Character Controller not found.");
            enabled = false;
        }
        cptGoutte = delayGoutte;
        defaultPosition = transform.position;
    }
    void Start() { 
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setLives(lives);
        heatBar.setMaxJetPack(jetPackMaxHeat);
        mouvement.y = 0;
    }
    void Update() {
        //allAnimation();
        // CONTROLS
        if (controller == null)
            return;
        mouvement.x = Input.GetAxisRaw("Horizontal");
        // Debug.Log(mouvement.x);
        mouvement.y -= gravity * Time.deltaTime;
        if(mouvement.x>0){
             bodyRotate.transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        if(mouvement.x<0 && facingRight){
            flip();
        }else if(mouvement.x>0&& !facingRight){
            flip();
        }
        if(controller.isGrounded){
              
            // mouvement.y = 0;
            jumpsCount = 0;
            // gameObject.GetComponentInChildren<ParticleSystem>.isPlaying = false;
            // jetPackFuel++;
            // Debug.Log(jetPackFuel);

        } 
        if (mouvement.x == 0){
            animator.SetBool("Move", false);
        }
        if(mouvement.x != 0){
             animator.SetBool("Move", true);
        }
        // this didn't work: if(Input.GetButtonDown("Jump")){
        if(Input.GetKeyDown(KeyCode.Z)){
                if(jumpsCount == 0){
                mouvement.y = jumpSpeed;
                animator.SetBool("jump", true);
                jumpsCount++;
                }
    
        }
         if(Input.GetKeyUp(KeyCode.Z)){
            animator.SetBool("jump", false);

        }
        controller.Move(mouvement * Time.deltaTime * speed);
        // Création des gouttes quand MeatBoy court:
        if(mouvement.x != 0f){
            IsMoving = true;
            cptGoutte -= Time.deltaTime;

        }
        heatBar.setJetPack(jetPackHeat);
    }
    public void Die(){
        controller.enabled = false;
        animator.SetBool("Death", true);
        mouvement.y = 0;
        mouvement.x = 0;
        // Destroy(gameObject);
        Invoke("MoveBody", reSpawnTime);
        playerIsDead = true;
        healthBar.setLives(lives);
        if(lives <= 0){
            Debug.LogError("die");
            SceneManager.LoadScene("Menu");
            // LevelManager levelmanager = GetComponent<LevelManager>();
            // levelmanager.restart();
        }
        // Debug.LogError("die");
    }
    public void MoveBody(){
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth);
        controller.enabled = true;
        animator.SetBool("Death", false);
        playerIsDead = false;

    }
    public void Fly(){
        // gameObject.GetComponentInChildren<ParticleSystem>.isPlaying = true;
         mouvement.y = jetPackSpeed;
        if(jetPackHeat > jetPackMaxHeat && !controller.isGrounded){
            mouvement.y = 0 - gravity/10;
        }
        if(mouvement.x == 0 ){
            animator.SetBool("lift", true);
        }

    }
    public void SuperSpeed(){
        mouvement.y -= gravity * Time.deltaTime;
        controller.Move(mouvement * Time.deltaTime * jetPackSpeed);
    }
    public void TakeDamage(int damage){
        Instantiate(gouttePrefab, transform.position, Quaternion.identity);
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if(currentHealth<=0){
            countLives();
            Die();
        }
    }
    void flip(){
        facingRight = !facingRight;
        bodyRotate.transform.Rotate(0f,180f,0f);
        // this.gameObject.transform.rotation = Quaternion.Euler(0f,180f,0f);
    }
    public void countLives(){
        lives--;
    }

}
