using UnityEngine;
using System.Collections;
using System;

public class PlayerCharacter : MonoBehaviour,IHealth
{


    private int Health;




    public float m_Speed = 1.0f;
   // public float m_jumpSpeed = 5.0f;
    public float m_JumpPower = 5.0f;
    bool m_OnGround;
    bool m_Orouch;
    Rigidbody m_Rigid;



    [SerializeField]
   public GameObject m_WeaponA;


   void Start()
    {
        m_Rigid = gameObject.GetComponent<Rigidbody>();
        m_Rigid.constraints = RigidbodyConstraints.FreezeRotation;
    }
   void Update()
    {
        CheckForGround();
    }
   


    public void ReceiveInput(int direction,bool jump, bool attack)
    {
        if(direction > 1)
        direction = direction / direction;

            HandleMovement(direction * m_Speed);
            HandleJump(jump);
        
        
            HandleAttack(attack);

    }


    void HandleMovement(float movement)
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
            movement = 0;
        // gameObject.GetComponent<Animator>().SetFloat("runSpeed", Mathf.Abs(movement));


        if (Mathf.Abs(movement) > 0)
        {
            //gameObject.GetComponent<Animator>().Play("run");
            GetComponent<Animator>().SetBool("moving", true);
            Vector3 forward = gameObject.transform.forward;
            forward.x = movement;
            gameObject.transform.forward = forward;
        }
           
        if(Mathf.Abs(movement) <= 0)
            GetComponent<Animator>().SetBool("moving", false);
        //gameObject.GetComponent<Animator>().Play("idle");
        Vector3 vel = m_Rigid.velocity;
        vel.x = movement;
         
        m_Rigid.velocity = vel;
    }
    void HandleJump(bool jump)
    {
       if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
           jump = false;

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("jump"))
           jump = false;

        if (m_OnGround && jump)
        {
            

            

            GetComponent<Animator>().SetTrigger("jump");
            Vector3 vel = m_Rigid.velocity;

            vel.y = m_JumpPower;

            m_Rigid.velocity = vel;
        }
             
    }
    void HandleAttack(bool attack)
    {

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
          return;
        if (m_WeaponA == null)
            return;
        
        if (m_WeaponA.GetComponent<DamagingObject>())
        {  
            if(attack == true)
            GetComponent<Animator>().SetTrigger("attack");
           

            m_WeaponA.GetComponent<DamagingObject>().active = attack;
        }
    }



    void CheckForGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hit, .12f))

        {
            m_OnGround = true;
        }
        else m_OnGround = false;
    }

 

    public void ModifyHealth(int damage)
    {
       Health--;
    }
    public int ReturnHealth()
    {
        return Health;
    }

}
