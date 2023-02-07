using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (_player != null)
            transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z);
        else
            return;
    }
}
