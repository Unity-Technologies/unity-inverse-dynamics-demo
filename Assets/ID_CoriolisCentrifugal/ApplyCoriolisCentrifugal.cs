using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCoriolisCentrifugal : MonoBehaviour
{
    public bool applyForce = false;
    private ArticulationBody[] abs;
    void Start()
    {
        abs = FindObjectsOfType<ArticulationBody>();
    }
    
    
    void FixedUpdate()
    {
        if (!applyForce)
        {
            for (int i = 0; i < abs.Length; i++)
            {
                abs[i].jointForce = new ArticulationReducedSpace(0);
            }

            return;
        }

        List<float> results = new List<float>();
        List<int> indices = new List<int>();
        
        abs[0].GetJointCoriolisCentrifugalForces(results);
        abs[0].GetDofStartIndices(indices);

        for (int i = 0; i < abs.Length; i++)
        {
            // Since all joints in this articulation only have 1 DoF we can get away with writing it like this
            abs[i].jointForce = new ArticulationReducedSpace(results[indices[abs[i].index]]);
        }
    }
}
