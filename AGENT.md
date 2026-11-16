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
- Unity Hub instalado (Flatpak). El editor de Unity se está instalando (lo hace el usuario).
- .NET SDK 10 y VS Code con C# Dev Kit disponibles.
- ✅ Lección 0.1: solución `csharp/TopDown.slnx` con `TopDown.Core` (netstandard2.1, C# 9) y
  `Playground`. `WaveMath.EnemyCount` con guard clauses y `checked`. Vistos: top-level statements,
  excepciones, fail fast, try/catch, overflow de `int`.
- Siguiente paso: inicializar Git y primer commit; luego **lección 0.2** (clase `Health`).

Mantén esta sección al día cuando se complete un paso.
