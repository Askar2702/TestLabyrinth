using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class Player : MonoBehaviour
{
    public UnityEvent<bool> SetMove = new UnityEvent<bool>();
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private GameObject _explosionCubes;
    [SerializeField] private float _delayTime;
    [SerializeField] private ParticleSystem _finish;
    [SerializeField] private float _durationShield;


    [SerializeField] private Material _shieldOff;
    [SerializeField] private Material _shieldOn;
    public bool isHield { get; private set; }
    private void Start()
    {
        StartCoroutine(DelayMove());
    }
    IEnumerator DelayMove()
    {
        _mesh.enabled = true;
        yield return new WaitForSeconds(_delayTime);
        SetMove?.Invoke(true);
    }




    public void Finish()
    {
        _finish.Play();
    }
    public void Death()
    {
      //  Debug.Log(isHield);
        if (isHield) return;
        Debug.Log(isHield);
        var exp = Instantiate(_explosionCubes, transform.position, Quaternion.identity);
        Destroy(exp, 2f);
        SetMove?.Invoke(false);
        _mesh.enabled = false;
        StartCoroutine(DelayMove());
    }






    public void Move(bool isMove)
    {
        SetMove?.Invoke(isMove);
    }











    public void EnableShield()
    {
        isHield = true;
        _mesh.sharedMaterial = _shieldOn;
        Debug.Log(_mesh.material.name);
        StartCoroutine(OffShield());
    }

    IEnumerator OffShield()
    {
        yield return new WaitForSeconds(_durationShield);
        DisableShield();
    }
    public void DisableShield()
    {
        StopCoroutine(OffShield());
        _mesh.sharedMaterial = _shieldOff;
        isHield = false;
    }

    
}
