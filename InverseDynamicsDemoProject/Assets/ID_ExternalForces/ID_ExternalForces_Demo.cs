using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ID_ExternalForces_Demo : MonoBehaviour
{
    [SerializeField]
    ArticulationBody m_Root;

    [SerializeField]
    Vector3 m_WindForce;

    List<ArticulationBody> m_Bodies = new List<ArticulationBody>();

    [SerializeField]
    bool b_ApplyExternalForces;

    [SerializeField]
    Text m_ExternalStatus;
    [SerializeField]
    Text m_ButtonText;

    List<float> m_ExternalForces = new List<float>();
    List<float> m_ZeroList = new List<float>();

    void Start()
    {        
        m_Root.GetJointExternalForces(m_ExternalForces, Time.fixedDeltaTime);
        m_ButtonText.text = "Apply Forces: " + b_ApplyExternalForces;

        // We populate a list with 0s to reset the forces added later
        for (int i = 0; i < m_ExternalForces.Count; i++)
        {
            m_ZeroList.Add(0);
        }
    }

    void FixedUpdate()
    {
        // We apply the force here and clear the list, to ensure that all the forces were added
        // only once and were added before we call GetJointExternalForces
        foreach (var body in m_Bodies)
        {
            body.AddForce(m_WindForce * Time.fixedDeltaTime* Random.Range(0.75f, 1.25f));
        }
        m_Bodies.Clear();

        m_Root.GetJointExternalForces(m_ExternalForces, Time.fixedDeltaTime);

        float sum = 0;

        for (int i = 0; i < m_ExternalForces.Count; i++)
        {
            sum += m_ExternalForces[i];
        }

        m_ExternalStatus.text = "Total External Forces: " + sum.ToString("F2");

        if (b_ApplyExternalForces)
            m_Root.SetJointForces(m_ExternalForces);
        else
        {
            m_Root.SetJointForces(m_ZeroList);
        }
    }

    public void ToggleApplyForces()
    {
        b_ApplyExternalForces = !b_ApplyExternalForces;
        m_ButtonText.text = "Apply Forces: " + b_ApplyExternalForces;
    }

    private void OnTriggerStay(Collider other)
    {
        // We collect the bodies that are in our trigger zone, but don't apply the force yet
        ArticulationBody ab = other.GetComponentInParent<ArticulationBody>();

        if (ab != null)
        {
            if (!m_Bodies.Contains(ab))
                m_Bodies.Add(ab);
        }
    }
}
