using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only works with Kinematic Rigidbody
//Valem Tutorials
//How to Make Physics Hands in VR - PART 1 - Unity VR Tutorial
//https://www.youtube.com/watch?v=VG8hLKyTiJQ


public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;

    private Rigidbody rb;

    //private Collider[] handCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //handCollider = GetComponentInChildren<Collider>();
    }

    void Update() 
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }
        else 
        {
            nonPhysicalHand.enabled = false;
        }

    }

    void FixedUpdate()
    {
        //Position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //Rotation
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad/ Time.fixedDeltaTime);
    }

    /*public void EnabledHandCollider() 
    {
        foreach (var item in handCollider) 
        {
            item.enabled = true;
        }
    }

    public void DisabledHandCollider()
    {
        foreach (var item in handCollider)
        {
            item.enabled = false;
        }
    }*/
}
