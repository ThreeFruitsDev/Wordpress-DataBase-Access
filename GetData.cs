using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetData : MonoBehaviour
{
    public void GetDataFrom(string url = "websitename/GetData.php")
    {
        StartCoroutine(GetDataIE(url));
    }
    private IEnumerator GetDataIE(string url)
    {
        WWWForm wWWForm = new WWWForm();
        //if you want add some restriction
        //wWWForm.AddField("page", 1);
        //wWWForm.AddField("perpage", 10);
        using (UnityWebRequest www = UnityWebRequest.Post(url, wWWForm))
        {
            www.certificateHandler = new BypassAllCertificate();
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string _txt = www.downloadHandler.text;
            }
        }
    }
}
