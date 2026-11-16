# 03 · Convenciones de Unity

## Versión y paquetes
- Unity **6.3 LTS** (`6000.3.28f1`), instalado desde Unity Hub.
- Render pipeline: **URP** (plantilla "Universal 3D").
- Paquetes: Input System, Test Framework, uGUI (con TextMeshPro para el texto).
  Cualquier paquete nuevo se discute antes de añadirlo.

## Estructura de carpetas
Todo el contenido propio va dentro de `Assets/_Project/` para separarlo de los paquetes y
assets de terceros:
```
Assets/_Project/
  Art/          Materials/, Models/, Textures/
  Audio/
  Prefabs/
  Scenes/
  ScriptableObjects/   Config/, Events/, Input/
  Scripts/
    Core/       (TopDown.Core.asmdef)
    Runtime/    (TopDown.Runtime.asmdef)  Combat/, Enemies/, Events/, Game/, Input/, Player/, UI/, ...
    Editor/     (TopDown.Editor.asmdef)
  Tests/
    EditMode/   (TopDown.Tests.EditMode.asmdef)
```

## Nombres de assets
- Prefabs: `PascalCase` (`Player.prefab`, `Enemy_Chaser.prefab`).
- ScriptableObjects: tipo + nombre (`PlayerConfig.asset`, `EnemyKilled.asset`).
- Escenas: `PascalCase` (`Bootstrap.unity`, `Arena.unity`).

## Física y movimiento
- El movimiento con física va en `FixedUpdate`; la lectura de input y la cámara, en
  `Update`/`LateUpdate`.
- Unity 6: usar `Rigidbody.linearVelocity` (no `velocity`, que está obsoleto).
- Preferir capas y la matriz de colisiones antes que comprobar tags en el código.
- No usar `Camera.main` en `Update`; cachear la cámara.

## Escenas y prefabs
- Los objetos reutilizables siempre como prefab. La escena solo compone prefabs.
- Preferir prefab variants a duplicar prefabs.

## Control de versiones
- `.gitignore` estándar de Unity (ignorar `Library/`, `Temp/`, `Logs/`, `UserSettings/`, etc.).
- Asset Serialization: **Force Text**; Version Control: **Visible Meta Files**.
- Siempre se suben los `.meta` junto con su asset.
