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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        keyAvailable = GameObject.FindGameObjectsWithTag("Key").Length;

        //Perintah objektif awal
        StartCoroutine(Perintah(3.0f));
    }

    private IEnumerator Perintah(float timeAppear)
    {
        perintahAnimator.SetBool("Run", true);
        perintahText.text = "Objektif : Cari kunci emas yang tersedia!";
        yield return new WaitForSeconds(timeAppear);
        perintahAnimator.SetBool("Run", false);
    }

    void Update()
    {
        keyCountText.text = keyCount.ToString() + " / " + keyAvailable.ToString();
    }

}
