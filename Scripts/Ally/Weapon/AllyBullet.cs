using System;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class AllyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _startDamage = 100f;
    [SerializeField] private float _aliveSeconds = 5f;

    [SerializeField] private Rigidbody _rigidbody = null;

    private Vector3 _direction;
    private Damage _damage;
    private float _expiredSeconds;

    public void Init(Vector3 target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _direction = (target - transform.position).normalized;
    }

    private void Awake()
    {
        _damage = new Damage(_startDamage);
    }

    private void FixedUpdate()
    {
        _expiredSeconds += Time.fixedDeltaTime;
        var offset = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);
        if (_expiredSeconds >= _aliveSeconds)
        {
            _expiredSeconds = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        var health = collider.GetComponent<EnemyHealth>();
        if (health != null && health.IsAlive)
            health.TakeDamage(_damage);
    }
}


