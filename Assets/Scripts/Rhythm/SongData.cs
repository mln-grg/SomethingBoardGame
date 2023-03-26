using UnityEngine;

[CreateAssetMenu(fileName = "Data",menuName ="Song Data")]
public class SongData : ScriptableObject
{
    public AudioClip song;
    public string songName;
    public float bpm;
}
