using System;
using System.Collections.Generic;

namespace DiceBattleGame
{

    /// Handles available weapons, current weapon selection, and attack actions.
    /// List can be expand later by adding more weapons in the constructor.

    internal class WeaponSystem
    {
        // List that stores all weapons the player can choose from.
        private readonly List<Weapon> weaponShelf = new List<Weapon>();

        // The weapon currently selected by the player.
        private Weapon chosenWeapon;

        // Constructor: define all weapons available in the game.
        public WeaponSystem()
        {
            // --- AVAILABLE WEAPONS ---
            weaponShelf.Add(new Sword());
            weaponShelf.Add(new Rapier());

            // --- ADD MORE WEAPONS HERE LATER ---

        }


        /// Returns a list of weapon names (for displaying in dropdown menus, etc.).

        public List<string> GetWeaponNames()
        {
            var names = new List<string>();
            foreach (var w in weaponShelf)
                names.Add(w.GetType().Name);
            return names;
        }


        /// Selects a weapon based on its index in the list (0-based).

        public void SelectByIndex(int index)
        {
            if (index < 0 || index >= weaponShelf.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid weapon choice.");
            chosenWeapon = weaponShelf[index];
        }

       

        /// Returns the name of the current selected weapon.

        public string CurrentName() =>
            chosenWeapon == null ? "(none)" : chosenWeapon.GetType().Name;

        public string CurrentDamageType() =>
     chosenWeapon == null ? "-" : chosenWeapon.GetDamageType();

        /// Performs an attack using the selected weapon and returns the rolled damage.

        public int Attack()
        {
            if (chosenWeapon == null)
                throw new InvalidOperationException("Please pick a weapon first.");
            return chosenWeapon.Attack();
        }

        //
        public Weapon GetCurrentWeapon()
        {
            if (chosenWeapon == null)
            {
                throw new InvalidOperationException("No weapon has been selected yet");
                
            }
            return chosenWeapon;
        }

    }
}