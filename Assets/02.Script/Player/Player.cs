using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using Photon.Pun;
namespace Asset.Script.Player
{
    public class Player : MonoBehaviour, IPunObservable
    {
        
        new Transform transform;
        PhotonView photonView = null;
        Vector3 currPos = Vector3.zero;
        Quaternion currRot = Quaternion.identity;

        void Awake()
        {
            transform = GetComponent<Transform>();
            photonView = GetComponent<PhotonView>();
            photonView.Synchronization = ViewSynchronization.UnreliableOnChange;

            photonView.ObservedComponents[0] = this;

            if (photonView.IsMine)
            {
                Camera.main.GetComponent<SmoothFollow>().target = transform;
            }

            currPos = transform.position;
            currRot = transform.rotation;

        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
            {
                transform.position = Vector3.Lerp(transform.position, currPos, Time.deltaTime * 3);
                transform.rotation = Quaternion.Slerp(transform.rotation, currRot, Time.deltaTime * 3);
            }

        }


        void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
            }
            else
            {
                currPos = (Vector3)stream.ReceiveNext();
                currRot = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}