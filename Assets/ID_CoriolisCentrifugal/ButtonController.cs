using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Text toggleButtonText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleApplyForce()
    { 
        ApplyCoriolisCentrifugal applyScript = FindObjectOfType<ApplyCoriolisCentrifugal>();

        applyScript.applyForce = !applyScript.applyForce;

        toggleButtonText.text = "Toggle counteracting: " + applyScript.applyForce;
    }
    
}
