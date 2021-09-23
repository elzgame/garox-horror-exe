using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Custom from SuryaElz
    public AudioClip keySound;
    public AudioClip doorSound;
    public AudioClip walkingSound;
    public CharacterController controller;
    public float movementSpeed;
    public List<int> keyCollected;
    private GameManager gameManager;
    private bool isFinish = false;
    private bool isMoving = false;
    public AudioSource walkingSource;

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

        if (x != 0 || y != 0)
        {
            if (isMoving == false)
            {
                isMoving = true;
                StartCoroutine(Walking(4f));
            }
        }
        else
        {
            walkingSource.Stop();
            isMoving = false;
        }
    }


    IEnumerator Walking(float timerToStop)
    {
        walkingSource.Play();
        yield return new WaitForSeconds(timerToStop);
        isMoving = false;
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
            keyCollected.Add(other.gameObject.GetComponent<Key>().keyID);
            StartCoroutine(gameManager.Perintah(3.0f,"Kunci merah didapatkan!, Objektif : cari pintu untuk menyelesaikan game."));        
        }

        if (other.gameObject.tag == "Finish")
        {
            if (isFinish == false)
            {
                isFinish = true;
                Cursor.lockState = CursorLockMode.None;
                gameManager.finishUI.SetActive(true);
                // finishTime.text = ""
                GameManager.audioSource.PlayOneShot(gameManager.finishSound);
                gameManager.timerTextFinish.text = gameManager.timerText.text;
                Time.timeScale  = 0;
            }
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
