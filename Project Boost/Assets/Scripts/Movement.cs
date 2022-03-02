using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRb;
    [SerializeField] public AudioSource audioSource;

    [SerializeField] float rocketSpeed = 1000;
    [SerializeField] float rotateStrenght = 200;
    [SerializeField] AudioClip rocketBoost;

    [SerializeField] ParticleSystem rocketParticles;


    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

  
    void Update()
    {
        Flight();
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateRocket(-rotateStrenght);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateRocket(rotateStrenght);
        }

    }

    private void Flight()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRb.AddRelativeForce(Vector3.up * rocketSpeed * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(rocketBoost);               
            }
            if (!rocketParticles.isPlaying)
            {
                rocketParticles.Play();
            }            
        }
        else
        {
            audioSource.Stop();
            rocketParticles.Stop();
        }      
    }

    private void RotateRocket(float rotationSpeed)
    {
        rocketRb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rocketRb.freezeRotation = false;
    }
}
