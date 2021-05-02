using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Material targetMaterial;
    [SerializeField] GameObject particle;
    [SerializeField] AudioClip clip;

    [HideInInspector] public bool isCorrectColor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;

            if (GetComponent<Renderer>().material.color == targetMaterial.color && !isCorrectColor)
            {
                isCorrectColor = true;
                GameManager.platformCount--;
            }
            else if (GetComponent<Renderer>().material.color != targetMaterial.color && isCorrectColor)
            {
                isCorrectColor = false;
                GameManager.platformCount++;
            }

            ActivateParticleEffect(other);
            ActivateSoundEffect(GameManager.isSoundOn);
        }
    }

    private void ActivateSoundEffect(bool soundOn)
    {
        if (soundOn)
        {
            GameManager.audioSource.PlayOneShot(clip, 0.5f);
        }
    }

    private void ActivateParticleEffect(Collider other)
    {
        GameObject particleGO = Instantiate(particle, transform.position + new Vector3(0, 0.5f, 0), particle.transform.rotation);
        particleGO.GetComponent<ParticleSystem>().startColor = other.GetComponent<Renderer>().material.color;
    }
}
