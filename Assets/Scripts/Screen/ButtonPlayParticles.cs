using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    public void PlayParticles()
    {
        if (_particles == null) return;
        _particles.transform.position = new Vector3(transform.position.x, transform.position.y, _particles.transform.position.z);
        _particles.Play();
    }
}
