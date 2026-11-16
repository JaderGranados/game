# 04 · Tests

- La lógica de `TopDown.Core` se cubre con **tests EditMode** (NUnit, Unity Test Framework).
- Cada clase nueva de Core trae al menos un test del caso normal y uno de un caso límite.
- Nombres: `Metodo_Condicion_Resultado`, por ejemplo `TakeDamage_MoreThanCurrent_ClampsToZero`.
- Estructura Arrange / Act / Assert, separada por líneas en blanco.
- Los tests PlayMode (comportamiento en escena) se añaden más adelante, cuando el
  usuario haya aprendido los EditMode.
- Antes de dar un paso por terminado, los tests deben pasar
  (Window > General > Test Runner, o en modo batch: `-runTests -testPlatform EditMode`).
