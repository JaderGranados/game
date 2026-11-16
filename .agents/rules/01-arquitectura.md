# 01 · Arquitectura (ligera)

Juego: **top-down shooter 3D**. Elegimos una arquitectura **ligera**: buenas prácticas
sin frameworks de inyección de dependencias. Si más adelante hace falta algo más formal
(VContainer, máquina de estados completa), se decide juntos y se documenta.

## Principios
1. **Separar la lógica de la presentación.** Las reglas del juego (vida, puntuación, cálculo
   de oleadas) se escriben en C# puro, sin `UnityEngine`, para poder testearlas.
   Los `MonoBehaviour` son adaptadores finos que conectan esa lógica con Unity.
2. **Datos en ScriptableObjects.** Los valores ajustables (velocidad, vida, cadencia de
   disparo, oleadas) viven en assets `*Config`, no en números fijos dentro del código.
3. **Comunicación por event channels.** Los sistemas que no deben conocerse (por ejemplo,
   el HUD y el jugador) se comunican mediante canales de eventos `ScriptableObject`.
   Para una relación directa padre-hijo dentro del mismo prefab se puede usar una referencia directa.
4. **Input abstraído.** El gameplay lee el input a través de un `InputReader` (ScriptableObject)
   que usa el **Input System** nuevo. Ningún script de gameplay lee teclas directamente.
5. **Object pooling** para objetos que se crean y destruyen a menudo (proyectiles, enemigos),
   usando `UnityEngine.Pool.ObjectPool<T>`.
6. **Nada de singletons globales** ni `FindObjectOfType` en el gameplay. Las dependencias se
   asignan en el Inspector (`[SerializeField]`) o las pasa quien crea el objeto.
7. **Una responsabilidad por componente.** Por ejemplo, `PlayerMovement` y `PlayerShooter`
   van separados en lugar de un único `Player` que lo hace todo.

## Capas y ensamblados (Assembly Definitions)
| Ensamblado               | Contenido                                     | Puede depender de          |
|--------------------------|-----------------------------------------------|----------------------------|
| `TopDown.Core`           | Lógica en C# puro (`noEngineReferences: true`) | nada                       |
| `TopDown.Runtime`        | MonoBehaviours, ScriptableObjects, UI          | Core, Input System, uGUI   |
| `TopDown.Editor`         | Herramientas de editor                         | Runtime, Core              |
| `TopDown.Tests.EditMode` | Tests de Core                                  | Core, Test Framework       |

Regla de dependencias: **Core no depende de nada**, y Runtime nunca depende de Editor ni de Tests.

## Decisiones
Cada decisión de arquitectura nueva se anota en `docs/decisiones.md` (qué decidimos, por qué
y qué alternativas descartamos).
