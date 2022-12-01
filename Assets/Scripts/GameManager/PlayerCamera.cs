using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class PlayerCamera : MonoBehaviour
{

    public Transform targetJulius;
    public Transform targetRave;
    [SerializeField] public Vector3 offset;
    private Vector3 shakeOffset;
    public float speed = 100f;
    public float smoothSpeed = 0.125f;

    Julius julius;
    Rave rave;

    internal Volume volume;
    internal Vignette vignette;
    internal DepthOfField depthOfField;
    internal ColorAdjustments colorAdjustments;

    private void Start()
    {
        julius = GetComponent<Julius>();
        rave = GetComponent<Rave>();
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out depthOfField);
        volume.profile.TryGet(out colorAdjustments);
    }
    void LateUpdate()
    {
        if (HeroManager.isJulius == true)
        {
            if (targetJulius != null)
            {

                float playerX = targetJulius.transform.position.x;
                float playerY = targetJulius.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                vignette.intensity.Override(1 - julius.GetHpRatio());
                transform.position = targetPosition + shakeOffset;
            }
        } 
        if (HeroManager.isRave == true)
        {
            if (targetRave != null)
            {

                float playerX = targetRave.transform.position.x;
                float playerY = targetRave.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                vignette.intensity.Override(1 - rave.GetHpRatio());
                transform.position = targetPosition + shakeOffset;
            }
        }
        

    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            shakeOffset.x = x;
            shakeOffset.y = y; 
            elapsed += Time.deltaTime;
            yield return 0;
        }
        shakeOffset = Vector3.zero;
    }
    public void StartShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }
}
