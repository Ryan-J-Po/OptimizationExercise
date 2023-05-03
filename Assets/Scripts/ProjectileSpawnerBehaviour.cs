using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

public class ProjectileSpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private ProjectileBehaviour _projectile;
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private LayerMask _collisionLayers;
    [SerializeField]
    private Transform _projectileHolder;

    public LayerMask CollisionLayers { get => _collisionLayers; private set => _collisionLayers = value; }

    public void FireProjectile()
    {
        if (!_projectile)
            return;

        GameObject projectileInstance = ObjectPoolBehaviour.Instance.GetObject(_projectile.gameObject, transform.position, transform.rotation);
        ProjectileBehaviour projectile = projectileInstance.GetComponent<ProjectileBehaviour>();

        projectileInstance.transform.parent = _projectileHolder.transform;

        projectile.CollisionLayers = _collisionLayers;

        Rigidbody projectileRigid = projectile.RB;

        projectileRigid.velocity = transform.up * _projectileSpeed;
    }
}
