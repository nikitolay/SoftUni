﻿using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons= new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
            => Models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
                => weapons.Remove(Models.FirstOrDefault(x => x.GetType().Name == name));
    }
}
