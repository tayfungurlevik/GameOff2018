using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera followCamera;
    private CinemachineComposer aim;
    [SerializeField]private float thirdPersonMouseSensitivity;

    // Use this for initialization
    void Start () {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }
	
	// Update is called once per frame
	void Update () {
        var vertical = (Input.GetAxis("Mouse Y")+Input.GetAxis("VerticalXboxRightStick")) * thirdPersonMouseSensitivity;
        aim.m_TrackedObjectOffset.y += vertical;
        //hareketi sınırlandırmak için Mathf.Clamp metodunu kullanıyoruz.
        aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10, 10);
    }
}
