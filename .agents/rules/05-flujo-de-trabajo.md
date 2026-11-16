# 05 · Flujo de trabajo

## Entorno
- Sistema: **Bazzite** (Fedora atómico/inmutable). Se instala software con **Flatpak**,
  no con `dnf`.
- Unity Hub: Flatpak `com.unity.UnityHub` (ya instalado). Se abre con
  `flatpak run com.unity.UnityHub`.
- Iniciar sesión, activar la licencia y descargar el editor son pasos que hace el usuario
  en la interfaz de Unity Hub.
- **.NET SDK 10** instalado en el sistema (`/usr/bin/dotnet`).
- Editor de código: **VS Code** (instalado con Homebrew, sin sandbox) con C# Dev Kit.

## Ciclo de cada paso
1. El agente explica el objetivo del paso y los conceptos nuevos.
2. El usuario lo implementa (en Unity o en el código).
3. El usuario lo prueba en Play Mode o con tests.
4. El agente revisa y resuelve dudas.
5. Commit con un mensaje claro.

## Git
- Un commit por paso completado. Mensajes en español, en imperativo y descriptivos:
  `Añade movimiento del jugador con Input System`.
- El agente no hace commit ni push sin que el usuario lo pida.

## Hoja de ruta (orientativa, se ajusta sobre la marcha)

### Módulo 0: C# fuera de Unity (carpeta `csharp/`)
Se practica en consola con .NET. Lo que se escribe aquí es la lógica real del juego y luego
se lleva a `TopDown.Core` en Unity.

Estructura:
```
csharp/
  TopDown.slnx
  src/TopDown.Core/          librería: lógica del juego (se copiará a Unity)
  src/Playground/            consola para experimentar
  tests/TopDown.Core.Tests/  NUnit (el mismo framework que usa Unity)
  bench/TopDown.Benchmarks/  BenchmarkDotNet (lección de memoria)
```
**Compatibilidad con Unity:** `TopDown.Core` apunta a `netstandard2.1` y usa
`<LangVersion>9.0</LangVersion>`, porque Unity 6 compila C# 9 sobre .NET Standard 2.1.
Así el código funciona en Unity sin cambios. La consola y los tests pueden usar `net10.0`.

Lecciones:
0.1. Fundamentos: tipos, variables, condicionales, bucles, métodos → `WaveMath.EnemyCount`.
0.2. Clases y encapsulación → `Health` (`TakeDamage`, `Heal`, `IsDead`).
0.3. Tests con NUnit → tests de `WaveMath` y `Health`.
0.4. Delegados y eventos (`event Action`) → eventos de `Health`, clase `Score`.
0.5. Interfaces → `IDamageable`.
0.6. Colecciones y genéricos → `List<T>`, `Dictionary`, nuestro propio `ObjectPool<T>`.
0.7. Memoria: `struct` frente a `class`, pila y heap, GC → medir con BenchmarkDotNet.

### Módulo 1: Unity
1. Instalar el editor y crear el proyecto (URP 3D); configurar Git y `.gitignore`.
2. Estructura de carpetas y Assembly Definitions.
3. Primer test: modelo `Health` en Core (TDD).
4. Escena de arena: suelo, paredes, cámara top-down.
5. Jugador: `InputReader` + movimiento con Rigidbody.
6. Apuntar con el ratón y rotar.
7. Disparo: proyectil + object pooling + `WeaponConfig`.
8. Daño y vida: `IDamageable`, `HealthComponent`.
9. Enemigos que persiguen + oleadas (`WaveSpawner`).
10. Event channels: puntuación y Game Over.
11. HUD con uGUI/TextMeshPro.
12. Pulido: audio, efectos, menú, build.
