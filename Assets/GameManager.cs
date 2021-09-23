using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int keyCount;
    private int keyAvailable;
    public Text keyCountText;
    public static AudioSource audioSource;
    public Text perintahText;
    public Animator perintahAnimator;
    private bool doneCollectingKeys;
    public AudioClip gameOverSound;
    public AudioClip finishSound;
    public GameObject gameOverUI;
    public GameObject finishUI;
    public Text timerText;
    public Text timerTextFinish;
    private int hourCount;
    private float secondsCount;
    private int minuteCount;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Perintah objektif awal
        StartCoroutine(Perintah(3.0f, "Objektif : Cari kunci emas yang tersedia!"));
        //Reset values.
        keyCount = 0;
        keyAvailable = GameObject.FindGameObjectsWithTag("Key").Length;
        doneCollectingKeys = false;

    }

    public IEnumerator Perintah(float timeAppear, string perintahTeks)
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

        UpdateTimerUI();

    }

    private void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        //hourCount +"h:"+ 
        timerText.text = "WAKTU : "  + minuteCount.ToString("00")+ ":"+ secondsCount.ToString("00");
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }


}
