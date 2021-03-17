using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

[Serializable]
public class ScoreHUDData
{
    [SerializeField]
    private int _scorePerKill;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private RectTransform _scoreTargetPosition;

    [Header("Animated Score Image")]
    [SerializeField]
    private Image _animatedScorePrefab;
    [SerializeField]
    private int _cachedObjectsInPool;
    [SerializeField]
    private RectTransform _holder;

    [Header("Tween Settings")]
    [Range(0.5f, 1.5f)]
    [SerializeField]
    private float _mainAnimationDuration;
    [SerializeField]
    private float _scaleAnimationDuration;
    [SerializeField]
    private Vector2 _growScaleSize;
    [SerializeField]
    private Vector2 _endScaleSize;

    public int ScorePerKill { get => _scorePerKill; }
    public TextMeshProUGUI ScoreText { get => _scoreText; }
    public RectTransform ScoreTargetPosition { get => _scoreTargetPosition; }
    public Image AnimatedScorePrefab { get => _animatedScorePrefab; }
    public int CachedObjectsInPool { get => _cachedObjectsInPool; }
    public RectTransform ScorePoolHolder { get => _holder; }
    public float MainAnimationDuration { get => _mainAnimationDuration; }
    public float ScaleAnimationDuration { get => _scaleAnimationDuration; }
    public Vector2 GrowScaleSize { get => _growScaleSize; }
    public Vector2 EndScaleSize { get => _endScaleSize; }
}
