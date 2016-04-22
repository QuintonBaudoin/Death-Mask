using UnityEngine;
using System.Collections;
using System;

public class PlayerCharacter : MonoBehaviour, IDamageable
{

    [SerializeField]
    private int _Health= 1;
    [SerializeField]
    private int _MaxHealth = 1;
    [SerializeField]

    private int _Lives = 1;
    private bool _Alive = true;
   

    public float m_Speed = 5.0f;
    public float m_CurrentSpeed;

    float CapsuleHeight;
    Vector3 CapsuleCenter;

    // public float m_jumpSpeed = 5.0f;
    public float m_JumpPower = 5.0f;
    bool m_OnGround;
    bool m_Orouch;
    Rigidbody m_Rigid;

    [SerializeField]
    public GameObject m_WeaponA;

    public int Health
    {
        get
        {
            return _Health;
        }

        set
        {
            if (value > MaxHealth)
                value = MaxHealth;
            _Health = value;

            if (Health <= 0)
                Lives--;

            if (GUIManager.Instance != null)
                GUIManager.Instance.UpdateHealthBar(Health, MaxHealth);

        }
    }
    public int MaxHealth
    {
        get
        {
            return _MaxHealth;
        }

        set
        {
            if (value <= 0)
                value = 1;
            if (Health > value)
                Health = value;
            _MaxHealth = value;

            if (GUIManager.Instance != null)
                GUIManager.Instance.UpdateHealthBar(Health, MaxHealth);

        }
    }
    public bool Alive
    {
        get
        {
            return _Alive;
        }

        set
        {
            _Alive = value;

            if (!Alive)
                OnDeath();

        }
    }

    public int Lives
    {
        get { return _Lives; }
        set { _Lives = value; if (_Lives <= 0) NoMoreLives(); else OnDeath(); }
    }

    void Start()
    {
        CapsuleHeight = GetComponent<CapsuleCollider>().height;
        CapsuleCenter = GetComponent<CapsuleCollider>().center;

        Health = _Health;
        MaxHealth = _MaxHealth;       

        m_Rigid = gameObject.GetComponent<Rigidbody>();
        m_Rigid.constraints = RigidbodyConstraints.FreezeRotation;

    }
    void FixedUpdate()
    {
        CheckForGround();
        ResizeCapsule();
        CheckCurrentSpeed();

    }



    public void ReceiveInput(int direction, bool jump, bool attack)
    {
        if (direction > 1)
            direction = direction / direction;

        HandleMovement(direction * m_Speed);
        HandleJump(jump);
        HandleAttack(attack);



    }


    void HandleMovement(float movement)
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
            movement = 0;
        if (Mathf.Abs(movement) > 0)
        {

            GetComponent<Animator>().SetBool("moving", true);
            Vector3 forward = gameObject.transform.forward;
            forward.x = movement;
            gameObject.transform.forward = forward;
        }

        if (Mathf.Abs(movement) <= 0)
            GetComponent<Animator>().SetBool("moving", false);

        Vector3 vel = m_Rigid.velocity;
        vel.x = movement;
        vel.z = 0;

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
        { m_WeaponA.GetComponent<DamagingObject>().active = true; return; }
        if (m_WeaponA == null)
            return;

        if (m_WeaponA.GetComponent<DamagingObject>())
        {
            if (attack == true)
                GetComponent<Animator>().SetTrigger("attack");


            m_WeaponA.GetComponent<DamagingObject>().active = attack;
        }
    }

    void ResizeCapsule()
    {
        CapsuleCollider c = GetComponent<CapsuleCollider>();

        if(m_OnGround)
        {
            c.center = CapsuleCenter;
            c.height = CapsuleHeight;
        }

        else
        {
            c.height = CapsuleHeight - .23f;
            c.center = new Vector3(CapsuleCenter.x, CapsuleCenter.y - .1f, CapsuleCenter.z);
        }

    }

    void CheckCurrentSpeed()
    {
        // print(GetComponent<Rigidbody>().velocity.x + "  " + GetComponent<Rigidbody>().velocity.y + " " + GetComponent<Rigidbody>().velocity.z);


        m_CurrentSpeed = Vector3.Magnitude(m_Rigid.velocity);

        if (m_CurrentSpeed < .01)
        {
            m_CurrentSpeed = 0;
        }

    }
    void CheckForGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.forward * 0.1f), Vector3.down, out hit, .12f))
        {
            m_OnGround = true;
        }
        else m_OnGround = false;

        GetComponent<Animator>().SetBool("airborn", !m_OnGround);
    }

    

    public void TakeDamage()
    {
        Health--;
    }
    public void OnDeath()
    {  
        GameManager.PlayerRecall();
    }
    void NoMoreLives()
    {
        GameManager.ResetLevel(); 
    }

}
