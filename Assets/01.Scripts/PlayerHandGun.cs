using UnityEngine;

public class PlayerHandGun : PlayerWeapon
{

    private int nowAmmo;


    void Start()
    {
        camera = Camera.main;
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
