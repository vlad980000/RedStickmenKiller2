using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _damage;

    private float _lifeTime;
    private float _time = 0;

    private Collider _collider;

    private Renderer _renderer;

    private bool _isDestroyed;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward);
        _time += Time.deltaTime;

        if (_time >= _lifeTime)
            Destroy(gameObject);
    }

    public void SetStats(int damage, float lifeTime, bool isDestroyed)
    {
        _damage = damage;
        _lifeTime = lifeTime;   
        _isDestroyed = isDestroyed; 
    }

    public void SetEffects(ParticleSystem particles, Material color)
    {
        Instantiate(particles,transform);
        _renderer.material = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);

            if(_isDestroyed == true)
                Destroy(gameObject);
        }
    }
}
