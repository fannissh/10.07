using UnityEngine;

class ClickExplosion : MonoBehaviour
{
    [SerializeField] Transform cursor3D;

    void Update()
    {
        Camera cam = Camera.main;
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            cursor3D.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("WasHit: " + hit.collider.name);
            }

            cursor3D.gameObject.SetActive(true);
        }
        else
        {
            cursor3D.gameObject.SetActive(false);
        }
    }
}
