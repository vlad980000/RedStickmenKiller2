using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _model;

    [SerializeField] private ParticleSystem _explosionEffect;

    [SerializeField] private float _jumpPower;
    [SerializeField] private float _delay;
    [SerializeField] private float _destroyDelay;

    [SerializeField] private Collider _collider;

    private int _damage;

    private List<Enemy> _enemyes = new List<Enemy>();

    private void OnEnable()
    {
        _explosionEffect.Stop();
        StartCoroutine(DoJumpAndExplosion(new Vector3(transform.position.x,transform.position.y + 3,transform.position.z + 50)));

        Debug.Log("Стреляю");
    }

    public void SetStats(int damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
            _enemyes.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
            _enemyes.Remove(enemy);
    }

    private IEnumerator DoJumpAndExplosion(Vector3 target)
    {
        var explosionDelay = new WaitForSeconds(_delay);
        var destroyDelay = new WaitForSeconds(_destroyDelay);

        transform.DOJump(target,_jumpPower,1,_delay / 2,false).SetEase(Ease.Linear);
        
        yield return explosionDelay;

        _explosionEffect.Play();

        yield return destroyDelay;

        for (int i = 0; i < _enemyes.Count; i++)
        {
            if (_enemyes[i] != null && _enemyes[i].IsAlive == true)
                _enemyes[i].ApplyDamage(_damage);
            else
                _enemyes.RemoveAt(i);
        }
        Destroy(gameObject);
    }
}
