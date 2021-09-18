using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public float speed = 1;
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // var ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit, 100))
        // {
        //     if (hit.transform.tag == "Player")
        //     {
        //         float step = speed * Time.deltaTime;
        //         transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), step);
        //         transform.LookAt(player.transform, Vector3.up);
        //     }
        // }
        // float step = speed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), step);
        // transform.LookAt(player.transform, Vector3.up);
        agent.SetDestination(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

    }
}



