using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ValidatorController : MonoBehaviour
{
    Variable vars;
    ChromaticAberration aberration;
    private void Start()
    {
        vars = GameObject.Find("GameController").GetComponent<Variable>();

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        aberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        aberration.enabled.Override(true);
        aberration.intensity.Override(1f);

        Variable.shakeCam = true;
        Destroy(PostProcessManager.instance.QuickVolume(GameObject.Find("PPV").layer, 100f, aberration),vars.destroyEffecttime);

        if (CompareTag(col.tag))
        {
            Variable.points++;
            Debug.Log(Variable.points);
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
            Debug.Log("Mistake!");
        }
    }
}
