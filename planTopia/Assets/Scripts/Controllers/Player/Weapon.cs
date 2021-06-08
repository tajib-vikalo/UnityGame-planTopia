using planTopia.ScriptabileObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace planTopia.Controllers.Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<ShootingAttributes> Weapons;
        [SerializeField]
        private AudioSource GunLoadingAudio;
        [SerializeField]
        private Image UIGunImage;
        [SerializeField]
        private Text UIAmmunation;
        private SkinnedMeshRenderer Renderer { get; set; }
        private AudioSource Audio { get; set; }


        private void Start()
        {
            Renderer = this.GetComponentInChildren<SkinnedMeshRenderer>();
            Audio = this.GetComponent<AudioSource>();
            SetGreenWeapon();
        }
        private void SetWeaponAndSound(ShootingAttributes Gun)
        {
            Renderer.material = Gun.Weapon;
            Audio.clip = Gun.Sound;
            UIGunImage.sprite = Gun.UIImage;
            Gun.CurrentAmmunation = Gun.MaxAmmunation;
            UIAmmunation.text= $"{Gun.CurrentAmmunation}/{Gun.MaxAmmunation}";
            this.GetComponent<ShootingWeapon>().SetShootingAttributes(Gun);
            GunLoadingAudio.Play();
        }
        public void SetRedWeapon()
        {
            var Gun = Weapons.Where(x => x.name == Constants.Tag.RedWeapon).FirstOrDefault();
            if (Gun != null)
                SetWeaponAndSound(Gun);
        }
        public void SetYellowWeapon()
        {
            var Gun = Weapons.Where(x => x.name == Constants.Tag.YellowWeapon).FirstOrDefault();
            if (Gun != null)
                SetWeaponAndSound(Gun);
        }
        public void SetBlueWeapon()
        {
            var Gun = Weapons.Where(x => x.name == Constants.Tag.BlueWeapon).FirstOrDefault();
            if (Gun != null)
                SetWeaponAndSound(Gun);
        }
        public void SetGreenWeapon()
        {
            var Gun = Weapons.Where(x => x.name == Constants.Tag.GreenWeapon).FirstOrDefault();
            if (Gun != null)
                SetWeaponAndSound(Gun);
        }
        public void SetBlackWeapon()
        {
            var Gun = Weapons.Where(x => x.name == Constants.Tag.BlackWeapon).FirstOrDefault();
            if (Gun != null)
                SetWeaponAndSound(Gun);
        }

    }
}
