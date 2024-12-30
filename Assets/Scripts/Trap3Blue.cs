using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
namespace GameMechanics
{
    [RequireComponent(typeof(MeshCollider))]
    public class ActivatablePanel : MonoBehaviour
    {
        private Material panelMaterial;
 
        [SerializeField] private Color activatedColor = new Color(0, 0, 1, 0.5f); 
        [SerializeField] private Color blinkColor = new Color(0, 0, 0.5f, 1); 
        [SerializeField] private float durationBeforeDestruction = 0.5f;
        private void Awake()
        {
            panelMaterial = GetComponent<Renderer>().material;
        }
 
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ActivatePanel();
            }
        }
        private void ActivatePanel()
        {
            panelMaterial.color = activatedColor;
            StartCoroutine(HandleDestruction());
        }
 
        private IEnumerator HandleDestruction()
        {
            yield return new WaitForSeconds(durationBeforeDestruction);
            panelMaterial.color = blinkColor;
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    }
}
