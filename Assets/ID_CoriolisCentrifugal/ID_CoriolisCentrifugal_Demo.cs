using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ID_CoriolisCentrifugal_Demo : MonoBehaviour
{
    public Text statusOutput;
    public Text currentSpeedOutput;
    public ArticulationBody targetAB;
    public ArticulationBody motorAB;

    private void Start()
    {
        currentSpeedOutput.text = "Current Speed: " + motorAB.xDrive.targetVelocity;
    }

    void FixedUpdate()
    {
        List<float> results = new List<float>();
        List<int> indices = new List<int>();

        targetAB.GetJointCoriolisCentrifugalForces(results);
        targetAB.GetDofStartIndices(indices);

        statusOutput.text = "Coriolis/Centrifugal\nForce: \n" + (-results[indices[targetAB.index]]).ToString("F2") + " N";
    }

    public void OnClickIncrease()
    {
        if (motorAB.xDrive.targetVelocity >= 600)
            return;
        ArticulationDrive tempDrive = motorAB.xDrive;
        tempDrive.targetVelocity += 25;
        motorAB.xDrive = tempDrive;
        currentSpeedOutput.text = "Current Speed: " + motorAB.xDrive.targetVelocity;
    }

    public void OnClickDecrease()
    {
        if (motorAB.xDrive.targetVelocity <= -600)
            return;
        ArticulationDrive tempDrive = motorAB.xDrive;
        tempDrive.targetVelocity -= 25;
        motorAB.xDrive = tempDrive;
        currentSpeedOutput.text = "Current Speed: " + motorAB.xDrive.targetVelocity;
    }
}
