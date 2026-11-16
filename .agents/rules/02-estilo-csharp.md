# 02 · Estilo de C#

- Namespaces por carpeta: `TopDown.Core`, `TopDown.Player`, `TopDown.Combat`, etc.
- `PascalCase` para tipos, métodos, propiedades y eventos. `camelCase` para campos privados
  y variables locales, sin prefijo `_` ni `m_`.
- Campos expuestos al Inspector: `[SerializeField] private`, **nunca** `public` solo para
  que aparezcan en el Inspector.
- En los ScriptableObject de configuración, usar propiedades de solo lectura:
  `[field: SerializeField] public float MoveSpeed { get; private set; } = 5f;`
- Marcar las clases como `sealed` salvo que estén pensadas para heredarse.
- Eventos C#: `event Action<T>`. Suscribirse en `OnEnable` y desuscribirse en `OnDisable`.
  Toda suscripción debe tener su desuscripción.
- Validar con `[Min]`, `[Range]` y `[Tooltip]` los valores del Inspector.
- Usar `RequireComponent` cuando un componente necesite otro en el mismo GameObject.
- Cachear con `GetComponent` en `Awake`, no llamarlo en `Update`.
- **Todo el código va en inglés**: identificadores, comentarios y documentación XML
  (`/// <summary>`, `<param>`, `<returns>`, `<exception>`). Las explicaciones del agente al
  usuario siguen en español.
- Comentarios breves y solo cuando expliquen el **porqué**. Documentación XML en todos los
  tipos y miembros públicos.
- Un tipo público por archivo; el nombre del archivo coincide con el del tipo.
