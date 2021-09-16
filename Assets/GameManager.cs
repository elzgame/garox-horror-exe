using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static int keyCount;
    private int keyAvailable;
    public Text keyCountText;
    public static float timer;
    public static AudioSource audioSource;
    public Text perintahText;
    public Animator perintahAnimator;
    private bool doneCollectingKeys;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        keyAvailable = GameObject.FindGameObjectsWithTag("Key").Length;

        //Perintah objektif awal
        StartCoroutine(Perintah(3.0f, "Objektif : Cari kunci emas yang tersedia!"));
    }

    private IEnumerator Perintah(float timeAppear, string perintahTeks)
    {
        perintahAnimator.SetBool("Run", true);
        perintahText.text = perintahTeks;
        yield return new WaitForSeconds(timeAppear);
        perintahAnimator.SetBool("Run", false);
    }

    void Update()
    {
        keyCountText.text = keyCount.ToString() + " / " + keyAvailable.ToString();
        if (keyCount >= keyAvailable && doneCollectingKeys == false)
        {
            Debug.Log("Sudah selesai mengambil semua kunci emas!");
            StartCoroutine(Perintah(4.0f, "Semua kunci emas telah ditemukan, Objektif : Cari kunci merah untuk menyelesaikan game!"));
            doneCollectingKeys = true;
        }
    }

}
