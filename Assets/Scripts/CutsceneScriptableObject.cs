using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cutscene Example", menuName = "ScriptableObjects/Cutscene Data")]
public class CutsceneScriptableObject : ScriptableObject
{
    // timelines of when events occur
    public List<float> eventTimesActorA = new List<float>(); 
    public List<CutscenePlayer.Events> eventsA = new List<CutscenePlayer.Events>();
    public List<string> informationA = new List<string>();

    public List<float> eventTimesActorB = new List<float>();
    public List<CutscenePlayer.Events> eventsB = new List<CutscenePlayer.Events>();
    public List<string> informationB = new List<string>();
    /// movement is always: V(0,0,0)
    /// talk is always normal string data
}
