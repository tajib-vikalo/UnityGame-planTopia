using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using planTopia.Controllers.Core;

namespace planTopia
{
    public class ZoomCameraController : MonoBehaviour
    {
        [SerializeField]
        private InputManagment InputManagment;

        private CinemachineFreeLook Camera;
        private void Start()
        {
            Camera = GetComponent<CinemachineFreeLook>();
            InputManagment.ZoomCamera += ZoomInOut;
        }

        private void ZoomInOut(bool zoomed)
        {
            if (zoomed)
                Camera.m_Lens.FieldOfView = 20;
            else
                Camera.m_Lens.FieldOfView = 40;
        }
    }
}
