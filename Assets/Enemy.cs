using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    //public Animator anim;

    //public Transform[] tips;

    public Transform[] tipstarget;

    public Vector3[] tipstargetPos;
    //public Transform[] tipstarget;

    public int[] timer;

    public Transform[] offsets;

    public Transform head;

    public Transform[] eyes;

    //public Rigidbody rb;

    public bool pathAvailable;
    public NavMeshPath navMeshPath;

    public Transform[] patrolPoints;

    public Vector3 playerLastSeen;

    public int wait;

    public AudioSource aud;

    public AudioClip aud2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshPath = new NavMeshPath();
        agent.SetDestination(transform.position);
        playerLastSeen = player.position;
        //agent.updatePosition = false;
        //offset timers
        timer[1] = 20;
        timer[2] = 40;
        timer[3] = 60;
    }

    IEnumerator play(float a){
        yield return new WaitForSeconds(0.5f);
        aud.pitch = Random.Range(0.9f, 1.1f);
        aud.PlayOneShot(aud2, a);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, player.position) < 3){
            gameObject.SetActive(false);
            SceneManager.LoadSceneAsync("Lose");
        }
        //unused rn
        if (wait > 0)
        {
            wait--;
        } //else {
           // wait = 500;
        //}
        if(wait <= 0){
        playerLastSeen = patrolPoints[Random.Range(0, patrolPoints.Length)].position;
        wait = 500;
        while(agent.pathStatus == NavMeshPathStatus.PathInvalid){
            playerLastSeen = patrolPoints[Random.Range(0, patrolPoints.Length)].position;
            wait = 500;
        }
        }
        //more advanced system ig
        //calc path
        //NavMeshHit hit25;
      //  pathAvailable = agent.CalculatePath(player.position, navMeshPath);

        //idk what's broken here but the pathfinding is a bit broke
        //RaycastHit hit25;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        //Vector3 currentDirection = (transform.position-player.position).normalized;
        Debug.Log(!Physics.Linecast(transform.position, player.position, layerMask));
        //Debug.Log(hit25.collider.transform.gameObject.layer);
        if (!Physics.Linecast(transform.position, player.position, layerMask) && agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            //go to player if player is visible and it can actually get to the player
            agent.SetDestination(player.position);
            //set the variable to the last seen position
            playerLastSeen = player.position;
            wait = 500;
        }
        else
        {
            //if(wait > 0){
            //if it cant see the player, go to the last seen player position
            agent.SetDestination(playerLastSeen);
            //}
        }
        //rotate body towards where moving (maybe not?)    
        //transform.LookAt(transform.position + agent.velocity);

        //look at player
        //head.DODynamicLookAt(player.position, 5f);

        //move eyes seperately
       // for (int a = 0; a < eyes.Length; a++)
       // {
       //     eyes[a].DODynamicLookAt(player.position, 0.1f);
       // }
        //go through all timers moving legs if it's zero
        for (int i = 0; i < tipstarget.Length; i++)
        {
            if (timer[i] <= 0)
            {
                //move leg x
                timer[i] = 80 + Random.Range(-25, 25);
                RaycastHit hit;
                Physics.Raycast(offsets[i].position + (agent.velocity * 1.25f) * transform.localScale.z, Vector3.down, out hit, 100f, LayerMask.GetMask("Ground"));
                tipstargetPos[i] = hit.point;
                tipstarget[i].DOJump(tipstargetPos[i], Vector3.Distance(tipstarget[i].position, tipstargetPos[i]) * 0.2f, 1, 0.5f);
                StartCoroutine(play(Vector3.Distance(tipstarget[i].position, tipstargetPos[i]) * 0.2f));
                //transform.DOShakeRotation(0.1f, 22.5f, 1, 22.5f, true);

            }
            else
            {
                timer[i]--;
            }

        }


    }

}
