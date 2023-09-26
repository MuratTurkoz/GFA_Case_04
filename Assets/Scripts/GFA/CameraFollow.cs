using Cinemachine;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow :CinemachineExtension
{
    // Start is called before the first frame update
    [SerializeField] Cinemachine3rdPersonAim cinemachine3RdPersonAim;
    [SerializeField] PlayerInput _playerInput;
   

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage==CinemachineCore.Stage.Aim)
            {
                //if(startingRotation==null) startingRotation=transform.localEulerAngles
            }
        }
        throw new System.NotImplementedException();
    }

    private  void Awake()
    {
       
        cinemachine3RdPersonAim=GetComponent<Cinemachine3rdPersonAim>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cinemachine3RdPersonAim.
    }
}
