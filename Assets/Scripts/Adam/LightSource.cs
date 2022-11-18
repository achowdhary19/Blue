using System;
using UnityEditor.Experimental.GraphView;
using UnityEditor.TextCore.Text;
using UnityEngine;

namespace Scripts
{
    public class LightSource : MonoBehaviour
    {
        public LayerMask avoidPlayerCollision;
        public LayerMask everythingMask;
        public PlayerLifeController lifeController;

        private RaycastHit[] _hits;
        private ISwitch[] _iSwitchArray;

        private void Start()
        {
            _hits = new RaycastHit[10];
            _iSwitchArray = new ISwitch[10];
        }

        private void OnTriggerStay(Collider other)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (other.transform.position - transform.position), out hit, everythingMask))
            {
                ISwitch iswitch = hit.collider.gameObject.GetComponent<ISwitch>();
                if (iswitch != null)
                {
                    iswitch.Switch(true);
                    Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.green);
                }

                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.blue);
                    
                    _hits = Physics.RaycastAll(transform.position, other.transform.position - transform.position, 20.0f);
            
                    bool keyInView = false;
                    bool playerInView = false;
                    for (int i = 0; i < _hits.Length; i++)
                    {
                        RaycastHit subHit = _hits[i];
                        _iSwitchArray[i] = subHit.collider.gameObject.GetComponent<ISwitch>();

                        ISwitch tempISwitchHit = null;
                        if (_iSwitchArray[i] != null)
                        {
                            tempISwitchHit = _iSwitchArray[i];
                            keyInView = true;
                        }

                        if (subHit.collider.CompareTag("Player"))
                        {
                            playerInView = true;
                        }

                        if (keyInView && tempISwitchHit != null && playerInView)
                        {
                            Debug.Log("Player blocking key");
                            _iSwitchArray[i].Switch(false);
                        }
                    }
                    //Debug.Log("In direct light");
                    lifeController.inLight = true;
                }
                else
                {
                    Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.red);
                }
            }
            
            /*for (int i = 0; i < _hits.Length; i++)
            {
                RaycastHit hit = _hits[i];
                
                _iSwitchArray[i] = hit.collider.gameObject.GetComponent<ISwitch>();
                if (_iSwitchArray[i] != null)
                {
                    _iSwitchArray[i].Switch(true);
                    Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.green);
                }
                
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.blue);
                    //Debug.Log("In direct light");
                    lifeController.inLight = true;
                }
            }*/
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Trigger Exit");
            _hits = Physics.RaycastAll(transform.position, other.transform.position - transform.position, 20.0f);
            
            for (int i = 0; i < _hits.Length; i++)
            {
                RaycastHit hit = _hits[i];
                _iSwitchArray[i] = hit.collider.gameObject.GetComponent<ISwitch>();
                
                if (_iSwitchArray[i] != null)
                {
                    Debug.Log("Switch trigger exit");
                    _iSwitchArray[i].Switch(false);
                }
            }
            /*RaycastHit hit;
            if (Physics.Raycast(transform.position, (other.transform.position - transform.position), out hit,
                    avoidPlayerCollision))
            {
                Debug.Log("Switch trigger exit - player avoid");
                ISwitch iswitch = hit.collider.gameObject.GetComponent<ISwitch>();
                if (iswitch != null)
                {
                    iswitch.Switch(false);
                }
            }*/
        }
    }
}