using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Ghost : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public float speed = 1;
    private NavMeshAgent agent;
    public AudioClip soundKaget;
    public AudioClip soundChasing;
    public AudioClip soundSamlekom;
    public AudioClip soundCaught;
    public AudioSource source;
    public int chasingTimeSound;
    private bool isChasingSound = false;
    public GameObject garoxJumpScareUI;

    void Start()
    {
        source = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        var directionToPlayer = player.transform.position -  transform.position ;
        var ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject.name);
            Debug.DrawRay(transform.position, directionToPlayer,Color.red);
            if (hit.transform.tag == "Player" && isChasingSound == false)
            {
                Debug.Log("Chasing Player!");
                isChasingSound = true;
                StartCoroutine(ChasingSound(5));
            }
        }
        // float step = speed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), step);
        // transform.LookAt(player.transform, Vector3.up);
        agent.SetDestination(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }

    IEnumerator ChasingSound(float chasingTime)
    {
        Debug.Log("Garox is chasing");
        source.PlayOneShot(soundChasing);
        source.PlayOneShot(soundKaget);
        source.PlayOneShot(soundSamlekom);
        yield return new WaitForSeconds(chasingTime);
        isChasingSound = false;
    }
}



