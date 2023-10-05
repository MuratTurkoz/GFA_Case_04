using Cinemachine;
using GFA.Case04.Mediators;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CinemachinePOV : CinemachineExtension
{
    [SerializeField]PlayerMediator playerMediator;
    [SerializeField] private PlayerInput playerInput;
    private Vector3 startingRotation;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float clambAngle = 80f;
    protected override void Awake()
    {
        if (startingRotation == null)
        {
            startingRotation = transform.localRotation.eulerAngles;
        }
        base.Awake();

        Cursor.visible = false;
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = playerInput.GetMouseDelta();
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.x = Mathf.Clamp(startingRotation.x, -clambAngle, clambAngle);
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clambAngle, clambAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

            }
        }
    }

}
