using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Test : MonoBehaviour
{

    public Transform PlayerTransform;
    public Transform CameraTransform;
    [SerializeField]
    private Vector3 PlayerPosition;
    public Vector3 CameraPosition;
    public Vector3 CameraToPlayer;


    public float FOV;
    public Vector3 RightBoundary
    {
        get
        {

            float theta = 90 - (FOV / 2);
            theta = theta * (Mathf.PI / 180);
            return new Vector3(Mathf.Cos(theta), 0.0f, Mathf.Sin(theta));
        }
    }
    public Vector3 LeftBoundary
    {
        get
        {
            float theta = 90 + (FOV / 2); //120 if fov 60
            theta = theta * (Mathf.PI / 180);  //120 / 180 = 6/9 = 2/3 = .666666
            return new Vector3(Mathf.Cos(theta), 0.0f, Mathf.Sin(theta));
        }

    }


    public Vector3 LBInspector, RBInspector;

    public float RDot;
    public float LDot;
    public Vector3 RBDrawPos, LBDrawPos, PlayerDrawPos;
    
    [ExecuteInEditMode]
    void Update()
    {


        LBInspector = LeftBoundary;
        RBInspector = RightBoundary;

        PlayerPosition = PlayerTransform.position;
        CameraPosition = CameraTransform.position;

        //direction from the camera to the player
        CameraToPlayer = (PlayerPosition - CameraPosition).normalized;

        RBDrawPos = CameraPosition + RightBoundary * 10;
        LBDrawPos = CameraPosition + LeftBoundary * 10;
        PlayerDrawPos = PlayerPosition + CameraToPlayer * 10;

        Debug.DrawLine(CameraPosition, PlayerDrawPos, Color.blue);
        Debug.DrawLine(CameraPosition, RBDrawPos, Color.red);
        Debug.DrawLine(CameraPosition, LBDrawPos, Color.green);
        RDot = Vector3.Dot(RightBoundary, CameraToPlayer);
        LDot = Vector3.Dot(LeftBoundary, CameraToPlayer);
        if (RDot >= .999999 || LDot >= .999999)
            Debug.DrawLine(CameraPosition, PlayerPosition * 10.0f, Color.black);








    }


}
