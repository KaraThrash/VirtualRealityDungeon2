using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : Photon.MonoBehaviour
{
    private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
    private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this

    public GameObject cube;
    private PhotonView myPhotonView;
    public int playerCount;
    public GameObject monsterObj;
    public bool isControllable;
    public GameObject audioTextObj;
    public GameObject myCam;
    public GameObject myText;
    public int myPlayerInt;
    public int syncInt;
    public string words;
    public string correctString;
    public float timer = 5;
    public int health;
    public int treasure;
	// Use this for initialization
	void Start () {
        
        //if (SystemInfo.deviceType == DeviceType.Desktop)
       // { print(SystemInfo.deviceType);
            //isMaster = true;
       // }
        myText = GameObject.Find("PlayerText");
        if (isControllable == true)
        {
            
           myCam.active = true;
            audioTextObj = GameObject.Find("AudioTextNetwork");
            Ispawned();
            //audioTextObj.GetComponent<AudioTextNetwork>().what = 1;
            //myText.GetComponent<Text>().text = "Spawned now";
            
        }

    }
    void Update()
    {
        if (!photonView.isMine)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                syncInt = myPlayerInt;
                if (words != "")
                {
                    correctString = words;
                    myText.GetComponent<Text>().text = correctString;
                }
                transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
                transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
                timer = 5f;
            }
        }
        if (isControllable == true)
        {
            if (health <= 0)
            { PlayerLose(); }
            if (treasure >= 5)
            { PlayerWin(); }
        }
        if (isControllable == true && Input.GetKey(KeyCode.Space))
        {
            myPlayerInt++;
            CollectTreasure();
        }
    }
    public void OnTriggerEnter(Collider crash)
    {
        if (crash.gameObject.tag == "Trap")
        { health--;
            Trapped();
        }
        
    }
    public void OnCollisionEnter(Collision crash2)
    {
        
        if (crash2.gameObject.tag == "Enemy")
        { health--;
            FightMonster();
        }
    }
    [PunRPC]
    public void Ispawned()
    {
        words = "Player Spawned";
        myText.GetComponent<Text>().text = words;
        myPlayerInt = 1;
        syncInt = 2;
        //audioTextObj.GetComponent<AudioTextNetwork>().what = 2;
        //if (Input.GetKey(KeyCode.Space))
        //{
           
        //}
    }
    public void PlayerWin()
    {
        words = "Player Wins";
    }
    public void PlayerLose()
    {
        words = "Player Loses";
    }
    public void CollectTreasure()
    {
        words = "Collecting Treasure";
        treasure++;
    }
    public void FightMonster()
    {
        words = "FightingMonster";
    }
    public void KillMonster()
    {
        words = "Killing Monster";
    }
    public void Trapped()
    {
        words = "Caught by Trap";
    }
    public void DisarmTrap()
    {
        words = "Disarm Trap";
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(myPlayerInt);
            stream.SendNext(words);
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            //stream.SendNext(transform.rotation);

            // myThirdPersonController myC = GetComponent<myThirdPersonController>();
            //stream.SendNext((int)myC._characterState);
        }
        else
        {
            // Network player, receive data
            this.myPlayerInt = (int)stream.ReceiveNext();
            this.words = (string)stream.ReceiveNext();
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
            // this.correctPlayerRot = (Quaternion)stream.ReceiveNext();

            // myThirdPersonController myC = GetComponent<myThirdPersonController>();
            //myC._characterState = (CharacterState)stream.ReceiveNext();
        }
    }
}
