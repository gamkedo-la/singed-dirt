using System;
using UnityEngine;
using UnityEngine.UI;

public class TankModel : MonoBehaviour {
    // ------------------------------------------------------
    // UI REFERENCE VARIABLES
    [Header("UI Reference")]
    // empty game objects marking parent location for each part of the tank
    public GameObject tankBase;
    public GameObject turretBase;
    public GameObject turret;
    public GameObject hat;
    public Transform shotSource;
    public Transform passiveCameraSource;
    public Transform chaseCameraSource;
    public Transform centerOfMass;

    [Header("Tank Part Selections")]
    public TankBaseKind tankBaseKind = TankBaseKind.standard;
    public TankTurretBaseKind turretBaseKind = TankTurretBaseKind.standard;
    public TankTurretKind turretKind = TankTurretKind.standard;
    public TankHatKind hatKind = TankHatKind.sunBlue;

    // instantiated prefabs for each part of the tank
    public GameObject tankBasePrefab = null;
    public GameObject turretBasePrefab = null;
    public GameObject turretPrefab = null;
    public GameObject hatPrefab = null;

    float _tankRotation = 133f;
    float _aimHorizontal = 0f;
    float _aimVertical = 15f;

    public void Start() {
        UpdateAvatar();
    }

    public float tankRotation
    {
        get
        {
            return _tankRotation;
        }
        set
        {
            _tankRotation = value;
            transform.localRotation = Quaternion.AngleAxis(_tankRotation, Vector3.up);
        }
    }

    public float turretRotation
    {
        get
        {
            return _aimHorizontal;
        }
        set
        {
            _aimHorizontal = value;
        }
    }

    public float turretElevation
    {
        get
        {
            return _aimVertical;
        }
        set
        {
            _aimVertical = value;
            turret.transform.localRotation = Quaternion.Euler(_aimVertical, 0, 0);
        }
    }

    public void UpdateAvatar() {
        // instantiate tank base
        if (tankBasePrefab != null) DestroyImmediate(tankBasePrefab);
        var prefab = PrefabRegistry.singleton.GetPrefab<TankBaseKind>(tankBaseKind);
        tankBasePrefab = Instantiate(
            prefab,
            tankBase.transform.position,
            tankBase.transform.rotation,
            tankBase.transform);

        // instantiate turret base
        if (turretBasePrefab != null) DestroyImmediate(turretBasePrefab);
        prefab = PrefabRegistry.singleton.GetPrefab<TankTurretBaseKind>(turretBaseKind);
        turretBasePrefab = Instantiate(
            prefab,
            turretBase.transform.position,
            turretBase.transform.rotation,
            turretBase.transform);

        // instantiate turret
        if (turretPrefab != null) DestroyImmediate(turretPrefab);
        prefab = PrefabRegistry.singleton.GetPrefab<TankTurretKind>(turretKind);
        turretPrefab = Instantiate(
            prefab,
            turret.transform.position,
            turret.transform.rotation,
            turret.transform
        );

        // instantiate hat
        if (hatPrefab != null) DestroyImmediate(hatPrefab);
        prefab = PrefabRegistry.singleton.GetPrefab<TankHatKind>(hatKind);
        hatPrefab = Instantiate(
            prefab,
            hat.transform.position,
            hat.transform.rotation,
            hat.transform);

    }

    public void ActivateMeshes(bool action) {
        MeshRenderer[] allMeshes = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < allMeshes.Length; i++) {
            allMeshes[i].enabled = action;
        }
    }
}
