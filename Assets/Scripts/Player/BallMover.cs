using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Path _path;
    
    private Queue<Vector2> _targets;
    private PlayerInputs _inputs;
    private Vector2 _currentTarget;
    private Vector2 _previousPos;

    private void Awake()
    {
        _previousPos = transform.position;
        _currentTarget = Vector2.zero;
        _inputs = FindObjectOfType<PlayerInputs>();
        _targets = new Queue<Vector2>();
    }

    private void OnEnable()
    {
        _inputs.TargetAdded += OnTargetAdded;
    }

    private void OnDisable()
    {
        _inputs.TargetAdded -= OnTargetAdded;
    }

    private void Update()
    {
        if (_currentTarget == Vector2.zero) 
            return;
            
        Move();

        if (transform.position.x == _currentTarget.x && transform.position.y == _currentTarget.y)
        {
            SetNewTarget();
        }
    }
    
    private void OnTargetAdded(Vector2 newTarget)
    {
        var path = Instantiate(_path);
        path.DrawLine(_previousPos, newTarget);
        
        _targets.Enqueue(newTarget);

        if (_currentTarget == Vector2.zero)
        {
            _currentTarget = _targets.Dequeue();
        }

        _previousPos = newTarget;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    private void SetNewTarget()
    {
        if (_targets.Count > 0)
        { 
            _currentTarget = _targets.Dequeue();
        }
        else
        {
            _currentTarget = Vector2.zero;
        }
    }
}
