using Cinemachine;
using GFA.Case04.Mediators;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CinemachinePOV:CinemachineExtension
{
    //[SerializeField] private CinemachineVirtualCamera _vcam;
    ////[SerializeField] private CinemachinePOV _pov;
    ////[SerializeField] private Cinemachine.CinemachineComponentBase _component;
    //[SerializeField]
    //private PlayerMediator _playerMediator;
    ////private Vector3 startingRotation;
    ////[SerializeField] private float clambAngle = 80f;
    ////[SerializeField] private float HorizontalSpeed = 10f;
    //[Tooltip("Rotation speed of the character")]
    //public float RotationSpeed = 1.0f;
    //[Header("Cinemachine")]
    //[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    //public GameObject CinemachineCameraTarget;
    //[Tooltip("How far in degrees can you move the camera up")]
    //public float TopClamp = 90.0f;
    //[Tooltip("How far in degrees can you move the camera down")]
    //public float BottomClamp = -90.0f;

    // cinemachine
    private float _cinemachineTargetPitch;
    private const float _threshold = 0.01f;
    private float _rotationVelocity;
   [SerializeField] private PlayerInput playerInput;
    private Vector3 startingRotation;
    [SerializeField]
    private float verticalSpeed=10f;
    [SerializeField]
    private float horizontalSpeed=10f;
    [SerializeField]
    private float clambAngle=80f;
    protected override void Awake()
    {
        if (startingRotation == null)
        {
            startingRotation = transform.localRotation.eulerAngles;
        }
        base.Awake();

        //Cursor.visible = false;
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null)
                {
                    startingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = playerInput.GetMouseDelta();
           
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clambAngle, clambAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

}
