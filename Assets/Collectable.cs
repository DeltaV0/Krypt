using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Transform player;

    public Movement movement;

    public GameObject GlowObj;

    public Door Close;

    public bool Collected;

    public CheckForCollected trigger;

    public bool key;

    public AudioSource aud;

    public AudioClip aud2;

    public GameObject activate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 5 && !Collected){
            if(Input.GetKey("e")){
                gameObject.SetActive(false);
                Collected = true;
                if(Close != null){
                    Close.Close();
                }
                if(key){
                    movement.keys++;
                    aud.PlayOneShot(aud2, 0.5f);
                }
                if(trigger != null){
                    trigger.Trigger();
                }
                if(activate != null){
                    activate.SetActive(true);
                }
                //StartCoroutine(Move());
            }
        }
        GlowObj.SetActive(Vector3.Distance(player.position, transform.position) < 5 && !Collected);
    }
}
