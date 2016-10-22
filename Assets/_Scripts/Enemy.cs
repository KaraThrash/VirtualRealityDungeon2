using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private PhotonView myPhotonView;
    public GameObject player;
    public GameObject behindPlayer;
    public float speed;
    public bool isGhost;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player(Clone)");
        behindPlayer = GameObject.Find("BehindPlayer");
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit))
                {

                if (hit.transform.gameObject.tag == "Player")
                {
                    if (isGhost == false)
                    {
                        transform.LookAt(player.transform.position);
                        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    }
                    else {
                        transform.LookAt(player.transform.position);
                        transform.position = Vector3.MoveTowards(transform.position, behindPlayer.transform.position, speed * Time.deltaTime);
                    }
                }


                }
            }
            
        }
    
}
