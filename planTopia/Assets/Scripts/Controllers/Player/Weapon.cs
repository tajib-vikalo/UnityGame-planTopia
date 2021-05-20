using planTopia.ScriptabileObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace planTopia.Controllers.Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<ShootingAttributes> Weapons;
        private SkinnedMeshRenderer Renderer { get; set; }

        private void Start()
        {
            Renderer = this.GetComponent<SkinnedMeshRenderer>();
        }
        private void SetRedWeapon() => Renderer.material = Weapons.Where(x => x.name == Constants.Tag.RedWeapon).FirstOrDefault().Weapon;
        private void SetYellowWeapon() => Renderer.material = Weapons.Where(x => x.name == Constants.Tag.YellowWeapon).FirstOrDefault().Weapon;
        private void SetBlueWeapon() => Renderer.material = Weapons.Where(x => x.name == Constants.Tag.BlueWeapon).FirstOrDefault().Weapon;
        private void SetGreenWeapon() => Renderer.material = Weapons.Where(x => x.name == Constants.Tag.GreenWeapon).FirstOrDefault().Weapon;
        private void SetNormalWeapon() => Renderer.material = Weapons.Where(x => x.name == Constants.Tag.NormalWeapon).FirstOrDefault().Weapon;
    
    }
}
