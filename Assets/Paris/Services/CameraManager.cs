using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    private GameObject _mainCamera;
    private Transform _cameraTarget;

    private Vector3 _lastTargetPosition;
    private Vector3 _targetDirection;

    private bool _tracking = true;
    private bool _dynamic = false;

    private GameObject _lastShotSetter;

    //Dynamic Camera Variables
    private float _dynamicCameraProgress;
    private GameObject[] _splineArray;

    private struct _dynamicCameraSplinePoint {
        public int index;
        public Transform transform;
        public Vector3 position;
    }

    private _dynamicCameraSplinePoint _splinePointA;
    private _dynamicCameraSplinePoint _splinePointB;

    public void Initialize() {
        _mainCamera = GameObject.FindGameObjectWithTag("GameCamera");
        _cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _lastTargetPosition = Vector3.zero;
    }

    public void Update() {
        //NullCheck
        if (_mainCamera == null || _cameraTarget == null) return;
        constructForwardVectorForTarget();

        if (_dynamic) _dynamicUpdate();
        if (_tracking) _trackingUpdate();

        //TEMP!!!!
        _dynamicCameraProgress += .005f;
        if (_dynamicCameraProgress > 1) _dynamicCameraProgress = 0;

    }

    void constructForwardVectorForTarget() {
        _targetDirection = -Vector3.Normalize(_lastTargetPosition - _cameraTarget.position) * 3;
        _lastTargetPosition = _cameraTarget.position;
    }

    void _trackingUpdate() {
        Vector3 _desiredDirection = ((_cameraTarget.position + _cameraTarget.transform.forward * 2) - _mainCamera.transform.position);
        Quaternion _desiredRotation = Quaternion.LookRotation(_desiredDirection, Vector3.up);
        _mainCamera.transform.rotation = Quaternion.Slerp(_mainCamera.transform.rotation, _desiredRotation, Time.deltaTime);
    }

    public void setShotStatic(GameObject shotHolder, bool tracking, GameObject shotSetter) {

        if (shotSetter == _lastShotSetter) return;

        _dynamic = false;

        _lastShotSetter = shotSetter;

        _tracking = tracking;

        _mainCamera.transform.position = shotHolder.transform.position;
        _mainCamera.transform.rotation = shotHolder.transform.rotation;

    }

    public void setShotDynamic(GameObject[] splineArray, bool tracking, GameObject shotSetter) {

        if (shotSetter == _lastShotSetter) return;

        _dynamic = true;

        _lastShotSetter = shotSetter;

        _tracking = tracking;

        _splineArray = splineArray;

        _splinePointA.transform = splineArray[0].transform;
        _splinePointA.index = 0;

        _splinePointB.transform = splineArray[1].transform;
        _splinePointB.index = 1;

    }

    public void _dynamicUpdate() {

        _updateSplineInformation();

        float _progress = GetProgress(_splinePointA.position, _splinePointB.position, _cameraTarget.position);

        if (_progress > .95f) _dynamicCamUpIndex();
        if (_progress < .05f) _dynamicCamDownIndex();

        _dynamicCameraProgress = (_progress + _splinePointA.index / _splineArray.Length);

        Debug.Log(_splinePointA.index);
        Debug.Log(_splinePointB.index);

        //Set Camera Along Line
        Vector3 _noramlizedDirection = Vector3.Normalize(_splinePointA.position - _splinePointB.position);
        float _distanceBetweenPoints = Vector3.Distance(_splinePointA.position, _splinePointB.position);

        _mainCamera.transform.position = _splinePointA.position + (-_noramlizedDirection * _dynamicCameraProgress * _distanceBetweenPoints);

    }

    void _updateSplineInformation() {

        _splinePointA.transform = _splineArray[_splinePointA.index].transform;
        _splinePointB.transform = _splineArray[_splinePointB.index].transform;

        _splinePointA.position = _splinePointA.transform.position;
        _splinePointB.position = _splinePointB.transform.position;

    }

    void _dynamicCamUpIndex() {

        //B becomes A, B+1 becomes B

        int _i = _splinePointB.index;

        if (_i == _splineArray.Length - 1) return;

        Debug.Log("Up Index");

        _splinePointB.index = _i + 1;
        _splinePointA.index = _i;
    }

    void _dynamicCamDownIndex() {

        int _i = _splinePointA.index;

        Debug.Log("Down Index");

        if (_i == 0) return;

        _splinePointA.index = _i - 1;
        _splinePointB.index = _i;

        //A becomes B, A-1 becomes B
    }

    float GetProgress(Vector3 _origin, Vector3 _end, Vector3 _point) {

        Vector2 origin = new Vector2(_origin.x, _origin.z);
        Vector2 end = new Vector2(_end.x, _end.z);
        Vector2 point = new Vector2(_point.x, _point.z);

        //Get heading
        Vector2 heading = (end - origin);
        float magnitudeMax = heading.magnitude;
        heading.Normalize();

        //Do projection from the point but clamp it
        Vector2 lhs = point - origin;
        float dotP = Vector2.Dot(lhs, heading);
        dotP = Mathf.Clamp(dotP, 0f, magnitudeMax);
        Vector2 output = origin + heading * dotP;

        float progress = Vector2.Distance(origin, output) / Vector2.Distance(origin, end);

        return progress;

    }



}
