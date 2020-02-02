using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public RhythmData rhythmData;

    public List<AnimatedNatureElement> grassList;
    public List<AnimatedNatureElement> flowerList;
    public List<AnimatedNatureElement> treeList;
    public List<AnimatedNatureElement> birdList;

    public RhythmData.Level currentLevel;

    private void Start()
    {
        grassList.ForEach(g => g.enabled = false);
    }

    private void Update()
    {
        if (InputManager.IsValidKey() && currentLevel != rhythmData.level)
        {
            if (currentLevel > rhythmData.level)
            {
                DisablePreviousLevelStuff();
            }

            switch (rhythmData.level)
            {
                case RhythmData.Level.Dark:
                    break;
                case RhythmData.Level.Grass:
                    grassList.ForEach(g => g.enabled = true);
                    break;
                case RhythmData.Level.Flower:
                    grassList.ForEach(g => g.Finish(true));
                    break;
                case RhythmData.Level.Tree:
                    break;
                case RhythmData.Level.Bird:
                    break;
            }

            currentLevel = rhythmData.level;
        }
    }

    private void DisablePreviousLevelStuff()
    {
        switch (rhythmData.level)
        {
            case RhythmData.Level.Dark:
                grassList.ForEach(g => g.enabled = false);
                break;
            case RhythmData.Level.Grass:
                flowerList.ForEach(f => f.enabled = false);
                break;
            case RhythmData.Level.Flower:
                treeList.ForEach(t => t.enabled = false);
                break;
            case RhythmData.Level.Tree:
                birdList.ForEach(b => b.enabled = false);
                break;
            case RhythmData.Level.Bird:
                break;
        }
    }
}
