using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSystem : MonoBehaviour
{
    public LayerMask unitLayer;
    public Material selectedMaterial;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    SelectUnits();
                }
            }
        }
    }

    private void SelectUnits()
    {
        // Get the bounds of the BoxCollider representing the selection area
        Bounds selectionBounds = GetComponent<BoxCollider>().bounds;

        // Detect units within the selection bounds
        Collider[] hitColliders = Physics.OverlapBox(selectionBounds.center, selectionBounds.extents, Quaternion.identity, unitLayer);

        // Highlight selected units
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Unit"))
            {
                collider.GetComponent<Renderer>().material = selectedMaterial;
                // Store reference to selected unit
                // You can add it to a list or perform other actions here
            }
        }
    }

}
