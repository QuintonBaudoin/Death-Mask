using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class DMCamera : MonoBehaviour
{    
    public float offset;
    [Header("Lock to axis (select only one)")]
    public bool xAxis;
    public bool yAxis;
    public bool zAxis;

    Transform followTarget;
    Transform cameraChild;

    public float leftDistance = 3f;
    public float rightDistance = 10f;
    public float followSpeed = 1f;
    public float smoothing = 2f;
    Vector3 leftBoundary, rightBoundary;

    float FOV;
    /// temporary FOV fix
    //this represents the difference between unity's FOV and this FOV.
    //We add this to Camera.main.fieldOfView to make them the same.
    float tempFOVfix = 27.0f;   //only if unity's FOV is set to 60.
    //unity FOV needs to subtract 38.7 to get be the same as this FOV.
    //this FOV needs to add 27 to be the same as unity FOV.


    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        cameraChild = transform.GetChild(0);
        
        FOV = Camera.main.fieldOfView + tempFOVfix;
        //FOV = (FOV * FOV) / tempFOVfix;
        //determine field of view angles
        float RightBoundAngle = (90 - (FOV / 2)) * (Mathf.PI / 180);
        float leftBoundAngle = (90 + (FOV / 2)) * (Mathf.PI / 180);

        rightBoundary = new Vector3(Mathf.Cos(RightBoundAngle), 0, Mathf.Sin(RightBoundAngle) * cameraChild.forward.z);
        leftBoundary = new Vector3(Mathf.Cos(leftBoundAngle), 0, Mathf.Sin(leftBoundAngle) * cameraChild.forward.z);
    }

    void Update()
    {
        #region dotStuff
        //We want to calc some threshhold and use the dotproduct to determine if an object has reached the edge of the screen
        //that threshhold will the the direction vector calculated from the cameras field of view
        //given the fov, calculate the direction vector by (fov/2) + x = 90 or x = 90 - (fov/2)
        //alternatively we can use the parall
        //float Rangle = (180 - Camera.main.fieldOfView) / 2;
        //Rangle = Rangle * (Mathf.PI / 180); //convert to rads
        //float Langle = 180 - Camera.main.fieldOfView;
        //Langle = Langle * (Mathf.PI / 180);

        //Vector3 screenEdgeR = new Vector3(Mathf.Cos(Rangle), 0, Mathf.Sin(Rangle) * -1);
        //Vector3 screenEdgeL = new Vector3(Mathf.Cos(Langle), 0, Mathf.Sin(Langle)* -1);
        #endregion

        Vector3 followTargetDir = Vector3.Normalize(followTarget.position - transform.position);
        followTargetDir.y = transform.position.y;

        Debug.DrawLine(transform.position, transform.position + rightBoundary * 25, Color.red);
        Debug.DrawLine(transform.position, transform.position + leftBoundary * 25, Color.red);
        Debug.DrawLine(transform.position, transform.position + followTargetDir * 25, Color.white);

        float angleToEdgeR = Vector3.Dot(followTargetDir, rightBoundary);
        float angleToEdgeL = Vector3.Dot(followTargetDir, leftBoundary);

        Debug.Log("angleToEdgeR: " + angleToEdgeR);
        Debug.Log("angleToEdgeL: " + angleToEdgeL);

        if (angleToEdgeL >= 0.99f || angleToEdgeR >= 0.99f)
        {
            Debug.DrawLine(transform.position, transform.position + followTargetDir * 10.0f, Color.black);
            transform.position = Vector3.Lerp(transform.position, transform.position + followTarget.position, Time.deltaTime * smoothing);
        }
    }

}
