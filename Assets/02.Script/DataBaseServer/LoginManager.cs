using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;
namespace Asset.Script.DataBase
{
    public class LoginManager : MonoBehaviour
    {
        [SerializeField] InputField id = null;
        [SerializeField] InputField password = null;


        string domain = "http://startream.iptime.org/";



        public void OnClickLogin()
        {
            StartCoroutine(Login());
        }

        public void OnClickSignup()
        {
            StartCoroutine(Signup());
        }

        IEnumerator Login()
        {
            WWWForm loginData = SetLoginData(id.text,password.text);
            UnityWebRequest www = UnityWebRequest.Post(domain + "login.php", loginData);

            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "1")
            {
                SceneManager.LoadScene("Lobby");
                NetWorkManager.GetID += () => id.text;
            }

            else
            {
            }
        }

        IEnumerator Signup()
        {
            WWWForm loginData = SetLoginData(id.text,password.text);


            UnityWebRequest www = UnityWebRequest.Post(domain + "signup.php", loginData);
            yield return www.SendWebRequest();

            Debug.Log(www.downloadHandler.text);
        }

        WWWForm SetLoginData(string id,string pw)
        {

            WWWForm loginData = new WWWForm();
            loginData.AddField("userId", id);
            loginData.AddField("userPw", pw);
            return loginData;
        }

    }
}