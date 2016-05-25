using UnityEngine;
using System.Collections;
using System;

public class NewEnemy : MonoBehaviour, IDamageable
{
    public float TurnAwayDistance = 1.0f;
    public float TurnAroundTimer = 1;
    public float Speed;

    public bool DoesItWalk;
    public bool m_OnGround;

    public float SecondsPerDamage = .5f;

    GameObject target = null;

    Rigidbody m_Rigid;

    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int m_MaxHealth;

    private bool m_Alive = true;

    public bool Alive
    {
        get
        {
            return m_Alive;
        }

        set
        {
            m_Alive = value;
        }
    }

    public int Health
    {
        get
        {
            return m_Health;
        }

        set
        {
            if (value > MaxHealth)
                value = MaxHealth;

            m_Health = value;

            if (Health <= 0)
                OnDeath();
        }
    }

    public int MaxHealth
    {
        get
        {
            return m_MaxHealth;
        }

        set
        {
            if (value <= 0)
                MaxHealth = 1;

            if (Health > value)
                Health = value;

            m_MaxHealth = value;

        }
    }

    public void OnDeath()
    {
        //GetComponent<Collider>().enabled = false;
        Alive = false;
        StopAllCoroutines();
        StartCoroutine("Death");
    }
  
    public void TakeDamage(GameObject other)
    {
        Vector3 a = new Vector3(other.transform.forward.x, 0, 0);
           m_Rigid.AddForce(other.transform.forward.x * 2, 3, 0, ForceMode.Impulse);
        //ForceMode.Impulse
        Health--;
    }




    void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.forward * 0.1f), Vector3.down, out hit, .12f))
        {
            m_OnGround = true;
        }
        else { m_OnGround = false;  }
    }
    void Start()
    {
        StartCoroutine("TurningTimer");
        Health = m_Health;
        MaxHealth = m_MaxHealth;
        transform.forward = new Vector3(1, 0, 0);

        m_Rigid = GetComponent<Rigidbody>();
        m_Rigid.freezeRotation = true;

    }
    void FixedUpdate()
    {

        CheckGround();

        if (target != null)
            HandleChase();
        else HandlePatrol();



    }
    void HandlePatrol()
    {

        if (!m_OnGround && DoesItWalk || !Alive)
            return;
        
       
        Vector3 pos = m_Rigid.position;

        pos.x += transform.forward.x * Speed * Time.deltaTime;
        m_Rigid.MovePosition(pos);
        
    }
    void HandleChase()
    {
        if (!Alive)
            return;
       
        Vector3 pos = m_Rigid.position;
        Vector3 dirToPlayer = Vector3.Normalize(new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z) - transform.position);

        transform.forward = dirToPlayer;

        dirToPlayer.z = 0; ///Keeps the game in 2D movement
        if (DoesItWalk)
        {
            dirToPlayer.y = 0;
            transform.forward = dirToPlayer;
            pos.x += transform.forward.x * Speed *Time.deltaTime;
        }
        else
        {
            
            transform.forward = dirToPlayer;
            pos += transform.forward * Speed * Time.deltaTime;
        }
        m_Rigid.MovePosition(pos);
    }

    IEnumerator TurningTimer()  // Hit Delay
    {

        while (true)
        {

            yield return new WaitForSeconds(TurnAroundTimer);

            transform.forward = -transform.forward;
        }

    }
    void OnCollisionEnter(Collision c)
    {

        if (c.collider.GetComponent<IDamageable>() != null && c.collider.gameObject.tag == "Player")
        {
            StartCoroutine("Hit", c.collider.GetComponent<IDamageable>());
           
        }
        //if(c.collider.gameObject.tag != "Player")
        //{
        //    transform.forward = -transform.forward;
        //}
    }
    void OnCollisionExit(Collision c)
    {
        if (c.collider.GetComponent<IDamageable>() != null && c.collider.gameObject.tag == "Player")
        {
            StopCoroutine("Hit");
        }
    }


    IEnumerator Death() 
    {
        Alive = false;
     
        foreach (Collider c in GetComponents<Collider>())
            c.enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Animator>().SetTrigger("Death");
        StopCoroutine("TurningTimer");

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
       
    }
    IEnumerator Hit(IDamageable d)  
    {
        while(true)
        {                    
            d.TakeDamage(gameObject);          
            yield return new WaitForSeconds(SecondsPerDamage);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && c.gameObject.GetComponent<IDamageable>() != null)
        {
            StopCoroutine("TurningTimer");
            target = c.gameObject;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.gameObject == target)
        {
            StartCoroutine("TurningTimer");
            target = null;
        }

        transform.forward = new Vector3(transform.forward.x, 0, 0);
    }
}
