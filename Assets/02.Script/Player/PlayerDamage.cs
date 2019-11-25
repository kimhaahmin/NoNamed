using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace Asset.Script.NetWork
{
    public class PlayerDamage : MonoBehaviour
    {
        Player.FireCtrl fireCtrl;
        Photon.Pun.PhotonView photonView;
        CharacterController character;
        PlayerController playerController;
        SkinnedMeshRenderer[] renderers;
        AudioSource audioSource;
        new Transform transform;

        [SerializeField] AudioClip dieAudio;
        [SerializeField] const int HP = 100;
        [SerializeField] int currHP;

        // Start is called before the first frame update
        void Awake()
        {
            currHP = HP;
            transform = GetComponent<Transform>();
            character = GetComponent<CharacterController>();
            renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            audioSource = GetComponent<AudioSource>();
            playerController = GetComponent<PlayerController>();
            photonView = GetComponent<Photon.Pun.PhotonView>();
            fireCtrl = GetComponent<Player.FireCtrl>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Bullet")
            {
                currHP -= other.gameObject.GetComponent<Bullet>().damage;
                Destroy(other.gameObject);
                if (currHP <= 0)
                {
                    audioSource.PlayOneShot(dieAudio);
                    photonView.RPC("PlayerDieRPC", RpcTarget.All);
                }
            }
        }

        [PunRPC]
        void PlayerHit(Collider collider)
        {
            Destroy(collider.gameObject);
        }

        [PunRPC]
        void PlayerDieRPC()
        {
            StartCoroutine(PlayerDie());
        }

        IEnumerator PlayerDie()
        {
            PlayerEnable(false);
            yield return new WaitForSecondsRealtime(5f);
            transform.position = new Vector3(Random.Range(-21.0f, 20.0f), 0, Random.Range(-21.0f, 20.0f));
            currHP = HP;
            PlayerEnable(true);

        }

        void PlayerEnable(bool isVisible)
        {
            character.enabled = isVisible;
            playerController.enabled = isVisible;
            fireCtrl.enabled = isVisible;
            foreach (SkinnedMeshRenderer renderer in renderers)
                renderer.enabled = isVisible;
        }
    }
}
