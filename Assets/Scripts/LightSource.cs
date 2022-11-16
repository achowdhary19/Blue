using UnityEditor.Experimental.GraphView;
using UnityEditor.TextCore.Text;
using UnityEngine;

namespace Scripts
{
    public class LightSource : MonoBehaviour
    {
        public LayerMask layerMask;
        public PlayerLifeController lifeController;
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //Debug.Log("In light radius");
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (other.transform.position - transform.position), out hit, layerMask))
                {
                    //Debug.Log("Ray hit - non player");
                    if (hit.collider.isTrigger && hit.collider.CompareTag("Player"))
                    {
                        Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.blue);
                        //Debug.Log("In direct light");
                        lifeController.inLight = true;
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.red);
                    }
                }
            }
        }
    }
}