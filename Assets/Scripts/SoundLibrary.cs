using UnityEngine;


[System.Serializable]
public struct SoundEffect 
{
    public string groundID;
    public AudioClip[] clips;
}


public class SoundLibrary : MonoBehaviour
{

    public SoundEffect[] soundEffects;

    public AudioClip GetClipFromName(string name)
    {
        foreach (SoundEffect soundEffect in soundEffects)
        {
            if (soundEffect.groundID == name)
            {
                return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
            }
        }
        return null;
    }

}