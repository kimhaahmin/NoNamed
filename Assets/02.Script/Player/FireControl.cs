using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace Asset.Script.Player
{
    public class FireControl : MonoBehaviour
    {
        [SerializeField] Transform firePosition = null;
        [SerializeField] AudioClip gunVoice = null;
        [SerializeField] float fireRate = 0.1f;

        GameObject bullet;
        AudioSource audioSource;
        bool canFire = true;

        PhotonView photonView = null;
        // Start is called before the first frame update
        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            photonView = GetComponent<PhotonView>();
            bullet = Resources.Load("Bullet") as GameObject;

        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
                return;

            if (Input.GetMouseButton(0) && canFire)
            {
                audioSource.PlayOneShot(gunVoice);
                StartCoroutine(Fire());
                BulletCreate();
                photonView.RPC("BulletCreate", RpcTarget.Others, null);
            }
        }

        IEnumerator Fire()
        {
            canFire = false;
            yield return new WaitForSecondsRealtime(fireRate);
            canFire = true;
        }

        [PunRPC]
        void BulletCreate()
        {
            Instantiate(bullet, firePosition.position, firePosition.rotation);
        }
    }
}