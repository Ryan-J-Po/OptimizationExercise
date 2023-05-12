using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] 
    private HealthBehaviour _playerHealth;
    [SerializeField] 
    private GameObject _deathScreen;
    [SerializeField]
    private GameObject _explosionRef;
    private static GameObject _explosion;

    private void Start()
    {
        _explosion = _explosionRef;
        _playerHealth.AddOnHitListener(SpawnHitEffect);
        _playerHealth.AddOnDeathListener((health) => _deathScreen.SetActive(true));
    }

    public static void SpawnExplosion(HealthBehaviour character)
    {
        GameObject explosionInstance = Instantiate(_explosion, character.transform.position, _explosion.transform.rotation);

        ScreenShakeBehaviour.ShakeScreen();
        Destroy(explosionInstance, 1f);
        
    }

    public static void SpawnHitEffect(HealthBehaviour character)
    {
        GameObject explosionInstance = Instantiate(_explosion, character.transform.position, _explosion.transform.rotation);
        explosionInstance.transform.localScale /= 1.25f;
        ScreenShakeBehaviour.ShakeScreen();
        Destroy(explosionInstance, 0.3f);
    }

    private void EnableDeathScreen(float health)
    {
        _deathScreen.SetActive(true);
    }

}
