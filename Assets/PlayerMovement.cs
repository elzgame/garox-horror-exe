using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Custom from SuryaElz
    public AudioClip keySound;
    public AudioClip doorSound;
    public CharacterController controller;
    public float movementSpeed;
    public List<int> keyCollected;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

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
            keyCollected.Add(other.gameObject.GetComponent<Key>().keyID);
        }

        if (other.gameObject.tag == "KeyRed")
        {
            Destroy(other.gameObject);
            GameManager.keyCount++;
            GameManager.audioSource.PlayOneShot(keySound);
        }

        if (other.gameObject.tag == "Door")
        {
            bool isMatch = false;
            for (int x = 0; x < keyCollected.Count; x++)
            {
                if (other.gameObject.GetComponent<Door>().doorID == keyCollected[x])
                {
                    isMatch = true;
                }
            }
            if (isMatch == true)
            {
                bool isOpened = other.gameObject.GetComponent<Door>().isOpened;
                if (isOpened == false)
                {
                    other.gameObject.GetComponent<Door>().isOpened = true;
                    Debug.Log("Buka pintu!");
                    other.gameObject.GetComponent<Animator>().SetTrigger("OpenDoor");
                    GameManager.audioSource.PlayOneShot(doorSound);
                }
                isMatch = false;
            }
            else
            {
                StartCoroutine(gameManager.Perintah(3.0f, "Tidak dapat membuka pintu, temukan kunci yang benar!"));
            }
        }
    }

}
