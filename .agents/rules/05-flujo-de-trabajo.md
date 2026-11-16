# 05 · Flujo de trabajo

## Entorno
- Sistema: **Bazzite** (Fedora atómico/inmutable). Se instala software con **Flatpak**,
  no con `dnf`.
- Unity Hub: Flatpak `com.unity.UnityHub` (ya instalado). Se abre con
  `flatpak run com.unity.UnityHub`.
- Editor de Unity: **6000.3.28f1** (Unity 6.3 LTS), en `~/Unity/Hub/Editor/`.
- Proyecto de Unity: carpeta `TopDownShooter/` en la raíz del repo.
- Iniciar sesión, activar la licencia y descargar el editor son pasos que hace el usuario
  en la interfaz de Unity Hub.
- **.NET SDK 10** instalado en el sistema (`/usr/bin/dotnet`).
- Editor de código: **VS Code** (instalado con Homebrew, sin sandbox) con C# Dev Kit.
  Para integrarlo con Unity hace falta el paquete `com.unity.ide.visualstudio`.

## Ciclo de cada paso
1. El agente explica el objetivo del paso y los conceptos nuevos.
2. El usuario lo implementa (en Unity o en el código).
3. El usuario lo prueba en Play Mode o con tests.
4. El agente revisa y resuelve dudas.
5. Commit con un mensaje claro.

## Git
- Un commit por paso completado. Mensajes **en inglés**, en imperativo y descriptivos:
  `Add player movement with Input System`.
- El agente no hace commit ni push sin que el usuario lo pida.

## Hoja de ruta (orientativa, se ajusta sobre la marcha)

El Módulo 0 (C# en consola) se descartó: el usuario ya domina C#. Los conceptos de C#
que se comportan distinto en Unity se enseñan dentro de Unity, en el paso donde aparecen.

### Módulo 1: Unity
1. Crear el proyecto (Universal 3D) en `TopDownShooter/`; `.gitignore` de Unity; qué es cada
   carpeta (`Assets`, `Packages`, `ProjectSettings`, `Library`…) y qué se versiona; los `.meta`.
2. Estructura de carpetas y Assembly Definitions; integración con VS Code.
   Concepto: el C# de Unity (C# 9, .NET Standard 2.1, sin `Main`).
3. `TopDown.Core`: `WaveMath` y `Health` con TDD en el Test Runner (EditMode).
4. Escena de arena: suelo, paredes, cámara top-down.
   Conceptos: GameObject, Transform, componentes, qué se serializa en un `.unity`.
5. Jugador: `InputReader` + movimiento con Rigidbody.
   Conceptos: ciclo de vida de `MonoBehaviour`, `Update` frente a `FixedUpdate`, `[SerializeField]`.
6. Apuntar con el ratón y rotar.
7. Disparo: proyectil + object pooling + `WeaponConfig`.
   Conceptos: prefabs, ScriptableObjects, el `null` sobrecargado de Unity.
8. Daño y vida: `IDamageable`, `HealthComponent`.
9. Enemigos que persiguen + oleadas (`WaveSpawner`).
10. Event channels: puntuación y Game Over.
11. HUD con uGUI/TextMeshPro.
12. Pulido: audio, efectos, menú, build.
13. Rendimiento: Profiler, asignaciones por frame y GC.
