﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;

namespace CarGo.Application.interfaces.CarDescriptioninterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescription(int carId);
    }
}
