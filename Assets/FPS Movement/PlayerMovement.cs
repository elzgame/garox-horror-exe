// Some stupid rigidbody based movement by Dani

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Custom from SuryaElz
    public AudioClip keySound;
    public CharacterController controller;
    public float movementSpeed;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * movementSpeed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            GameManager.keyCount++;
            GameManager.audioSource.PlayOneShot(keySound);
        }
    }


}
