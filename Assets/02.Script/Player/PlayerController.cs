using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    CharacterController controller;
    new Transform transform = null;


    Photon.Pun.PhotonView photonView = null;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        photonView = GetComponent<Photon.Pun.PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;

        Rotation();
        Move();
    }

    void Rotation()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(camRay, out rayLength))

        {

            Vector3 pointTolook = camRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));

        }


    }

    void Move()
    {
        float h, v;
        Vector3 moveDir;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        moveDir = (Vector3.forward * v) + (Vector3.right * h);

        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }

}
