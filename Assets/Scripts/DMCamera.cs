/*
[Documentation]
To set up a camera:
    1) Create an empty gameobject named Camera.
    2) Attach this script to it.
    3) Create a new camera and make it a child of Camera.
    4) Tag the child as MainCamera.
*/

using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class DMCamera : MonoBehaviour
{
    Transform followTarget;
    Transform cameraChild;
    Vector3 leftBoundary, rightBoundary;
    public float smoothing = 2f;

    public float FOV;
    //temporary FOV fix
    //this represents the difference between unity's FOV and this FOV.
    //We add this to Camera.main.fieldOfView to make them the same.

    //Only if unity's FOV is set to 60,
    //unity FOV needs to subtract 38.7 to be the same as this FOV.
    //this FOV needs to add 27 to be the same as unity FOV.
    float tempFOVfix = 27.0f;    

    Vector3 DirectionFromAngle(float angleInDegrees)
    {
        //                                          //convert to radians
        //float RightBoundAngle = (90 - (FOV / 2)) * (Mathf.PI / 180);
        //float leftBoundAngle = (90 + (FOV / 2)) * (Mathf.PI / 180);

        //add the transform's rotation so that the angles are relative
        angleInDegrees += cameraChild.eulerAngles.y;

        // have to switch sin() and cos() because Unity's unit circle is set back 90 degrees
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void Start()
    {
        //track player for camera scrolling
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        cameraChild = transform.GetChild(0);

        FOV = Camera.main.fieldOfView + tempFOVfix;
        FOV = (FOV * FOV) / tempFOVfix;
    }

    void Update()
    {
        Vector3 followTargetDir = Vector3.Normalize(followTarget.position - transform.position);
        //followTargetDir.y = transform.position.y;

        //determine field of view angles
        leftBoundary = DirectionFromAngle(-FOV / 2);
        rightBoundary = DirectionFromAngle(FOV / 2);

        /////Draw FOV lines
        Debug.DrawLine(cameraChild.position, cameraChild.position + leftBoundary * 25, Color.red);
        Debug.DrawLine(cameraChild.position, cameraChild.position + rightBoundary * 25, Color.blue);
        Debug.DrawLine(transform.position, transform.position + followTargetDir * 25, Color.white);

        float angleToEdgeL = Vector3.Dot(followTargetDir, leftBoundary);
        float angleToEdgeR = Vector3.Dot(followTargetDir, rightBoundary);

        if (angleToEdgeL >= 0.99f || angleToEdgeR >= 0.99f)
        {
            Debug.DrawLine(transform.position, transform.position + followTargetDir * 10.0f, Color.black);
            transform.position = Vector3.Lerp(transform.position, transform.position +
                                             (followTarget.forward * 5.3f), Time.deltaTime * smoothing);
        }

        //transform.position = Vector3.Lerp(transform.position, transform.position + ((followTarget.position - transform.position).normalized * smoothing), Time.deltaTime * smoothing);
        //MoveCamera(camToTargetAngle2);
    }
}
