using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    private GameObject _mainCamera;
    private Transform _cameraTarget;

    private Vector3 _lastTargetPosition;
    private Vector3 _targetDirection;

    private bool _tracking = true;

    private GameObject _lastShotSetter;

    public void Initialize() {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _lastTargetPosition = Vector3.zero;
    }

    public void Update() {
        //NullCheck
        if (_mainCamera == null || _cameraTarget == null) return;
        constructForwardVectorForTarget();


        if (_tracking) {
            Vector3 _desiredDirection = ((_cameraTarget.position + _cameraTarget.transform.forward * 2) - _mainCamera.transform.position);
            Quaternion _desiredRotation = Quaternion.LookRotation(_desiredDirection, Vector3.up);
            _mainCamera.transform.rotation = Quaternion.Slerp(_mainCamera.transform.rotation, _desiredRotation, Time.deltaTime);
        }


    }

    void constructForwardVectorForTarget() {
        _targetDirection = -Vector3.Normalize(_lastTargetPosition - _cameraTarget.position) * 3;
        _lastTargetPosition = _cameraTarget.position;
    }

    public void setShotStatic(GameObject shotHolder, bool tracking, GameObject shotSetter) {

        if (shotSetter == _lastShotSetter) return;

        _lastShotSetter = shotSetter;

        _tracking = tracking;

        _mainCamera.transform.position = shotHolder.transform.position;
        _mainCamera.transform.rotation = shotHolder.transform.rotation;

    }
}
