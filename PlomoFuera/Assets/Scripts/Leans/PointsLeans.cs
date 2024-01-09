using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsLeans : MonoBehaviour
{
    private static PointsLeans _instance;
    public static PointsLeans Instance { get { return _instance; } }

    [Header("Scales")]
    [SerializeField] private float _initScale;
    [SerializeField] private float _scaleUp;
    [SerializeField] private float _scaleDown;
    [Space(3)]
    [Header("Times")]
    [SerializeField] private float _timeScaleUp;
    [SerializeField] private float _timeScaleDown;

    private void Awake()
    {
        if (_instance is null)
        {
            _instance = this;
        }
    }

    public void ScaleUp(GameObject go)
    {
        LeanTween.scale(go, Vector3.one * _scaleUp, 0.0f);
        LeanTween.scale(go, Vector3.one * _initScale, 1.0f);
    }

}
