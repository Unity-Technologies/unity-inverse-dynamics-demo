using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_Gravity_Demo : MonoBehaviour
{
    public GameObject AB_Link;
    public GameObject AB_Root;
    private Transform lastAddedLink;

    private List<ArticulationBody> bodies = new List<ArticulationBody>();
    
    void Start()
    {
        lastAddedLink = AB_Root.transform.GetChild(0);
        bodies.Add(lastAddedLink.GetComponent<ArticulationBody>());
    }

    public void OnClickAddLink()
    {
        List<ArticulationReducedSpace> positions = new List<ArticulationReducedSpace>();
        for (int i = 0; i < bodies.Count; i++)
        {
            positions.Add(bodies[i].jointPosition);
        }
        lastAddedLink = Instantiate(AB_Link, lastAddedLink).transform;
        
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].jointPosition = positions[i];
        }
        
        bodies.Add(lastAddedLink.GetComponent<ArticulationBody>());
    }

    public void OnClickRemoveLink()
    {
        if (bodies.Count <= 1)
            return;
        
        List<ArticulationReducedSpace> positions = new List<ArticulationReducedSpace>();
        for (int i = 0; i < bodies.Count; i++)
        {
            positions.Add(bodies[i].jointPosition);
        }

        Destroy(lastAddedLink.gameObject);
        lastAddedLink = lastAddedLink.parent;
        
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].jointPosition = positions[i];
        }
        
        bodies.RemoveAt(bodies.Count-1);
    }
}
