

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;

namespace CarGo.Application.interfaces.Carinterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrand();
        List<Car> GetLast5CarsListWithBrand();

    }
}