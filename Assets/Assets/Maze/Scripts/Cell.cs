using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject Floor;
    public GameObject WallLeft;
    public GameObject WallBottom;
    [SerializeField] private DeathZone _deathZone;
    [SerializeField] private FinishZone _finishZone;

    public void SetFinish()
    {
        _finishZone.gameObject.SetActive(true);
        _finishZone.enabled = true;
        Destroy( _deathZone);
    }

    public void DeleteComponentFinish()
    {
        Destroy(_finishZone);
    }
    public void DeleteComponentDeath()
    {
        Floor.transform.GetChild(0).gameObject.SetActive(false);
    }
}