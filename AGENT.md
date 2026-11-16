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
- Siguiente paso: **Módulo 1, paso 1**. Crear el proyecto Unity (Universal 3D) en `TopDownShooter/`.

Mantén esta sección al día cuando se complete un paso.
