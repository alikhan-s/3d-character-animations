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
    }

    public void PlayFailAnimation()
    {
        characterAnimator.SetTrigger("Fail");

        if (sceneLight != null)
        {
            sceneLight.intensity = 0.2f;
        }
    }
}