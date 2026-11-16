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
- 🔄 Paso 5a (en curso): materiales `Ground`, `Wall` y `Player` (URP/Lit), cápsula `Player` y script temporal
  `Runtime/Diagnostics/LifecycleProbe.cs` para estudiar el ciclo de vida. Pendiente: usar `logEveryNFrames`,
  repetir el experimento del componente desactivado antes de Play, la pregunta de renombrar un campo
  serializado (`FormerlySerializedAs`), borrar el probe y hacer el commit.
- Siguiente: 5b (asset de Input Actions), 5c (`InputReader`), 5d (movimiento con `Rigidbody`).

Mantén esta sección al día cuando se complete un paso.
