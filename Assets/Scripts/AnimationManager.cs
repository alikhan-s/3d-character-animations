using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Tooltip("Character")]
    public Animator characterAnimator;

    [Tooltip("Directional Light")]
    public Light sceneLight;

    private float initialLightIntensity;

    void Start()
    {
        if (sceneLight != null)
        {
            initialLightIntensity = sceneLight.intensity;
        }
    }

    public void PlayWinAnimation()
    {
        characterAnimator.SetTrigger("Win");

        if (sceneLight != null)
        {
            sceneLight.intensity = initialLightIntensity;
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