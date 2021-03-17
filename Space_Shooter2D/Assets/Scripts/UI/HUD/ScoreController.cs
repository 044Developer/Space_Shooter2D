using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class ScoreController
{
    private const string ScoreText = "Score:\n";

    private Camera _camera;
    private ScoreHUDData _scoreData;
    private int _scoreCount = 0;
    public ScoreController(ScoreHUDData scoreData)
    {
        _scoreData = scoreData;
        _camera = Camera.main;
        InitializeScoreText();
    }

    public void AnimateScore(Vector3 scoreSpawnPoint, ref Queue<Image> scorePool)
    {
        var position = _camera.WorldToScreenPoint(scoreSpawnPoint);

        if (scorePool.Count > 0)
        {
            Image animatedImage = scorePool.Dequeue();
            animatedImage.gameObject.SetActive(true);
            animatedImage.transform.position = position;

            CreateAnimationSequence(animatedImage, _scoreData.ScoreTargetPosition, scorePool);
        }
    }

    private void CreateAnimationSequence(Image image, RectTransform target, Queue<Image> pool)
    {
        Sequence animationSequence = DOTween.Sequence();

        animationSequence.Append(image.rectTransform.DOPunchScale(_scoreData.GrowScaleSize, _scoreData.ScaleAnimationDuration))
        .Append(image.rectTransform.DOMove(target.position, _scoreData.MainAnimationDuration))
        .Insert(0, image.rectTransform.DOScale(_scoreData.EndScaleSize, animationSequence.Duration())
        .OnComplete(() =>
        {
            image.gameObject.SetActive(false);
            pool.Enqueue(image);

            AddScore();
        }));
    }

    private void InitializeScoreText()
    {
        _scoreData.ScoreText.text = $"{ScoreText} {_scoreCount}";
    }

    private void AddScore()
    {
        _scoreCount += _scoreData.ScorePerKill;
        _scoreData.ScoreText.text = $"{ScoreText} {_scoreCount}";
    }
}
