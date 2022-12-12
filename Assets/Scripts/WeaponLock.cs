using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLock : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public Vector3 offSet;

    RaycastHit hit;
 
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,obstacleLayer))
        {
            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offSet);
        }
    }
}
