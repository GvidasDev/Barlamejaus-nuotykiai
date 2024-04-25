using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public event Action<int> onPlayerLevelChange;
    public void PlayerLevelChange(int level)
    {
        if(onPlayerLevelChange != null)
        {
            onPlayerLevelChange(level);
        }
    }

    public event Action<int> onExperienceGained;
    public void ExperienceGained(int experience)
    {
        if (onExperienceGained != null)
        {
            onExperienceGained(experience);
        }
    }

    public event Action<int> onExperienceChange;
    public void ExperienceChange(int experience)
    {
        if (onExperienceChange != null)
        {
            onExperienceChange(experience);
        }
    }
}
