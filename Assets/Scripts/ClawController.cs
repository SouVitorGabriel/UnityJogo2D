using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    [Header("Configurações")]
    public float velX = 5f;

    public int vidas = 3;

    Vector3 vZero = Vector3.zero;

    Vector3 move;

    //variaveis de movimento
    bool estouParaDireita = true;
    Rigidbody2D  rigidBody2D;

    private Animator animController;

    CharacterController2D cController;

    public float Speeds = 40f;

    float horizontalMoviment = 0f;

    bool jumpp = false;
    bool crouch = false;
    void Start()
    {
        cController = GetComponent<CharacterController2D>();
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        horizontalMoviment = Input.GetAxisRaw("Horizontal") *  Speeds;

        animController.SetFloat("Speed", Mathf.Abs(horizontalMoviment));

        if(Input.GetButtonDown("Jump"))
        {
            jumpp = true;
            animController.SetBool("Jump", true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
              crouch =  true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            animController.SetBool("Attack", true);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            animController.SetBool("Attack", false);
        }
       
    }

    void FixedUpdate() 
    {
        cController.Move(horizontalMoviment * Time.deltaTime, crouch, jumpp);
        jumpp = false;
    }


    public void updateHealth(int value)
    {
        vidas = Mathf.Clamp(value + vidas, 0, 5);
        Debug.Log("Vida passou a ser: " + vidas);
    }

    public void Caii()
    {
        animController.SetBool("Jump", false);
    }

    public void Abaixando(bool estouAbaixando)
    {
        animController.SetBool("Crouch", estouAbaixando);
    }
}
