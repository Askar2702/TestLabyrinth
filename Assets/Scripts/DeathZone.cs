using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float _chance;
    private Player _player;
    private void Awake()
    {
        var randomMumber = Random.Range(0f, 100f);
        if (randomMumber > _chance) gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.instance.LoseGame();
        }
    }
}
