using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayJointGravityStrain : MonoBehaviour
{
    private ArticulationBody ab;
    public Text outputText;
    public float min = 25;
    public float max = 100;
    public Transform joint;
    
    private Color colorGood = Color.green;
    private Color colorBad = Color.red;
    private int fontSize = 40;
    void Start()
    {
        ab = GetComponent<ArticulationBody>();
    }
    
    void FixedUpdate()
    {
        List<float> gravity = new List<float>();
        List<int> indices = new List<int>();
        ab.GetDofStartIndices(indices);
        ab.GetJointGravityForces(gravity);

        var gravityForce = gravity[indices[ab.index]];
        float lerp = (Mathf.Abs(gravityForce) - min) / (max - min);
        float r = Mathf.Lerp(colorGood.r, colorBad.r, lerp);
        float g = Mathf.Lerp(colorGood.g, colorBad.g, lerp);
        float b = Mathf.Lerp(colorGood.b, colorBad.b, lerp);

        joint.GetComponent<Renderer>().material.color = new Color(r, g, b);
        
        outputText.color = new Color(r, g, b);
        outputText.text = gravityForce.ToString("F2");
        outputText.fontSize = fontSize + (int)Mathf.Abs(gravityForce);
    }
}
