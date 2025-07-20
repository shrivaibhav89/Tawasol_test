using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticalManager : MonoBehaviour
{
    public ParticleSystem coinCollectParticle;

    public Queue<ParticleSystem> coinPool;
    private void Start()
    {
        // Initialize the coin pool with the particle system
        int poolSize = 10; // Adjust the size of the pool as needed
        coinPool = new Queue<ParticleSystem>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            ParticleSystem particle = Instantiate(coinCollectParticle);
            particle.gameObject.SetActive(false);
            coinPool.Enqueue(particle);
        }
    }

    private ParticleSystem GetParticleSystem()
    {
        if (coinPool.Count > 0)
        {
            return coinPool.Dequeue();
        }
        // If all particles are active, return a new one
        ParticleSystem newParticle = Instantiate(coinCollectParticle);
        return newParticle;
    }

    public void PlayCoinCollectParticle(Vector3 position)
    {
        ParticleSystem particle = GetParticleSystem();
        particle.transform.position = position;
        particle.gameObject.SetActive(true);
        particle.Play();
        StartCoroutine(ReleaseParticleAfterDelay(particle, particle.main.duration));
    }

    private IEnumerator ReleaseParticleAfterDelay(ParticleSystem particle, float delay)
    {
        yield return new WaitForSeconds(delay);
        particle.gameObject.SetActive(false);
        coinPool.Enqueue(particle);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnCoinCollected += OnCoinCollectedHandler;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCoinCollected -= OnCoinCollectedHandler;
    }

    private void OnCoinCollectedHandler()
    {
        PlayCoinCollectParticle(GameManager.Instance.playerController.transform.position);
    }
}
