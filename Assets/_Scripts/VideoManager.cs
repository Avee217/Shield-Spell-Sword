using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]private List<VideoClip> Videos = new List<VideoClip>();

    [SerializeField] private Dictionary<string, List<VideoClip>> myVideoManager = new Dictionary<string, List<VideoClip>>();

    [SerializeField] private List<List<int>> myList = new List<List<int>>();
    // Start is called before the first frame update
    void Start()
    {
        //myVideoManager.Add("1", Videos);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
