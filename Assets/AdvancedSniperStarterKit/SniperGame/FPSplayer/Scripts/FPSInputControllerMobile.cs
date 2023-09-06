using UnityEngine;
using UnityEngine.UI;

public class FPSInputControllerMobile : MonoBehaviour
{

    private GunHanddle gunHanddle;
    private FPSController FPSmotor;

    public TouchScreenVal touchMove;
    public TouchScreenVal touchAim;
    public TouchScreenVal touchShoot;
    public TouchScreenVal touchZoom;
    public TouchScreenVal touchJump;

    public Texture2D ImgButton;
    public float TouchSensMult = 0.05f;
    public Slider zoomSlider;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Awake()
    {
        FPSmotor = GetComponent<FPSController>();
        gunHanddle = GetComponent<GunHanddle>();
    }

    void Update()
    {
        if (Input.touchCount <= 1)
        {
            Vector2 aimdir = touchAim.OnDragDirection(true);
            if (Input.touchCount > 1) return;
            FPSmotor.Aim(new Vector2(aimdir.x, -aimdir.y) * TouchSensMult);
            Vector2 touchdir = touchMove.OnTouchDirection(false);

        }
        //FPSmotor.Move (new Vector3 (touchdir.x, 0, touchdir.y));

        //FPSmotor.Jump (Input.GetButton ("Jump"));

        /* if (touchShoot.OnTouchPress())
         {

         }*/

       /* if (touchZoom.OnTouchRelease())
        {
            gunHanddle.ZoomToggle();
        }*/

    }
    public void ZoomIn()
    {
        if (gunHanddle.CurrentGun.IndexZoom < gunHanddle.CurrentGun.ZoomFOVLists.Length - 1)
            gunHanddle.CurrentGun.IndexZoom += 1;
        gunHanddle.CurrentGun.Zooming = true;
    }
    public void ZoomOut()
    {
        if (gunHanddle.CurrentGun.IndexZoom > 0)
            gunHanddle.CurrentGun.IndexZoom -= 1;
        else
            gunHanddle.CurrentGun.Zooming = false;
    }
    public void Shoot()
    {
        gunHanddle.Shoot();
    }

    void OnGUI()
    {
        touchAim.Draw();
        //touchZoom.Draw();
    }
}
