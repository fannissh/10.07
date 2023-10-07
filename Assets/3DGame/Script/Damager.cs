using UnityEngine;

class Damager : MonoBehaviour
{

    [SerializeField] int damage = 5;
    void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;

        HPObject hpObject = otherGameObject.GetComponent<HPObject>();

        if (hpObject != null)
        {
            // Debug.Log(other.gameObject.name);

            hpObject.Damage(damage);
        }


        

    }


}
