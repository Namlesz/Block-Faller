using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ValidatorController : MonoBehaviour
{
    private Variable vars;
    private ChromaticAberration aberration;
    public GameObject particle;

    private void Start()
    {
        vars = GameObject.Find("GameController").GetComponent<Variable>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (CompareTag(col.tag))
        {
            vars.AddPoint(1);

            Destroy(Instantiate(particle, col.transform.position, Quaternion.identity), 2f);
            Destroy(col.gameObject);
        }
        else
        {
            applyPostProccesing();
            Destroy(col.gameObject);
            vars.Hurt(1);
        }
    }

    void applyPostProccesing()
    {
        aberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        aberration.enabled.Override(true);
        aberration.intensity.Override(1f);

        Variable.shakeCam = true;
        Destroy(PostProcessManager.instance.QuickVolume(GameObject.Find("PPV").layer, 100f, aberration), vars.destroyEffecttime);
    }
}
