/*
To set up a camera:
    1) Create an empty gameobject named Camera.
    2) Attach this script to it.
    3) Create a new camera and make it a child of Camera.
    4) Tag the child as MainCamera.
*/

using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class DMCamera : MonoBehaviour
{
    Transform followTarget;
    Transform cameraChild;
    Vector3 leftBoundary, rightBoundary;

    public float smoothing = 2f;

    float FOV;
    //temporary FOV fix
    //this represents the difference between unity's FOV and this FOV.
    //We add this to Camera.main.fieldOfView to make them the same.

    //Only if unity's FOV is set to 60,
    //unity FOV needs to subtract 38.7 to be the same as this FOV.
    //this FOV needs to add 27 to be the same as unity FOV.
    float tempFOVfix = 27.0f;

    //void MoveCamera(float differenceAngle)
    //{
    //    Debug.Log(differenceAngle);
    //    transform.position = Vector3.Lerp(transform.position, transform.position + 
    //                                     (followTarget.forward * differenceAngle * 0.2f), 
    //                                      Time.deltaTime * smoothing);
    //}
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
        Vector3 followTargetDir = Vector3.Normalize(followTarget.position - transform.position);
        followTargetDir.y = transform.position.y;

        ///Draw FOV lines
        //Debug.DrawLine(transform.position, transform.position + rightBoundary * 25, Color.red);
        //Debug.DrawLine(transform.position, transform.position + leftBoundary * 25, Color.red);
        //Debug.DrawLine(transform.position, transform.position + followTargetDir * 25, Color.white);

        float angleToEdgeR = Vector3.Dot(followTargetDir, rightBoundary);
        float angleToEdgeL = Vector3.Dot(followTargetDir, leftBoundary);
        //float camToTargetAngle = Vector3.Angle(followTargetDir, cameraChild.forward);

        //Vector3 newCamPos = followTarget.position - transform.position;
        //Debug.Log("newCamPos: " + newCamPos);
        //Debug.Log("followTargetForward: " + followTarget.forward);
        //newCamPos.x = newCamPos.x * followTarget.forward.x;
        //newCamPos.y = newCamPos.y * followTarget.forward.y;
        //newCamPos.z = newCamPos.z * followTarget.forward.z;

        if (angleToEdgeL >= 0.99f || angleToEdgeR >= 0.99f)
        {
            //Debug.DrawLine(transform.position, transform.position + followTargetDir * 10.0f, Color.black);
            transform.position = Vector3.Lerp(transform.position, transform.position + 
                                             (followTarget.forward * 5.3f), Time.deltaTime * smoothing);
        }
            
        //transform.position = Vector3.Lerp(transform.position, transform.position + ((followTarget.position - transform.position).normalized * smoothing), Time.deltaTime * smoothing);
        //MoveCamera(camToTargetAngle2);

    }

}
