using UnityEngine;
using UnityEngine.UI;

//using System.Collections;

public class AudioTextNetwork : Photon.MonoBehaviour
{
    private PhotonView myPhotonView;
    public Text myText;
    public AudioClip marco;
    public AudioClip polo;
    public int what;
    public string whatString;
    public int correctInt;
    public string correctString;
    public bool playSound;

    // Use this for initialization
    void Start () {
        myPhotonView = GetComponent<PhotonView>();
    }
	
	// Update is called once per frame
	void Update () {
        //myText.text = correctString;
        if (!photonView.isMine)
        {
            //correctString = whatString;
            //correctInt = what;
            //if (playSound == true)
            //{ print("I made a sound");
            //    playSound = false;
            //}
        }
    }
    
    public  void Ispawned()
    {
        //if (!this.enabled)
        //{
        //    return;
        //}
        what = 3;
        Debug.Log("Marco");
       // myText.text = "I spawned";
        whatString = "I what spawned";
      //  PhotonNetwork. 
        //m_Source.clip = marco;
        // m_Source.Play();
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(playSound);
            stream.SendNext(what);
        }
        else
        {
            // Network player, receive data
            this.playSound = (bool)stream.ReceiveNext();
            this.what = (int)stream.ReceiveNext();
        }
    }
}
