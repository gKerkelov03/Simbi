﻿namespace Simbi.Services.Models;

public class MaterialServiceModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public double QuantityAvailableInKilograms { get; set; }

    public string Size { get; set; } // има л ф б някви obiknoveno sa bukva cifra ma ima i nqkvi dr izvrateni
    public double PricePerKilogram { get; set; }
}
