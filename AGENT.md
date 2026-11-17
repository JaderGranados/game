# AGENT.md

Guía para cualquier agente de IA que trabaje en este repositorio.

## Proyecto
Top-down shooter **3D** en **Unity 6 LTS (URP)**, con arquitectura **ligera** y buenas prácticas.
Es un **proyecto de aprendizaje**: el usuario lo construye desde cero, paso a paso, con la
guía del agente.

## Reglas
Lee y sigue **todas** las reglas de `.agents/rules/`, en orden:

1. [`00-modo-aprendizaje.md`](.agents/rules/00-modo-aprendizaje.md): **regla principal**. Enseñar, no hacer por el usuario.
2. [`01-arquitectura.md`](.agents/rules/01-arquitectura.md): capas, ensamblados y patrones.
3. [`02-estilo-csharp.md`](.agents/rules/02-estilo-csharp.md): convenciones de código.
4. [`03-unity-convenciones.md`](.agents/rules/03-unity-convenciones.md): carpetas, paquetes, física, prefabs.
5. [`04-testing.md`](.agents/rules/04-testing.md): tests EditMode de la lógica.
6. [`05-flujo-de-trabajo.md`](.agents/rules/05-flujo-de-trabajo.md): entorno, ciclo de cada paso, git y hoja de ruta.

Si dos reglas entran en conflicto, manda `00-modo-aprendizaje.md`.

## Estado actual
- Unity Hub (Flatpak) y Unity **6000.3.28f1** instalados. .NET SDK 10 y VS Code con C# Dev Kit.
- Git inicializado (rama `main`).
- Se descartó el Módulo 0 de C# en consola porque el usuario ya domina C#. Se borró `csharp/`;
  `WaveMath` quedó en el historial (commit `02a1522`) y se reescribirá en Unity con TDD.
- ✅ Paso 1: proyecto Unity 6.3 URP en `TopDownShooter/` (un solo repo en la raíz, `.gitattributes`
  en la raíz, Git LFS activo, paquetes de plantilla innecesarios eliminados).
- ✅ Paso 2: `Assets/_Project/` con `TopDown.Core` (noEngineReferences), `TopDown.Runtime` y
  `TopDown.Tests.EditMode`. VS Code se abre desde Unity mediante el wrapper
  `~/.local/share/unity-vscode/code` (`flatpak-spawn --host`), porque Unity corre en el sandbox de Flatpak.
- ✅ Paso 3: `WaveMath` (con `checked`) y `Health` en Core, con 28 tests EditMode. Decisión: recibir daño
  o curarse estando muerto es un **no-op** (es una situación normal del juego, no un error del programador).
  Los paquetes `com.unity.sdk.*`, `toolchain.*` y `sysroot.*` los restaura el editor: no se quitan.
- ✅ Paso 4: escena `Assets/_Project/Scenes/Arena.unity` (arena de 30×30 m dentro de `Environment`, con escala 1;
  cámara en (0, 20, -10) a 65°). Vistos: GameObject/Transform/componentes, YAML de la escena, fileID/GUID,
  transform local frente a global, cuaterniones.
- ✅ Paso 5a: materiales `Ground`, `Wall` y `Player` (URP/Lit). Visto con un `LifecycleProbe` temporal (ya borrado):
  orden del ciclo de vida, `Update` frente a `FixedUpdate`, serialización por nombre de campo (`FormerlySerializedAs`).
  El GameObject `Player` se borró: se recreará como prefab en el 5d.
- ✅ Paso 5b: `Assets/_Project/Input/PlayerControls.inputactions` (map `Gameplay`: Move, Aim, Fire; WASD por
  posición física) con clase generada `TopDown.Input.PlayerControls` en `Scripts/Runtime/Input/`.
  Se quitaron las Project-wide Actions de la plantilla. `TopDown.Runtime` referencia `Unity.InputSystem`.
- ✅ Paso 5c: `InputReader` (ScriptableObject, `Scripts/Runtime/Input/`; asset en
  `ScriptableObjects/Input/`) que implementa `PlayerControls.IGameplayActions` y expone `MoveChanged`,
  `FirePressed`/`FireReleased` y `AimPosition`.
- ✅ Paso 5d: `PlayerConfig` (asset en `ScriptableObjects/Config/`), `PlayerMovement` (velocidad en XZ,
  conserva la Y de la física) y `Prefabs/Player.prefab` (Rigidbody con Interpolate y rotación X/Z congelada),
  instanciado en `Arena`. Vistos: prefabs y overrides, lambdas que no se desuscriben, interpolación, backing fields.
- Siguiente: **paso 6**, apuntar con el ratón (`PlayerAim`, screen → world con `Plane.Raycast`,
  rotación con `MoveRotation`, un prefab no puede referenciar objetos de la escena).

Mantén esta sección al día cuando se complete un paso.
