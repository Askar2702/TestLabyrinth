using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isLose { get; private set; }
    [SerializeField] private Image _background;
    [field: SerializeField] public Player Player { get; private set; }
    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void LoseGame()
    {
        if (Player.isHield) return;
        isLose = true;
        Player.Death();
    }
    public void FinishGame()
    {
        Player.Finish();
        var seq = DOTween.Sequence();
        seq.Append(_background.DOFade(1f, 1f));
        seq.OnComplete(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
