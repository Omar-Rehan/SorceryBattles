using UnityEngine;
using UnityEngine.UI;
using HTC.UnityPlugin.Vive;

public class LineRendererMaintainer : MonoBehaviour {
    RaycastHit m_hitInfo;
    public HandRole m_handRole;
    //private LayerMask m_buttonLayerMask;
    private LineRenderer m_lineRenderer;

    void Start() {
        m_lineRenderer = transform.GetComponent<LineRenderer>();
        //m_buttonLayerMask = LayerMask.NameToLayer("Button");
    }
    void Update() {
        UpdateLineRenderer();
        //CheckButtonsClicked();
    }

    private void UpdateLineRenderer() {
        if (m_lineRenderer != null) {
            m_lineRenderer.SetPosition(0, transform.position);
            m_lineRenderer.SetPosition(1, transform.position + 100.0f * transform.forward);
            m_lineRenderer.startWidth = 0.0f;
            m_lineRenderer.endWidth = 0.01f;
        } else {
            Debug.Log("No line renderer!");
        }
    }
    //private void CheckButtonsClicked() {
    //    if (ViveInput.GetPressDown(m_handRole, ControllerButton.Trigger)) {
    //        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out m_hitInfo, Mathf.Infinity, ~m_buttonLayerMask)) {
    //            Debug.Log("collided with " + m_hitInfo.transform.gameObject.name);
    //            m_hitInfo.transform.gameObject.SetActive(false);
    //            Button button = m_hitInfo.transform.gameObject.GetComponent<Button>();
    //            if (button != null) button.onClick.Invoke();
    //        }
    //    }
    //}
}
