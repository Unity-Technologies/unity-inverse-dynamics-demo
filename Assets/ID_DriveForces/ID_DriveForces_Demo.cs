using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;

public class ID_DriveForces_Demo : MonoBehaviour
{
    private List<GameObject> spheres = new List<GameObject>();
    private Vector3 spawnPoint = new Vector3(0, 3, 0);

    public Text weightValue;

    private ArticulationBody ab;

    void Start()
    {
        ab = transform.GetComponent<ArticulationBody>();
    }


    void FixedUpdate()
    {
        weightValue.text = (-ab.driveForce[0] / Physics.gravity.y - ab.mass).ToString("F2") + " kg";
    }

    public void OnClickAddSphere()
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localPosition = spawnPoint;
        var rb = sphere.AddComponent<Rigidbody>();
        rb.transform.localScale = Vector3.one * 0.3f;
        spheres.Add(sphere);
    }

    public void OnClickDestroySphere()
    {
        if (spheres.Count <= 0)
            return;
        Destroy(spheres[spheres.Count-1]);
        spheres.RemoveAt(spheres.Count-1);
    }
}
