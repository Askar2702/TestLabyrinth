using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _continue;
    [SerializeField] private Button _exit;
    [SerializeField] private CanvasGroup _panel;

    private void Awake()
    {
        _pause.onClick.AddListener(PauseGame);
        _continue.onClick.AddListener(ContinueGame);
        _exit.onClick.AddListener(ExitGame);
    }
   
    private void PauseGame()
    {
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1f, 1f);
        GameManager.instance.Player.Move(false);
    }

    private void ContinueGame()
    {
        _panel.DOFade(0f, 1f);
        _panel.gameObject.SetActive(false);
        GameManager.instance.Player.Move(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }



}
