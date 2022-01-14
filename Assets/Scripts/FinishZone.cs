using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private Material _mat;
    [SerializeField] private MeshRenderer _mesh;
    void Start()
    {
        _mesh.material = _mat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.instance.FinishGame();
            Destroy(gameObject);
        }
    }

}
