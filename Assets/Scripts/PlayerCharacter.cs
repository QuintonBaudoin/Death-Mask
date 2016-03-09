using UnityEngine;
using System.Collections;
using System;

public class PlayerCharacter : MonoBehaviour,IHealth
{


    public float m_Speed = 5.0f;
   // public float m_jumpSpeed = 5.0f;
    public float m_JumpPower = 5.0f;


   
    bool m_OnGround;
    bool m_Orouch;


    Rigidbody m_Rigid;

    [SerializeField]
    GameObject m_WeaponA;


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
        if (movement != 0)
        {
            Vector3 forward = gameObject.transform.forward;
            forward.z = movement;
       
        gameObject.transform.forward = forward;
        }
        Vector3 vel = m_Rigid.velocity;
        vel.x = movement;
        m_Rigid.velocity = vel;
    }
    void HandleJump(bool jump)
    {
       if(m_OnGround && jump)
        {
            Vector3 vel = m_Rigid.velocity;

            vel.y = m_JumpPower;

            m_Rigid.velocity = vel;
        }
             
    }
    void HandleAttack(bool attack)
    {
        if (m_WeaponA.GetComponent<DamagingObject>())
        {
            m_WeaponA.GetComponent<DamagingObject>().active = attack;
        }
    }



    void CheckForGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, (gameObject.GetComponent<CapsuleCollider>().height/2) + .05f))
        {
            m_OnGround = true;
        }
        else m_OnGround = false;
    }

 

    public void ModifyHealth(int damage)
    {
        throw new NotImplementedException();
    }

    public int ReturnHealth()
    {
        throw new NotImplementedException();
    }
}
