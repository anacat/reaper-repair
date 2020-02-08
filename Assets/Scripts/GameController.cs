using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public RhythmData rhythmData;

    public AnimatedNatureElement grassLeft;
    public AnimatedNatureElement grassRight;

    public AnimatedNatureElement flowerLeft;
    public AnimatedNatureElement flowerRight;

    public AnimatedNatureElement treeLeft;
    public AnimatedNatureElement treeRight;

    public AnimatedNatureElement birdLeft;
    public AnimatedNatureElement birdRight;

    [Space(10)]
    public List<AnimatedNatureElement> grassList;
    public List<AnimatedNatureElement> flowerList;
    public List<AnimatedNatureElement> treeList;
    public List<AnimatedNatureElement> birdList;

    public RhythmData.Level currentLevel;

    private void Start()
    {
        grassList.ForEach(g => g.enabled = false);
        flowerList.ForEach(f => f.enabled = false);
        treeList.ForEach(t => t.enabled = false);
        birdList.ForEach(b => b.enabled = false);
    }

    private void Update()
    {
        if (currentLevel > rhythmData.level)
        {
            DisablePreviousLevelStuff();
        }

        if (InputManager.IsValidKey() && currentLevel != rhythmData.level)
        {
            switch (rhythmData.level)
            {
                case RhythmData.Level.Dark:
                    break;
                case RhythmData.Level.Grass:
                    grassList.ForEach(g => g.enabled = true);
                    break;
                case RhythmData.Level.Flower:
                    grassList.ForEach(g => g.Finish(true));
                    flowerList.ForEach(f => f.enabled = true);
                    break;
                case RhythmData.Level.Tree:
                    flowerList.ForEach(f => f.Finish(true));
                    treeList.ForEach(t => t.enabled = true);
                    break;
                case RhythmData.Level.Bird:
                    treeList.ForEach(t => t.Finish(true));
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
                grassList.ForEach(g => g.Finish(false));
                flowerList.ForEach(f => f.enabled = false);
                break;
            case RhythmData.Level.Flower:
                flowerList.ForEach(f => f.Finish(false));
                treeList.ForEach(t => t.enabled = false);
                break;
            case RhythmData.Level.Tree:
                treeList.ForEach(t => t.Finish(false));
                birdList.ForEach(b => b.enabled = false);
                break;
            case RhythmData.Level.Bird:
                break;
        }
    }

    public bool IsCurrentLevelFinished()
    {
        switch (rhythmData.level)
        {
            case RhythmData.Level.Grass:
                return IsGrassFinished();
            case RhythmData.Level.Flower:
                return IsFlowerFinished();
            case RhythmData.Level.Tree:
                //return IsTreeFinished(); //uncomment when birds are implemented
                return false;
            //case RhythmData.Level.Bird:
            //    return IsBirdFinished();
        }

        return false;
    }

    public bool IsCurrentLevelDecreasing()
    {
        switch (rhythmData.level)
        {
            case RhythmData.Level.Grass:
                return IsGrassLevelDecrease();
            case RhythmData.Level.Flower:
                return IsFlowerLevelDecrease();
            case RhythmData.Level.Tree:
                return IsTreeLevelDecrease();
            //case RhythmData.Level.Bird:
            //    return IsBirdFinished();
        }

        return false;
    }

    public bool IsGrassFinished()
    {
        return grassLeft.spriteRenderer.sprite == grassLeft.spriteList[grassLeft.spriteList.Count - 1] &&
               grassRight.spriteRenderer.sprite == grassRight.spriteList[grassRight.spriteList.Count - 1];
    }

    public bool IsFlowerFinished()
    {
        return flowerLeft.spriteRenderer.sprite == flowerLeft.spriteList[flowerLeft.spriteList.Count - 1] &&
               flowerRight.spriteRenderer.sprite == flowerRight.spriteList[flowerRight.spriteList.Count - 1];
    }

    public bool IsTreeFinished()
    {
        return treeLeft.spriteRenderer.sprite == treeLeft.spriteList[treeLeft.spriteList.Count - 1] &&
               treeRight.spriteRenderer.sprite == treeRight.spriteList[treeRight.spriteList.Count - 1];
    }

    public bool IsBirdFinished()
    {
        return birdLeft.spriteRenderer.sprite == birdLeft.spriteList[birdLeft.spriteList.Count - 1] &&
               birdRight.spriteRenderer.sprite == birdRight.spriteList[birdRight.spriteList.Count - 1];
    }

    public bool IsGrassLevelDecrease()
    {
        return grassLeft.spriteRenderer.sprite == grassLeft.spriteList[0] &&
               grassRight.spriteRenderer.sprite == grassRight.spriteList[0];
    }

    public bool IsFlowerLevelDecrease()
    {
        return flowerLeft.spriteRenderer.sprite == flowerLeft.spriteList[0] &&
               flowerRight.spriteRenderer.sprite == flowerRight.spriteList[0];
    }

    public bool IsTreeLevelDecrease()
    {
        return treeLeft.spriteRenderer.sprite == treeLeft.spriteList[0] &&
               treeRight.spriteRenderer.sprite == treeRight.spriteList[0];
    }

    public bool IsBirdLevelDecrease()
    {
        return birdLeft.spriteRenderer.sprite == birdLeft.spriteList[0] &&
               birdRight.spriteRenderer.sprite == birdRight.spriteList[0];
    }
}
