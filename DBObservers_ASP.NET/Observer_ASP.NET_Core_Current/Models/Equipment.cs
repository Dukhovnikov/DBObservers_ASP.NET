using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Observer_ASP.NET_Core_Current.Models
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>Максимальная сила давления</summary>
        public int MaximumPressureForce { get; set; }

        /// <summary>Максимальная рабочая температура</summary>
        public int MaximumWorkingTemperature { get; set; }

        /// <summary>Скорость роста температуры</summary>
        public int TemperatureRiseRate { get; set; }

        /// <summary>Электропитание</summary>
        public int PowerSupply { get; set; }

        /// <summary>Потребляемая мощность</summary>
        public int PowerConsumption { get; set; }

        /// <summary>Сжатый воздух</summary>
        public int CompressedAir { get; set; }

        /// <summary>Потребление воздуха</summary>
        public int AirConsumption { get; set; }

        /// <summary>Габариты</summary>
        public string Dimensions { get; set; }

        /// <summary>Вес</summary>
        public int Weight { get; set; }

        public Guid EquipmentTypeId { get; set; }

        /// <summary>Вид системы</summary>
        public EquipmentType EquipmentType { get; set; }

        [NotMapped]
        public string EquipmentTypeString { get; set; }
    }

    public class EquipmentType : BaseEntity
    {
        public string Name { get; set; }

        public IList<Equipment> Equipments { get; set; }

        public EquipmentType()
        {
            Equipments = new List<Equipment>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
