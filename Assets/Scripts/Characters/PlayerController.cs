using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : Character
{

    public Transform Spine;

    public CinemachineVirtualCamera myCamera;

    public float rotSpeed;

    public Transform pePosition;

    public bool onGround = false;

    public float JumpForce;

    public float gforce;

    float mouseY = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Jump();

        Shoot();

        CheckGround();

        Gravity();

        ChangeWeapon();

    }

    void ChangeWeapon() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            actualWeapon = 0;
            EnableWeapon();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            actualWeapon = 1;
            EnableWeapon();
        }
    }

    float mouseYSpine;
    private void LateUpdate()
    {
        mouseYSpine += Input.GetAxis("Mouse Y") * rotSpeed;
        mouseYSpine = Mathf.Clamp(mouseY, -90f, 90f);
        Spine.transform.localRotation = Quaternion.Euler
            (mouseY, transform.rotation.y, transform.rotation.z);
    }

    void CheckGround() {
        RaycastHit ray;
        Physics.SphereCast
            (pePosition.transform.position, 0.2f,Vector3.down,out ray, 0.2f);
        if (ray.collider)
        {
            onGround = true;
        }
        else {
            onGround = false;
        }
    }

    void Shoot() {
        if (Input.GetButtonDown("Fire")) {
            ShootWeapon(1);
            GameManager._instance.HUDManager.UpdateHUD(myAmmunitions[ammoIndex]);
        }
    }

    void Move() {

        float mouseX = Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * rotSpeed;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        myAnimator.SetFloat("Y", vAxis);

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        Vector3 move = ((transform.forward * vAxis) + (transform.right * hAxis)) *  speed * Time.deltaTime;
        Quaternion bRotation = Quaternion.Euler(rigidBody.rotation.eulerAngles + (Vector3.up * mouseX * rotSpeed));

        rigidBody.MovePosition(transform.position + move);
        transform.rotation = bRotation;

        myCamera.transform.localRotation = Quaternion.Euler
            (mouseY, transform.rotation.y, transform.rotation.z);
    }

    void Jump() {
        if (onGround == true && Input.GetButton("Jump")) {
            rigidBody.AddRelativeForce(Vector3.up * JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pePosition.position, 0.2f);
    }

    void Gravity()
    {
        if(onGround == false) { }
            rigidBody.AddForce(Vector3.down * gforce);
    }

    public override void DoDamage(float damage)
    {
        Debug.Log("Entrei no player");
        myHealth.LoseHealth(damage);
        base.DoDamage(damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            Pickup itemPickup = collision.gameObject.GetComponent<Pickup>();
            itemPickup.PickUp(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}
