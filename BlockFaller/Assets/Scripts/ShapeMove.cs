using UnityEngine;

public class ShapeMove : MonoBehaviour
{
    void Start()
    {
        Variable vars = GameObject.Find("GameController").GetComponent<Variable>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-vars.speed)*Time.fixedDeltaTime*1000);
    }
    private void LateUpdate()
    {
        if (Variable.lostFlag)
        {
            Destroy(this.gameObject);
        }
    }
}
