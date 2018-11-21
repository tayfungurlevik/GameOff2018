using System;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera followCamera;
    private CinemachineComposer aim;
    [SerializeField]private float thirdPersonMouseSensitivity;
    [SerializeField]
    private float maxY=10.0f;
    [SerializeField]
    private float minY=-10.0f;
    

    

    // Use this for initialization
    void Start () {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
        
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.Instance.Paused)
        {
            var vertical = (Input.GetAxis("Mouse Y") + Input.GetAxis("VerticalXboxRightStick")) * thirdPersonMouseSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            //hareketi sınırlandırmak için Mathf.Clamp metodunu kullanıyoruz.
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, minY, maxY);
        }
        
        
    }
}
