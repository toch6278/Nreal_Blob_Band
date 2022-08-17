/****************************************************************************
* Copyright 2019 Nreal Techonology Limited. All rights reserved.
*                                                                                                                                                          
* This file is part of NRSDK.                                                                                                          
*                                                                                                                                                           
* https://www.nreal.ai/        
* 
*****************************************************************************/

using UnityEngine;

namespace NRKernal.NRExamples
{
    /// <summary> Controls the HelloAR example. </summary>
    [HelpURL("https://developer.nreal.ai/develop/unity/controller")]
    public class HelloMRController : MonoBehaviour
    {
        /// <summary> A model to place when a raycast from a user touch hits a plane. </summary>
        public GameObject AndyPlanePrefab;

        //blob's skin 
        public GameObject blob, misc; 

        void Start()
        {
            // blob = blob.GetComponent<GameObject>; 
            misc.GetComponent<GameObject>(); 
            misc.SetActive(false);
        }
        /// <summary> Updates this object. </summary>
        void Update()
        {
            // If the player doesn't click the trigger button, we are done with this update.
            if (!NRInput.GetButtonDown(ControllerButton.TRIGGER))
            {
                return;
            }

            // Get controller laser origin.
            var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left ? ControllerAnchorEnum.LeftLaserAnchor : ControllerAnchorEnum.RightLaserAnchor;
            Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

            RaycastHit hitResult;
            if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.up), out hitResult, 10))
            {
                if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null)
                {
                    var behaviour = hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>();
                    if (behaviour.Trackable.GetTrackableType() != TrackableType.TRACKABLE_PLANE)
                    {
                        //if not detected then the miscellaneous objects will not be active 
                        if(misc.tag == "extra")
                        {
                            misc.SetActive(false); 
                        }
                        return;
                    }
                    //miscellaneous objects are set as active
                    misc.SetActive(true);
                    //identify a ray that casted below the game object 
                    Vector3 up = transform.TransformDirection(Vector3.up);

                    if (Physics.Raycast(transform.position, up, 10))
                    {
                        print("There is something below the object!");
                    }
                    // Instantiate Andy model at the hit point / compensate for the hit point rotation.
                    Instantiate(AndyPlanePrefab, hitResult.point, Quaternion.identity, behaviour.transform);
                    
                    
                }
            }
        }
    }
}
