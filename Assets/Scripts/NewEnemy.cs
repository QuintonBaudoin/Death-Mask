using UnityEngine;
using System.Collections;
using System;

public class NewEnemy : MonoBehaviour, IDamageable
{
    public float TurnAwayDistance = 1.0f;
    public float TurnAroundTimer = 1;
    public float Speed;

    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int m_MaxHealth;

    private bool m_Alive;
  
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
        GetComponent<Collider>().enabled = false;
        StartCoroutine("Death");
    }

    public void TakeDamage()
    {
        Health--;
    }

    /*
    
        ineed to make a path likeness.

        i want to avoid tags(obvy)

        i wana avoid too much numbers and not have any 
        visual feedback to user
        
        avoid the need for colliders ( thats just jank using one (if i do it will be on a trigger))
        
        maybe not?

        Zacs hitting things may not have been that bad an idea... 

        maybe checking for ground infront of him?


        hit a wall turn around Oh! 

        if i hit an object that doesnt have damager on 
        turn around. if not continue forward.

        but what about holes... 

        What if i used erics pathfinding idea?
        nah that one sucked monkey ducks..

        how about i do some shit?>

        lets see... 

          []->  {"not a player"}
            []->{"not a player"}   shoot ray infront. if hit isnt a player turn around 
          <-[]  {"not a player"}
        <-[]    {"not a player"}
    */

    void CheckFront()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, TurnAwayDistance))
        {
            if(hit.collider.gameObject.tag != "Player")
            transform.forward = -transform.forward;
        }

    }
    void Start ()
    {
        StartCoroutine("TurningTimer");
        Health = m_Health;
        MaxHealth = m_MaxHealth;
        transform.forward = new Vector3(1, 0, 0);
        GetComponent<Rigidbody>().freezeRotation = true;

	}		
	void Update()
    {

        CheckFront();
        Rigidbody Rigid = GetComponent<Rigidbody>();

        Vector3 vel = Rigid.velocity;

        vel.x = transform.forward.x * Speed;

        GetComponent<Rigidbody>().velocity = vel;




	}
    IEnumerator TurningTimer()
    {

        while(true)
        {

            yield return new WaitForSeconds(TurnAroundTimer);

            transform.forward = -transform.forward;
        }
        
    }
    void OnCollision(Collision c)
    {
        if (c.collider.GetComponent<IDamageable>() != null && c.collider.gameObject.tag == "Player")
            c.collider.GetComponent<IDamageable>().TakeDamage();
    }
    IEnumerator Death()
    {
        GetComponent<Animator>().SetTrigger("Death");

        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
