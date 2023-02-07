using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private ParticleSystem _bloodEffect;

    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private float _timeBetweenBlood;

    [SerializeField] private ColorChanger _colorChanger;

    private int _health;
    private int _damage;
    private int _reward;

    private NavMeshAgent _NavmeshAgent;

    private StateMashine _stateMashine;

    private Player _player;

    private Collider _collider;

    private bool _isAlive = true;

    private bool _isTarget = false;

    private Coroutine _bloodEffectCoroutine;

    private WaitForSeconds _timeBetweenBloodInCoroutine;
    public Player PLayer => _player;

    public bool IsAlive => _isAlive;

    public bool IsTarget => _isTarget;

    private void Awake()
    {
        _bloodEffect.Stop();
        _collider = GetComponent<Collider>();
        _NavmeshAgent = GetComponent<NavMeshAgent>();

        _timeBetweenBloodInCoroutine = new WaitForSeconds(_timeBetweenBlood);
    }

    public void SetPLayer(Player player)
    {
        _player = player;
    }

    public void SetStats(int health, int damage, int reward)
    {
        _health = health;
        _damage = damage;
        _reward = reward;
    }

    public void ApplyDamage(int damage)
    {
        if (_bloodEffectCoroutine == null && _health > 0)
            _bloodEffectCoroutine = StartCoroutine(BloodEffect());

        if (_health > damage )
        {
            _health -= damage;
            _colorChanger.LoopChangeColor();
        }
        else
        {
            _isAlive = false;
            Death();
        }
    }

    public void SetIsTarget()
    {
        if (_isTarget == false)
            _isTarget = true;
        else
            return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            _player.ApplyDamage(_damage);
            Death();
        }
    }

    private IEnumerator BloodEffect()
    {
        _bloodEffect.Play();

        yield return _timeBetweenBloodInCoroutine;

        _bloodEffectCoroutine = null;
    }
    
    private void Death()
    {
        _collider.enabled = false;
        _NavmeshAgent.isStopped = true;
        _player.GetComponent<PlayerWallet>().ApplyMoney(_reward);
        StartCoroutine(Delete());
    }

    private IEnumerator Delete()
    {
        var time = new WaitForSeconds(_timeBeforeDestroy);

        _animator.SetTrigger("Death");
        _colorChanger.ChangeColor();

        yield return time;

        Destroy(gameObject);
    }
}
