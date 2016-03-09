using UnityEngine;
using System.Collections;

public class InputHandler : Singleton<MonoBehaviour>
{

    [SerializeField] GameObject WeaponA;


    public float speed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float jumpHeight = 5.0f;
    Vector3 direction;

    [SerializeField] KeyCode Left = KeyCode.A;
    [SerializeField] KeyCode Right = KeyCode.D;
    [SerializeField] KeyCode Up = KeyCode.W;
    [SerializeField] KeyCode Down = KeyCode.S;

    [SerializeField] KeyCode K = KeyCode.K;

    [SerializeField] KeyCode Jump = KeyCode.Space;
    bool onGround = true;

    Rigidbody m_Rigid;
    
    void Start()
    {
        m_Rigid = gameObject.GetComponent<Rigidbody>();

        m_Rigid.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void Update()
    {
        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

        if (onGround)
        {
            if (Input.GetKey(Right))
            {
                gameObject.transform.forward = new Vector3(0, 0, 1);
                velocity.x = speed ;
            }

            else if (Input.GetKey(Left))
            {
                gameObject.transform.forward = new Vector3(0, 0, -1);
               velocity.x = -speed ;
            }
            else velocity.x = 0;
            if(Input.GetKey(Jump))
            {
                
                velocity.y = jumpHeight;
            }

            if (Input.GetKey(K))
                Attack(true);
            else
            {
                Attack(false);
            }
        }




        gameObject.GetComponent<Rigidbody>().velocity = velocity;
    }


    void Attack(bool state)
    {
   
      if(WeaponA.GetComponent<DamagingObject>())
        {
            WeaponA.GetComponent<DamagingObject>().active = state;
        }



    }

}
