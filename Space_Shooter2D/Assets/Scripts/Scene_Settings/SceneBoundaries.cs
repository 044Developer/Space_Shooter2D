using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBoundaries : MonoBehaviour
{
    private const float HalfColliderSize = 0.5f;
    private const float HalfOfResolution = 2f;

    [Header("Borders")]
    [SerializeField]
    private GameObject _leftBorder;
    [SerializeField]
    private GameObject _rightBorder;
    [SerializeField]
    private GameObject _bottomBorder;
    [SerializeField]
    private GameObject _topBorder;

    [Space]
    [Header("Border Offset")]
    [SerializeField]
    private float _bottomBorderOffset;

    private Camera _mainCamera;
    private float _cameraHeight;
    private float _cameraWidth;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        SetSceneBoundaries();
    }

    private void GetCameraSize()
    {
        _cameraHeight = HalfOfResolution * _mainCamera.orthographicSize;
        _cameraWidth = _cameraHeight * _mainCamera.aspect;
    }

    private void SetSceneBoundaries()
    {
        GetCameraSize();

        float borderXPosition = (_cameraWidth / HalfOfResolution) + HalfColliderSize;
        float borderYPosition = (_cameraHeight / HalfOfResolution) + (HalfColliderSize + _bottomBorderOffset);

        _leftBorder.transform.position = new Vector2(-borderXPosition, 0f);
        _rightBorder.transform.position = new Vector2(borderXPosition, 0f);
        _bottomBorder.transform.position = new Vector2(0f, -borderYPosition);
        _topBorder.transform.position = new Vector2(0f, borderYPosition);
    }
}
