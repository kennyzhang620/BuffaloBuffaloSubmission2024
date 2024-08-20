using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimesofDay
{
    Morning,
    Afternoon,
    Night
}

public class DayLightManager : MonoBehaviour
{
    /*
     * ● Morning
○ Increases Spawn Rate of Archers by a range of .2 to .4.
○ Decreases Spawn Rate of Brown Enemies by a range of -.1 to -.3
● Afternoon
○ No Assassins can spawn during the Afternoon
○ All Grunts increase their Attack Power by 1
○ All other Enemies increase/decrease their Spawn Rate by a range of -.2
to .2 ● Night
○ Assassins increase their Speed by a range of 0 to 2
     */
    public EnemyPool EnemyPool;
    public TimesofDay SelectedTimesofDay;
    public Material SunMat;

    void ApplyModifiers(TimesofDay times)
    {
        switch (times)
        {
            case TimesofDay.Morning:
                {
                    foreach (ColouredEnemy e in EnemyPool.Enemies)
                    {
                        if (e.Class == EnemyType.Archer)
                        {
                            e.SpawnRate += Random.Range(0.2f, 0.4f);
                        }

                        if (e.EnemyColour == new Color(89, 23, 23))
                        {
                            e.SpawnRate -= Random.Range(0.1f, 0.3f);
                        }
                    }
                }
                break;
            case TimesofDay.Afternoon:
                {
                    foreach (ColouredEnemy e in EnemyPool.Enemies)
                    {
                        
                        if (e.Class == EnemyType.Assassin)
                        {
                            e.SpawnRate = 0;
                        }

                        else if (e.Class == EnemyType.Grunt)
                        {
                            e.AttackPower += 1;
                        }
                        else
                        {
                            e.SpawnRate += Random.Range(-0.2f, 0.2f);
                        }
                    }
                }
                break;
            case TimesofDay.Night:
                {
                    foreach (ColouredEnemy e in EnemyPool.Enemies)
                    {

                        if (e.Class == EnemyType.Assassin)
                        {
                            e.Speed += Random.Range(0, 2);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Shader sunS = SunMat.shader;
        print(sunS.FindPropertyIndex("Atmosphere Thickness"));

        Shader.SetGlobalFloat("Atmosphere Thickness", 2f);
        
        int rval = Random.Range(0, 75) / 25;

        switch (rval)
        {
            case 0:
                SelectedTimesofDay = TimesofDay.Morning;
                break;
            case 1:
                SelectedTimesofDay = TimesofDay.Afternoon;
                break;
            case 2:
                SelectedTimesofDay = TimesofDay.Night;
                break;
            default:
                break;
        }

        ApplyModifiers(SelectedTimesofDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
