using Cinemachine;
using GFA.Case04.Mediators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CinemachinePOV:MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vcam;
    //[SerializeField] private CinemachinePOV _pov;
    //[SerializeField] private Cinemachine.CinemachineComponentBase _component;
    [SerializeField]
    private PlayerMediator _playerMediator;
    //private Vector3 startingRotation;
    //[SerializeField] private float clambAngle = 80f;
    //[SerializeField] private float HorizontalSpeed = 10f;
    [Tooltip("Rotation speed of the character")]
    public float RotationSpeed = 1.0f;
    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;
    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 90.0f;
    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -90.0f;

    // cinemachine
    private float _cinemachineTargetPitch;
    private const float _threshold = 0.01f;
    private float _rotationVelocity;
    private void Awake()
    {
        //Cursor.visible = false;
    }
    private void LateUpdate()
    {
        // if there is an input
        if (_playerMediator.LookPosition.sqrMagnitude >= _threshold)
        {
            //Don't multiply mouse input by Time.deltaTime
            float deltaTimeMultiplier = 1;

            _cinemachineTargetPitch += _playerMediator.LookPosition.x * RotationSpeed * deltaTimeMultiplier;
            _rotationVelocity = _playerMediator.LookPosition.y * RotationSpeed * deltaTimeMultiplier;

            // clamp our pitch rotation
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Update Cinemachine camera target pitch
            CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * _rotationVelocity);
        }
        //_component.
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
    //protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    //{
    //    if (vcam.Follow)
    //    {
    //        if (stage == CinemachineCore.Stage.Aim)
    //        {
    //            if (startingRotation == null)
    //            {
    //                startingRotation = transform.localRotation.eulerAngles;
    //            }
    //            Vector2 deltaInput = _playerMediator.LookPosition;
    //            Debug.Log(deltaInput);
    //            startingRotation.x += deltaInput.x *verticalSpeed* Time.deltaTime;
    //            startingRotation.y += deltaInput.y *HorizontalSpeed* Time.deltaTime;
    //            startingRotation.y = Mathf.Clamp(startingRotation.y,-clambAngle,clambAngle);
    //            state.RawOrientation = Quaternion.Euler(startingRotation.y,startingRotation.x,0f);
    //        }
    //    }
    //}


    //[SerializeField]
    //private float horizontalSpeed = 10f;

    //[SerializeField]
    //private float verticalSpeed = 10f;

    //[SerializeField]
    //private float clampAngle = 80f;

    //private InputManager inputManager;
    //private Vector3 startingRotation;

    //protected override void Awake()
    //{
    //    inputManager = InputManager.Instance;
    //    base.Awake();
    //}
    //protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    //{
    //    if (vcam.Follow)
    //    {
    //        if (stage == CinemachineCore.Stage.Aim)
    //        {
    //            if (startingRotation == null)
    //            {
    //                startingRotation = transform.localRotation.eulerAngles;
    //            }
    //            Vector2 deltaInput = inputManager.GetMouseDelta();
    //            startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
    //            startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
    //            startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
    //            state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
    //        }
    //    }
    //}


}
