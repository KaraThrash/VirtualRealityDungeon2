using UnityEngine;
using System.Collections;

public class PlayerMovement : Photon.MonoBehaviour
{
    public bool isControllable;
    public float speed;
    public GameObject forwardObj;
    public GameObject target;
    public GameObject myCam;
    public GameObject rightObj;
    public GameObject upObj;
	// Use this for initialization
	void Start () {
        
       // GetComponent<Renderer>().material.color = Color.blue;

    }

    // Update is called once per frame
    void Update()
    {
        if (isControllable == true)
        {
            //Move();
            if (Input.GetButton("joystick button 0"))
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(forwardObj.transform.position.x, transform.position.y, forwardObj.transform.position.z), speed * Time.deltaTime);
                //transform.Translate(Vector3.forward * speed * Time.deltaTime); }
               // ControllerMove();
                

            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (forwardObj.transform.position - transform.position), out hit))
            {
                target = hit.transform.gameObject;
            }
            if (Input.GetButtonDown("joystick button 1") && target != null)
            { Activate(); }
        }
    }
    //public void OnMouseDown()
    // { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
    public void Activate()
    {
        if (target != null)
        {

            if (target.name == "Trap(Clone)")
            {
                Destroy(target.gameObject);
                target = null;
                GetComponent<Player>().DisarmTrap();
            }
            if (target.name == "Monster(Clone)")
            {
                Destroy(target.gameObject);
                target = null;
                GetComponent<Player>().KillMonster();
            }
            //if (target.name == "TrapGasSize(Clone)" || target.name == "TrapFloorSize(Clone)")
            //        {
            //            Destroy(target.gameObject);
            //            target = null;
            //            GetComponent<Player>().DisarmTrap();
            //        }
         
            //    if (target.name == "MonsterGhost(Clone)" || target.name == "MonsterBrute(Clone)")
            //    {
            //        Destroy(target.gameObject);
            //        target = null;
            //        GetComponent<Player>().KillMonster();
            //    }
        }
    }
    public void ControllerMove()
    {
        if (Input.GetAxis("Vertical") != 0)
        {

            //Vector3
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(forwardObj.transform.position.x,0, forwardObj.transform.position.z),  speed * Input.GetAxis("Vertical") * Time.deltaTime); }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 targetDir = rightObj.transform.position - transform.position;
            float step = speed * 0.2f * Input.GetAxis("Horizontal") * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);

            //myCam.transform.Rotate((rightObj.transform.position - transform.position ) * Input.GetAxis("Horizontal") * Time.deltaTime);
            //transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        //if (Input.GetAxis("Vertical") != 0)
        //{
        //    Vector3 targetDir = upObj.transform.position - transform.position;
        //    float step = speed * 0.2f * Input.GetAxis("Vertical") * Time.deltaTime;
        //    Vector3 newDirUP = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //    Debug.DrawRay(transform.position, newDirUP, Color.red);
        //    transform.rotation = Quaternion.LookRotation(newDirUP);




        //   // myCam.transform.Rotate(rightObj.transform.position * Input.GetAxis("Vertical") * Time.deltaTime);
        //    //transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        //}
        if (Input.GetButton("joystick button 4"))
            { transform.Translate(Vector3.right * -speed  * Time.deltaTime); }
        if (Input.GetButton("joystick button 5"))
            { transform.Translate(Vector3.right * speed  * Time.deltaTime); }
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        { transform.Translate(Vector3.right * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A))
        { transform.Translate(Vector3.left * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.W))
        { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S))
        { transform.Translate(Vector3.forward * -speed * Time.deltaTime); }
    }
    //public void ButtonMove()
    //{ transform.position = Vector3.MoveTowards(transform.position, new Vector3(forwardObj.transform.position.x, 0, forwardObj.transform.position.z), speed * Input.GetAxis("Vertical") * Time.deltaTime); }

}
