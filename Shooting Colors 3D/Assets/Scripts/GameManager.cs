using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static AudioSource audioSource;
    public static int platformCount;
    public static bool isSoundOn = true;
    
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject soundOnButton;
    [SerializeField] private GameObject soundOffButton;
    [SerializeField] private AudioClip successSFX;

    private bool levelCompleted = false;

    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
        ToggleSoundButton(isSoundOn);
        
        platformCount = FindObjectsOfType<Platform>().Length;
    }

    public IEnumerator Check()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        if (platformCount == 0 && !levelCompleted)
        {
            levelCompleted = true;
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        DisableShooters();

        nextLevel.SetActive(true);

        if (isSoundOn)
        {
            audioSource.PlayOneShot(successSFX, 1f);
        }
    }

    private static void DisableShooters()
    {
        Shooter[] shooters = FindObjectsOfType<Shooter>();

        foreach (Shooter shooter in shooters)
        {
            Destroy(shooter);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleSoundButton(bool toggle)
    {
        isSoundOn = toggle;
        soundOnButton.SetActive(toggle);
        soundOffButton.SetActive(!toggle);
    }
}
