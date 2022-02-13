namespace E09_TestTask
{
    public class EnemyBallonsSpawner : EnemySpawner
    {
        public override Entity Prefab => _settings.BalloonEnemyPrefab;

        public override float SpawnTimeout => base.SpawnTimeout * 4;
    }
}