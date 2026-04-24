using UnityEngine;
using System.Collections;
using TMPro;

public class AnimationManager : MonoBehaviour
{
    [Tooltip("Character")]
    public Animator characterAnimator;

    [Tooltip("Directional Light")]
    public Light sceneLight;

    public TextMeshProUGUI winText;

    public ParticleSystem explosionParticles;

    public CameraShake cameraShake;

    private float initialLightIntensity;

    void Start()
    {
        if (sceneLight != null)
        {
            initialLightIntensity = sceneLight.intensity;
        }

        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    public void PlayWinAnimation()
    {
        characterAnimator.SetTrigger("Win");

        if (sceneLight != null)
        {
            sceneLight.intensity = initialLightIntensity;
        }

        StartCoroutine(ExplosionRoutine());
    }

    private IEnumerator ExplosionRoutine()
    {
        yield return new WaitForSeconds(2.33f);

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
        }

        if (explosionParticles != null)
        {
            explosionParticles.Play();
        }

        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shake(0.5f, 0.1f));
        }
    }

    public void PlayFailAnimation()
    {
        characterAnimator.SetTrigger("Fail");

        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }

        if (sceneLight != null)
        {
            sceneLight.intensity = 0.2f;
        }
    }
}