using UnityEngine;

public class ClickComponentSwitch : MonoBehaviour
{
    [SerializeField] Behaviour component;

    void OnMouseDown()
    {
        component.enabled = !component.enabled;       // switch egyszerûsítettje

    }
}
