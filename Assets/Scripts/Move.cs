using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Transform _target;
    private Player _player;
    private Vector3 _posStart;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _player.SetMove.AddListener(SetMove);
    }
    void Update()
    {
        _meshAgent.SetDestination(_target.position);
    }

    

    private void SetMove(bool isMove)
    {
        _meshAgent.isStopped = !isMove;
        if (!isMove && GameManager.instance.isLose)
            transform.position = _posStart;
    }

    
}
