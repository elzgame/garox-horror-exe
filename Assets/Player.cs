using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ghost ghost;
    GameManager gameManager;
    bool isCaught;

    void Start()
    {
        ghost = FindObjectOfType<Ghost>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Garox")
        {
            if (isCaught == false)
            {
                isCaught = true;
                Debug.Log("Hit Garox!");
                ghost.garoxJumpScareUI.SetActive(true);
                ghost.source.PlayOneShot(ghost.soundCaught);
                StartCoroutine(GameOver(3.0f));
            }
        }
    }

    IEnumerator GameOver(float time)
    {
        yield return new WaitForSeconds(time);
        Cursor.lockState = CursorLockMode.None;
        gameManager.gameOverUI.SetActive(true);
        GameManager.audioSource.PlayOneShot(gameManager.gameOverSound);
        Time.timeScale = 0;
    }



}
