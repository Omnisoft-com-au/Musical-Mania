using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerStartPosition : MonoBehaviour
{
    public OVRPose trackerPose = OVRPose.identity;

   
    void Awake()
    {
        OVRCameraRig rig = GameObject.FindObjectOfType<OVRCameraRig>();

        if (rig != null) 
        {
            rig.UpdatedAnchors += OnUpdatedAnchors;
        }

        void OnUpdatedAnchors(OVRCameraRig rig) 
        {
            if (!enabled) 
            {
                return;
            }

            OVRPose pose = rig.trackerAnchor.ToOVRPose(true).Inverse();
            pose = trackerPose * pose;
            rig.trackingSpace.FromOVRPose(pose, true);
        }
    }

    
}
