using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void HealthEvent(HealthBehaviour owner);
public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    private float _health;
    private HealthEvent _onDeath;
    private HealthEvent _onHit; 

    public float Health { get => _health; private set => _health = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public void AddOnDeathListener(HealthEvent listener)
    {
        _onDeath += listener;
    }

    public void AddOnHitListener(HealthEvent listener)
    {
        _onHit += listener;
    }

    public void Start()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_onHit != null)
        {
            _onHit.Invoke(this);
        }

        if (_health <= 0)
        {
            _health = 0;

            if(_onDeath != null)
            _onDeath.Invoke(this);

            GameManagerBehaviour.SpawnExplosion(this);
            Destroy(gameObject);
        }
    }
}
