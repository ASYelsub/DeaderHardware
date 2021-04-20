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
    private bool _progressgoingup = false;
    private float _lastframeProgress;

    private GameObject _lastShotSetter;

    //Dynamic Camera Variables
    private float _dynamicCameraProgress, increments;
    private GameObject[] _camSplineArray;
    private GameObject[] _playerPathSpline;

    private struct _dynamicCameraSplinePoint {
        public int index;
        public Transform transform;
        public Vector3 position;
    }

    private struct SplineHolder {
        public GameObject[] array;
        public Transform pointA;
        public Transform pointB;
        public int index;
        public bool movingUpArray;
    }

    private SplineHolder cameraSpline;
    private SplineHolder pathSpline;

//    private _dynamicCameraSplinePoint _splinePointA;
//    private _dynamicCameraSplinePoint _splinePointB;

    public void Initialize() {
        Debug.Log("I am called");
        _mainCamera = GameObject.Find("GameCamera");
        _cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _lastTargetPosition = Vector3.zero;
    }

    public void Update() {
        //NullCheck
        if (_mainCamera == null || _cameraTarget == null) return;
        constructForwardVectorForTarget();

        if (_dynamic) _dynamicUpdate();
        if (_tracking) _trackingUpdate();

        /*
        //TEMP!!!!
        _dynamicCameraProgress += .005f;
        if (_dynamicCameraProgress > 1) _dynamicCameraProgress = 0;
        */
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

    //Set shot to be dynamic
    public void setShotDynamic(GameObject[] cameraSplineArray, GameObject[] playerPathSplineArray, bool tracking, GameObject shotSetter) {

        //Set Shot to be dynamic
        if (shotSetter == _lastShotSetter) return;
        if (cameraSplineArray.Length == 0 || playerPathSplineArray.Length == 0) return;
        if (_cameraTarget == null) return;

        cameraSpline.index = 0;
        pathSpline.index = 0;

        _dynamic = true;
        _lastShotSetter = shotSetter;

        //Is Camera Tracking
        _tracking = tracking;

        //Configure Camera Spline
        cameraSpline.array = cameraSplineArray;
        pathSpline.array = playerPathSplineArray;

        cameraSpline.pointA = cameraSpline.array[1].transform;
        cameraSpline.pointB = cameraSpline.array[0].transform;

        pathSpline.pointA = pathSpline.array[0].transform;
        pathSpline.pointB = pathSpline.array[1].transform;

        increments = (1f / (cameraSpline.array.Length - 1f));

        // -------------------------------- //

    }

    public void _dynamicUpdate() {

        _updateSplineInformation();

        float _progress = GetProgress(pathSpline.pointA.position, pathSpline.pointB.position, _cameraTarget.position);

        if (_progress > .95 && !_progressgoingup) {
            pathSpline = SplineUpIndex(pathSpline);

        }
        if (_progress < .05 && _progressgoingup) {
            pathSpline = SplineDownIndex(pathSpline);
            cameraSpline = SplineDownIndex(cameraSpline);
        }

        

        float overallProgress = (_progress + pathSpline.index) / (pathSpline.array.Length - 1);

        Debug.Log("Increments:" + increments);

        if (overallProgress > (cameraSpline.index * increments)) cameraSpline = splineUpIndexCamera(cameraSpline);
        if (overallProgress < (cameraSpline.index * increments)) cameraSpline = splineDownIndexCamera(cameraSpline);

        //---------- things broken blow this point ---------------//

        _dynamicCameraProgress = (overallProgress) / (((cameraSpline.index) * increments) + .25f);
        Debug.Log(new Vector3(_dynamicCameraProgress, overallProgress, cameraSpline.index));

        if (cameraSpline.pointA == null || cameraSpline.pointB == null) Debug.Log("Null Spline Points"); 
        if (pathSpline.pointA == null || pathSpline.pointB == null) Debug.Log("Null Spline Points");

        //Set Camera Along Line
        Vector3 _noramlizedDirection = Vector3.Normalize(cameraSpline.pointB.position - cameraSpline.pointA.position);
        float _distanceBetweenPoints = Vector3.Distance(cameraSpline.pointB.position, cameraSpline.pointA.position);

        _dynamicCameraProgress = _progress;
        Vector3 desiredCameraPosition = cameraSpline.pointB.position + ((-_noramlizedDirection * _distanceBetweenPoints) * (_dynamicCameraProgress));

        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, desiredCameraPosition, .1f);

        _progressgoingup = (_lastframeProgress > _progress);

        _lastframeProgress = _progress;

    }

    void _updateSplineInformation() {

    }

    //TODO refactor to take in SplineHolder
    SplineHolder SplineUpIndex(SplineHolder a) {

        /*
        if (a.index + 2 == a.array.Length) return a;

        //point a becomes b
        //point b becomes a+1

        a.pointA = a.pointB;
        a.pointB = a.array[a.index + 2].transform;

        a.index += 1;
                */
        return a;


    }

    SplineHolder SplineDownIndex(SplineHolder a) {
        //A becomes B, A-1 becomes B

        /*
        if (a.index == 0) return a;

        a.pointB = a.pointA;
        a.pointA = a.array[a.index - 1].transform;

        a.index--;
        */
        return a;
    }

    SplineHolder splineUpIndexCamera(SplineHolder a) {
        /*
        Debug.Log("Up:" + a.index);

        if (a.index == a.array.Length - 1) return a;

        a.pointA = a.array[a.index + 1].transform;
        a.pointB = a.array[a.index].transform;

        a.index++;
        */
        return a;
    }

    SplineHolder splineDownIndexCamera(SplineHolder a) {
        /*
        Debug.Log("Down:" + a.index);

        if (a.index - 1 == 0) return a;

        a.pointA = a.array[a.index - 1].transform;
        a.pointB = a.array[a.index - 2].transform;

        a.index--;
        */
        return a;
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
