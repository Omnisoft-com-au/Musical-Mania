using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;


//Justin P Barnett
//How to Teleport in Unity VR using XR Interaction Toolkit | VR Teleportation
//https://www.youtube.com/watch?v=cxRnK8aIUSI
//Works by pushing left controller thumbstick forward to show the line to target.
//When release the thumbstick you are teleported.
//To cancel press the grip button.

public class TeleportManager : MonoBehaviour
{
  
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;

    private InputAction _thumbStick;

    private bool _isActive;


    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        
        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        _thumbStick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        _thumbStick.Enable();
        //_thumbStick.Cancel();
    }


    // Update is called once per frame
    void Update()
    {
        // Find position of raycast when you release thumbstick
        if (!_isActive) 
        {
            return;
        }

        if (_thumbStick.triggered) 
        {
            return;
        }

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) 
        {
            rayInteractor.enabled = false;
            _isActive = false;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,

        };

        provider.QueueTeleportRequest(request);

    }

    void OnTeleportActivate(InputAction.CallbackContext context) 
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
