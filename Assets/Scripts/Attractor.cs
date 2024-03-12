using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float G = 6.674f;

    public static List<Attractor> pAttrac;
       

    void Attract(Attractor other)
    {
        Rigidbody rb2 = other.rb;

        //F = G(m1*m2)/r^2
        Vector3 direction = rb.position - rb2.position;

        //find distance between 2 obj from Vector3
        float distance = direction.magnitude;

        // Calculate Magnitude
        float forceMagnitude = G * (rb.mass * rb2.mass) / Mathf.Pow(distance, 2);

        // Calculate Vector3
        Vector3 finalForce = forceMagnitude * direction.normalized;

        // Add Force
        rb2.AddForce(finalForce);
    }

    private void OnEnable()
    {
        if (pAttrac == null)
        {
            pAttrac = new List<Attractor>();
        }

        pAttrac.Add(this);
    }

    void FixedUpdate()
    {
        foreach (var ATT in pAttrac)
        {
            if (ATT != this)
            {
                Attract(ATT);
            }
        }
    }
}
