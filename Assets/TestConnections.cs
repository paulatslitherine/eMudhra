using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class TestConnections : MonoBehaviour
{
    private TMP_Text console;

    private IEnumerator Start()
    {
        console = GetComponent<TMP_Text>();
        string[] prefixes =
        {
            "dv-g3b",
            "dv-g3c",
            "ov-g3b",
            "ov-g3c",
            "ev-g3b",
            "ev-g3c",
            "dv-g3b-aaa",
            "dv-g3c-aaa",
            "ov-g3b-aaa",
            "ov-g3c-aaa",
            "ev-g3b-aaa",
            "ev-g3c-aaa",
            "dv-g3b-noct",
            "dv-g3c-aaa-noct"
        };

        foreach (string prefix in prefixes)
        {
            Uri uri = new Uri($"https://{prefix}-emudhra.we-have-a-problem.com/");
            using UnityWebRequest request = UnityWebRequest.Get(uri);
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    console.text += $"{uri} <color=red>CONNECTED!</color>\n";
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    console.text += $"{uri} <color=green>BLOCKED</color>\n";
                    break;
                default:
                    console.text += $"{uri} <color=yellow>{request.result}</color>\n";
                    break;
            }
        }
    }
}
