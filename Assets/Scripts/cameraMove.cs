using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject target;
    public Vector3 distance;
    public Space offsetPositionSpace = Space.Self;
    public bool lookAt = true;    

    void Start()
    {
        
    }
    private void LateUpdate()
    {        

        if (offsetPositionSpace == Space.Self)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.TransformPoint(distance), Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + distance, Time.deltaTime);
        }
        if (lookAt)
        {
            transform.LookAt(target.transform);
        }
        else
        {
            transform.rotation = target.transform.rotation;
        }
    }
}
