using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    public Color rayColor;
    public float maxDistance;
    public LayerMask layersToHit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       CheckForColliders();
    }

    public void CheckForColliders()
    {
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * maxDistance, rayColor);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layersToHit, QueryTriggerInteraction.Ignore))
        {
            rayColor = Color.red;
            Debug.Log(hit.collider.gameObject.name + " Was hit");
        }
        else
        {
            rayColor = Color.green;
        }
    }
}