using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 2f;
    AudioSource audioSource;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failSound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheatLevel();
    }
    public void LoadReloadScene()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(failSound);
        }    
        StartCoroutine(ReloadScene());
    }


    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(transitionTime);     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        if(levelIndex != SceneManager.sceneCountInBuildSettings)
        {
                transition.SetTrigger("Start");
                SuccessSound();
                yield return new WaitForSeconds(transitionTime);
                SceneManager.LoadScene(levelIndex);
        }
        else
        {
            SuccessSound();
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(0);
            
        }

    }

    private void SuccessSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(successSound);
        }
    }

    private void CheatLevel()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
    }
}
