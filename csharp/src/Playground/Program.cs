using TopDown.Core;
for (int wave = 1; wave <= 10; wave++)
{
    Console.WriteLine($"Wave {wave}: {WaveMath.EnemyCount(wave, 3, 2)} enemies");
}

try
{
    WaveMath.EnemyCount(int.MaxValue, 3, 2);
}
catch (OverflowException ex)
{
    Console.WriteLine($"Error de desbordamiento: {ex.Message}");
}

try
{
    WaveMath.EnemyCount(0, 3, 2);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error esperado: {ex.Message}");
}