using InventoryControl.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain.Base
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }
        public void AsignarId()
        {
            Id = 1;
        }
    }
}
