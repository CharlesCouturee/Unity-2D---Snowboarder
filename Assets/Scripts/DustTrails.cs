using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrails : MonoBehaviour
{
    [SerializeField] ParticleSystem onSnowEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && onSnowEffect)
        {
            onSnowEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && onSnowEffect)
        {
            onSnowEffect.Stop();
        }
    }
}
