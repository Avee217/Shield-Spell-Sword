using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string Name;
    public Sprite icon;

    public List<VideoClip> Videos;
    
}
