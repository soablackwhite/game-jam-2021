using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public int PlayerNumber;
    private Vector2 movementInput;
    private Rigidbody2D rb2d;
    private TwoPlayerActionControl playerActionControl;

    private Animator anim;

    public bool loss=false;
    public gameManagerScript gameManager;
    bool disappear=false;

    void Awake()
    {
        playerActionControl = new TwoPlayerActionControl();
        gameManager=FindObjectOfType<gameManagerScript>();
        anim=GetComponent<Animator>();
    }

    void OnEnable()
    {
        playerActionControl.Enable();
    }

    void OnDisable()
    {
        playerActionControl.Disable();
    }

    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if(!loss && !disappear){
            anim.SetBool("loss",false);
            if (PlayerNumber == 1)
            {
                movementInput = playerActionControl.main.Move.ReadValue<Vector2>();
            } else
            {
                movementInput = playerActionControl.secondary.Move.ReadValue<Vector2>();
            }
            
            //Debug.Log(movementInput);
            // Basic movement input
            // TODO - refactor to be able to choose what keys affect the Input axes
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");

            //Use the two store floats to create a new Vector2 variable movement.
            //Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            // Set the velocity property of our Rigidbody2D rb2d to give our player some movement.
            // Elected to use velocity instead of AddForce because AddForce feels really floaty.
            rb2d.velocity = movementInput * speed;

            //animating the socks
            if(movementInput.y<0){
                anim.SetBool("facingForward",true);
            }else if(movementInput.y>0){
                anim.SetBool("facingForward",false);
            }

            if (rb2d.velocity!=Vector2.zero){
                anim.SetBool("walking",true);
            }else{
                anim.SetBool("walking",false);
            }

            if(movementInput.x>0){
                GetComponent<SpriteRenderer>().flipX=true;
            }else if(movementInput.x<0){
                GetComponent<SpriteRenderer>().flipX=false;
            }
        }else if (!disappear){
            anim.SetBool("loss",true);
            rb2d.velocity=Vector2.zero;
        }else{
            anim.SetBool("facingForward",true);
            anim.SetBool("walking",false);
            rb2d.velocity=Vector2.zero;
            gameObject.GetComponent<SpriteRenderer>().color=new Color(1f,1f,1f,gameObject.GetComponent<SpriteRenderer>().color.a-0.05f);
        }
    }

    public void RandomizeKeys(string[] keys){
        print(playerActionControl.secondary.Get().actions[0]);
        if(PlayerNumber==1){
            for(int i=1;i<5;i++){
                playerActionControl.main.Get().actions[0].ApplyBindingOverride(i,"<Keyboard>/"+keys[i-1]);
            }
            print(playerActionControl.main.Get().actions[0]);
        }else if(PlayerNumber==2){
            for(int i=1;i<5;i++){
                playerActionControl.secondary.Get().actions[0].ApplyBindingOverride(i,"<Keyboard>/"+keys[i+3]);
            }
            print(playerActionControl.secondary.Get().actions[0]);
        }
    }
        
    public IEnumerator Shake(float duration, float magnitude){
        Transform t=GetComponentInChildren<Camera>().gameObject.transform;
        Vector3 originalPos = t.localPosition;

        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            t.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        t.localPosition = originalPos;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="sock") gameManager.victory=true;
        disappear=true;
    }    


}