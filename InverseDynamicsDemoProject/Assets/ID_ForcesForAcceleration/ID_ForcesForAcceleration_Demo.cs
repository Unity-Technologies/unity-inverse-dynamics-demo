using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ID_ForcesForAcceleration_Demo : MonoBehaviour
{
    private ArticulationBody ab;
    public float desiredAcceleration = 0.5f;
    public Slider desiredAccelerationSlider;
    public Text desiredAccelerationText;
    public Text currentAcceleration;
    public Text currentVelocity;
    public Text currentForceApplied;
    void Start()
    {
        ab = GetComponent<ArticulationBody>();
    }
    
    void FixedUpdate()
    {
        desiredAcceleration = desiredAccelerationSlider.value;
        desiredAccelerationText.text = desiredAcceleration.ToString("F2");
        List<float> gravity = new List<float>();
        List<int> indices = new List<int>();

        ab.GetJointGravityForces(gravity);
        ab.GetDofStartIndices(indices);

        ArticulationReducedSpace desired =
            new ArticulationReducedSpace(desiredAcceleration);

        var accelerationForces = ab.GetJointForcesForAcceleration(desired);

        ArticulationReducedSpace accelerationAndGravity = new ArticulationReducedSpace(accelerationForces[0] + gravity[indices[ab.index]]);
        ab.jointForce = accelerationAndGravity;

        currentAcceleration.text = "Current Acceleration:\n" + ab.jointAcceleration[0].ToString("F2") + " m/s^2";
        currentVelocity.text = "Current Velocity:\n" + ab.jointVelocity[0].ToString("F2") + " m/s";
        currentForceApplied.text = "Current Force:\n" + ab.jointForce[0].ToString("F2") + " N";
    }
}
