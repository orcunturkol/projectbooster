using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject sceneLoader;
    LoadScene loadScene;
    bool isColliderEnabled = true;
    private void Start()
    {
       loadScene = (LoadScene)sceneLoader.GetComponent(typeof(LoadScene));
    }
    private void Update()
    {
        HandleCollision();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isColliderEnabled==true)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    GetComponent<Movement>().enabled = false;
                    GetComponent<Movement>().audioSource.Stop();
                    loadScene.LoadReloadScene();
                    break;
                case "FriendlyGround":
                    GetComponent<Movement>().enabled = false;
                    GetComponent<Movement>().audioSource.Stop();
                    loadScene.LoadNextLevel();
                    break;
                default:
                    break;
            }
        }
    }


    private void HandleCollision()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (isColliderEnabled == true)
            {
                Debug.Log("Collisions deactived.");
                isColliderEnabled = false;
            } 
        }
        if (Input.GetKey(KeyCode.V))
        {
            if (isColliderEnabled == false)
            {
                Debug.Log("Collisions actived.");
                isColliderEnabled = true;
            }
        }
    }

   
}
