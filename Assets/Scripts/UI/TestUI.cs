using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    public Canvas UICanvas;

    public void ButtonTest()
    {
        print("Button Pressed");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleUI(); 
    }

    public void ToggleUI() 
    {
        if (!UICanvas.enabled & OVRInput.GetDown(OVRInput.RawButton.X))
        {
            UICanvas.enabled = true;
        }

        else if (UICanvas.enabled & OVRInput.GetDown(OVRInput.RawButton.X))
        {
            UICanvas.enabled = false;
        }
    }
}
