using Ebac.Core.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ParticleSystem particles;
    public void PlayParticles()
    {
        particles.Play();
    }
}
