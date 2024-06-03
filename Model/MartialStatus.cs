using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Model
{
    /// <summary>
    /// Семейное положение
    /// </summary>
    public enum MartialStatus
    {
        /// <summary>
        /// Холост (для мужчины)
        /// </summary>
        Single,
        /// <summary>
        /// Женат (для мужчины)
        /// </summary>
        Married,
        /// <summary>
        /// Не замужем (для женщины)
        /// </summary>
        NotMarried,
        /// <summary>
        /// В разводе (для обоих)
        /// </summary>
        Divorced

    }
}
