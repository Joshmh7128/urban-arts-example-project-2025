using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{
    // this is our cutscene which we are working with
    public CutsceneScriptableObject cutsceneObject;
    bool cutscenePlaying;
    // define our two actors to be used by the scriptable object
    public Transform actorA, actorB;

    public enum Events
    {
        Move,
        Talk
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (cutscenePlaying) return;
            // start the cutscene
            StartCutscene();
        }
    }

    void StartCutscene()
    {
        StartCoroutine(RunCutsceneActorA());
        StartCoroutine(RunCutsceneActorB());
    }

    // our position within the cutscene
    int actorAcpos = 0;
    int actorBcpos = 0;

    IEnumerator RunCutsceneActorA()
    {
        // run our state
        RunStateA(cutsceneObject.eventsA[actorAcpos]);
        // advance
        yield return new WaitForSecondsRealtime(cutsceneObject.eventTimesActorA[actorAcpos]);
        actorAcpos++;
        if (actorBcpos == cutsceneObject.eventsB.Count)
            yield return null;

        // loop
        StartCoroutine(RunCutsceneActorA());
    }

    IEnumerator RunCutsceneActorB()
    {
        // run our state
        RunStateB(cutsceneObject.eventsB[actorBcpos]);
        // advance
        yield return new WaitForSecondsRealtime(cutsceneObject.eventTimesActorB[actorBcpos]);
        actorBcpos++;
        if (actorBcpos == cutsceneObject.eventsB.Count)
            yield return null;

        // loop 
        StartCoroutine(RunCutsceneActorB());
    }

    void RunStateA(Events e)
    {
        switch (e)
        {
            case Events.Move:
                Debug.Log("Run State A Movement");
                actorA.gameObject.GetComponent<CutsceneActor>().inputPosition = GetVectorFromString(cutsceneObject.informationA[actorAcpos]);
                actorA.gameObject.GetComponent<CutsceneActor>().CalculateTargetPosition();
                break;
            case Events.Talk:
                Talk(cutsceneObject.informationA[actorAcpos]);
                break;
        }
    }

    void RunStateB(Events e)
    {
        switch (e)
        {
            case Events.Move:
                actorB.gameObject.GetComponent<CutsceneActor>().inputPosition = GetVectorFromString(cutsceneObject.informationB[actorBcpos]);
                actorB.gameObject.GetComponent<CutsceneActor>().CalculateTargetPosition();
                break;
            case Events.Talk:
                Talk(cutsceneObject.informationB[actorBcpos]);
                break;
        }
    }


    void Talk(string s)
    {
        Debug.Log(s);
    }

    Vector3 GetVectorFromString(string str)
    {
        float x, y, z;
        string sx = "", sy = "", sz = "";
        bool gx = false, gy = false, gz = false;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                gx = true;
                continue;
            }

            // if we're getting X, build our X string
            if (gx == true && str[i] != ',')
            {
                sx += str[i];
            } else if (gx == true && str[i] == ',')
            {
                gx = false;
                gy = true;
                continue;
            }

            // if we're getting Y, build our Y string
            if (gy == true && str[i] != ',')
            {
                sy += str[i];
            }
            else if (gy == true && str[i] == ',')
            {
                gy = false;
                gz = true;
                continue;
            }

            // if we're getting Y, build our Y string
            if (gz == true && str[i] != ')')
            {
                sz += str[i];
            }
            else if (gz == true && str[i] == ')')
            {
                gz = false;
                break;
            }

        }

        // set our x, y, and z
        x = float.Parse(sx);
        y = float.Parse(sy);
        z = float.Parse(sz);

        // return our vector
        Debug.Log(sx + ", " + sy + ", " + sz);
        return new Vector3(x, y, z);
    }

}
