using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpperPart : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _attackSpeed;

    [SerializeField] private ParticleSystem _shootEffect;

    private Enemy _enemy;

    public UnityAction<Enemy> EnemyIsKilled;

    private void Update()
    {
        if(_enemy != null)
            Rotate();
    }

    public void KillEnemy(Enemy enemy)
    {
        StartCoroutine(Soot(enemy));
    }

    private IEnumerator Soot(Enemy enemy)
    {
        _enemy = enemy;

        var time = new WaitForSeconds(_attackSpeed);

        yield return time;

        _shootEffect.Play();
        enemy.ApplyDamage(_damage);
        _enemy = null;
        EnemyIsKilled?.Invoke(enemy);
    }

    private void Rotate()
    {
        Vector3 direction = _enemy.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,_rotateSpeed * Time.deltaTime);
    }
}
