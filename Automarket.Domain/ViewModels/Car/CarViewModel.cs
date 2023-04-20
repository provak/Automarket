﻿using Automarket.Domain.Enums;
using System;

namespace Automarket.Domain.ViewModels.Car
{
    public class CarViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public string TypeCar { get; set; }
    }
}
