using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private bool usedBonus = false;

        public Giant(string name, Point position, int owner = 0) : base(name, position, owner)
        {
            this.HitPoints = 200;
        }

        public int AttackPoints
        {
            get 
            {
                if (usedBonus)
                {
                    return 250;
                }
                else
                {
                    return 150; 
                }
                
            }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (this.usedBonus == false)
                {
                    this.usedBonus = true;
                }                

                return true;
            }

            return false;
        }
    }
}
